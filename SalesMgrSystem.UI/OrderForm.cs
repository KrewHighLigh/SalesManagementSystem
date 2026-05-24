using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.UI.Services;

namespace SalesMgrSystem.UI
{
    public partial class OrderForm : Form
    {
        private readonly OrderService    _service;
        private readonly CustomerService _custService;
        private readonly UserService     _userService;
        private int  _selectedId = 0;
        private bool _editando   = false;

        public OrderForm()
        {
            InitializeComponent();
            var ctx = new SalesMgrContext();
            _service     = new OrderService(ctx);
            _custService = new CustomerService(ctx);
            _userService = new UserService(ctx);
            _ = CargarCombos();
            _ = Cargar();
        }

        private async Task CargarCombos()
        {
            var clientes = await _custService.GetList(c => true);
            cmbCliente.DataSource    = clientes;
            cmbCliente.DisplayMember = "FirstName";
            cmbCliente.ValueMember   = "CustomerId";

            var usuarios = await _userService.GetList(u => true);
            cmbUsuario.DataSource    = usuarios;
            cmbUsuario.DisplayMember = "FullName";
            cmbUsuario.ValueMember   = "UserId";
        }

        private async Task Cargar()
        {
            try
            {
                SetCargando(true);
                string f = txtBuscar.Text.Trim().ToLower();
                var lista = await _service.GetListConRelaciones(
                    o => f == string.Empty
                      || (o.Status != null && o.Status.ToLower().Contains(f))
                      || (o.Customer != null && (o.Customer.FirstName + " " + o.Customer.LastName).ToLower().Contains(f)));

                var vista = lista.Select(o => new {
                    o.OrderId,
                    Cliente  = o.Customer != null ? o.Customer.FirstName + " " + o.Customer.LastName : "—",
                    Fecha    = o.OrderDate.HasValue ? o.OrderDate.Value.ToString("dd/MM/yyyy") : "—",
                    Total    = o.TotalAmount.HasValue ? o.TotalAmount.Value.ToString("C2") : "$0.00",
                    o.Status,
                    Detalles = o.OrderDetails.Count
                }).ToList();

                dgv.DataSource = null;
                dgv.DataSource = vista;
                lblEstado.Text      = $"✔  {vista.Count} orden(es).";
                lblEstado.ForeColor = Color.FromArgb(166,227,161);
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Guardar()
        {
            if (!decimal.TryParse(txtTotal.Text, out decimal total)) { MostrarWarning("Total inválido."); return; }
            try
            {
                SetCargando(true);
                var e = new Order {
                    OrderId    = _editando ? _selectedId : 0,
                    CustomerId = cmbCliente.SelectedValue as int?,
                    UserId     = cmbUsuario.SelectedValue as int?,
                    OrderDate  = _editando ? null : DateTime.Now,
                    TotalAmount = total,
                    Status     = cmbStatus.Text,
                    Notes      = string.IsNullOrWhiteSpace(txtNotas.Text) ? null : txtNotas.Text.Trim()
                };
                bool ok = await _service.Guardar(e);
                lblEstado.Text      = ok ? (_editando ? "✔  Orden actualizada." : "✔  Orden guardada.") : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok ? Color.FromArgb(166,227,161) : Color.FromArgb(243,139,168);
                if (ok) { Limpiar(); await Cargar(); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Eliminar()
        {
            if (_selectedId == 0) { MessageBox.Show("Selecciona una orden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"¿Eliminar Orden #{_selectedId}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                SetCargando(true);
                bool ok = await _service.Eliminar(_selectedId);
                lblEstado.Text      = ok ? "✔  Orden eliminada." : "✘  No encontrada.";
                lblEstado.ForeColor = ok ? Color.FromArgb(166,227,161) : Color.FromArgb(243,139,168);
                if (ok) { Limpiar(); await Cargar(); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async void btnGuardar_Click(object s, EventArgs e) => await Guardar();
        private async void btnEliminar_Click(object s, EventArgs e) => await Eliminar();
        private void btnNuevo_Click(object s, EventArgs e) => Limpiar();
        private async void btnBuscar_Click(object s, EventArgs e) => await Cargar();
        private async void txtBuscar_KeyDown(object s, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) await Cargar(); }

        private async void dgv_SelectionChanged(object s, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            if (dgv.SelectedRows[0].Cells["OrderId"].Value is not int id) return;
            var o = await _service.Buscar(id);
            if (o == null) return;
            _selectedId = o.OrderId; _editando = true;
            if (o.CustomerId.HasValue) cmbCliente.SelectedValue = o.CustomerId.Value;
            if (o.UserId.HasValue)     cmbUsuario.SelectedValue = o.UserId.Value;
            txtTotal.Text       = o.TotalAmount.HasValue ? o.TotalAmount.Value.ToString("F2") : "0";
            cmbStatus.Text      = o.Status ?? "Pending";
            txtNotas.Text       = o.Notes ?? string.Empty;
            lblTituloForm.Text  = $"✏  Editar Orden #{id}";
            btnGuardar.Text     = "💾  Actualizar";
            btnEliminar.Enabled = true;
        }

        private void Limpiar()
        {
            _selectedId = 0; _editando = false;
            txtTotal.Clear(); txtNotas.Clear();
            cmbStatus.SelectedIndex = 0;
            if (cmbCliente.Items.Count > 0) cmbCliente.SelectedIndex = 0;
            if (cmbUsuario.Items.Count > 0) cmbUsuario.SelectedIndex = 0;
            lblTituloForm.Text  = "＋  Nueva Orden";
            btnGuardar.Text     = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgv.ClearSelection();
        }

        private void SetCargando(bool v) { btnGuardar.Enabled=!v; btnNuevo.Enabled=!v; btnBuscar.Enabled=!v; btnEliminar.Enabled=!v&&_selectedId!=0; progressBar.Visible=v; Cursor=v?Cursors.WaitCursor:Cursors.Default; }
        private void MostrarError(string m) { lblEstado.Text=$"✘  {m}"; lblEstado.ForeColor=Color.FromArgb(243,139,168); }
        private void MostrarWarning(string m) { lblEstado.Text=$"⚠  {m}"; lblEstado.ForeColor=Color.FromArgb(249,226,175); }
    }
}
