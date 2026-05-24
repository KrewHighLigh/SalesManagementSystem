using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.UI.Services;

namespace SalesMgrSystem.UI
{
    public partial class PaymentForm : Form
    {
        private readonly PaymentService _service;
        private readonly OrderService   _orderService;
        private int  _selectedId = 0;
        private bool _editando   = false;

        public PaymentForm()
        {
            InitializeComponent();
            var ctx = new SalesMgrContext();
            _service      = new PaymentService(ctx);
            _orderService = new OrderService(ctx);
            _ = CargarOrdenes();
            _ = Cargar();
        }

        private async Task CargarOrdenes()
        {
            var ordenes = await _orderService.GetList(o => true);
            cmbOrden.DataSource    = ordenes;
            cmbOrden.DisplayMember = "OrderId";
            cmbOrden.ValueMember   = "OrderId";
        }

        private async Task Cargar()
        {
            try
            {
                SetCargando(true);
                string f = txtBuscar.Text.Trim().ToLower();
                var lista = await _service.GetListConRelaciones(
                    p => f == string.Empty
                      || (p.PaymentMethod != null && p.PaymentMethod.ToLower().Contains(f))
                      || (p.Notes != null && p.Notes.ToLower().Contains(f)));

                var vista = lista.Select(p => new {
                    p.PaymentId,
                    Orden   = p.OrderId.HasValue ? $"#{p.OrderId}" : "—",
                    Monto   = p.Amount.ToString("C2"),
                    Metodo  = p.PaymentMethod ?? "—",
                    Fecha   = p.PaymentDate.HasValue ? p.PaymentDate.Value.ToString("dd/MM/yyyy") : "—",
                    Notas   = p.Notes ?? "—"
                }).ToList();

                dgv.DataSource = null;
                dgv.DataSource = vista;
                lblEstado.Text      = $"✔  {vista.Count} pago(s).";
                lblEstado.ForeColor = Color.FromArgb(166,227,161);
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Guardar()
        {
            if (!decimal.TryParse(txtMonto.Text, out decimal monto)) { MostrarWarning("Monto inválido."); return; }
            try
            {
                SetCargando(true);
                var e = new Payment {
                    PaymentId     = _editando ? _selectedId : 0,
                    OrderId       = cmbOrden.SelectedValue as int?,
                    Amount        = monto,
                    PaymentMethod = cmbMetodo.Text,
                    PaymentDate   = _editando ? null : DateTime.Now,
                    Notes         = string.IsNullOrWhiteSpace(txtNotas.Text) ? null : txtNotas.Text.Trim()
                };
                bool ok = await _service.Guardar(e);
                lblEstado.Text      = ok ? (_editando ? "✔  Pago actualizado." : "✔  Pago guardado.") : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok ? Color.FromArgb(166,227,161) : Color.FromArgb(243,139,168);
                if (ok) { Limpiar(); await Cargar(); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Eliminar()
        {
            if (_selectedId == 0) { MessageBox.Show("Selecciona un pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"¿Eliminar Pago #{_selectedId}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                SetCargando(true);
                bool ok = await _service.Eliminar(_selectedId);
                lblEstado.Text      = ok ? "✔  Pago eliminado." : "✘  No encontrado.";
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
            if (dgv.SelectedRows[0].Cells["PaymentId"].Value is not int id) return;
            var p = await _service.Buscar(id);
            if (p == null) return;
            _selectedId = p.PaymentId; _editando = true;
            if (p.OrderId.HasValue) cmbOrden.SelectedValue = p.OrderId.Value;
            txtMonto.Text  = p.Amount.ToString("F2");
            cmbMetodo.Text = p.PaymentMethod ?? "Cash";
            txtNotas.Text  = p.Notes ?? string.Empty;
            lblTituloForm.Text  = $"✏  Editar Pago #{id}";
            btnGuardar.Text     = "💾  Actualizar";
            btnEliminar.Enabled = true;
        }

        private void Limpiar()
        {
            _selectedId = 0; _editando = false;
            txtMonto.Clear(); txtNotas.Clear();
            cmbMetodo.SelectedIndex = 0;
            if (cmbOrden.Items.Count > 0) cmbOrden.SelectedIndex = 0;
            lblTituloForm.Text  = "＋  Nuevo Pago";
            btnGuardar.Text     = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgv.ClearSelection();
        }

        private void SetCargando(bool v) { btnGuardar.Enabled=!v; btnNuevo.Enabled=!v; btnBuscar.Enabled=!v; btnEliminar.Enabled=!v&&_selectedId!=0; progressBar.Visible=v; Cursor=v?Cursors.WaitCursor:Cursors.Default; }
        private void MostrarError(string m) { lblEstado.Text=$"✘  {m}"; lblEstado.ForeColor=Color.FromArgb(243,139,168); }
        private void MostrarWarning(string m) { lblEstado.Text=$"⚠  {m}"; lblEstado.ForeColor=Color.FromArgb(249,226,175); }
    }
}
