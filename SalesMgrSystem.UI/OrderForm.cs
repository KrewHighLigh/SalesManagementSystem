using Microsoft.Extensions.DependencyInjection;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.UI
{
    public partial class OrderForm : Form
    {
        private static OrderService Servicio() =>
            Program.ServiceProvider.GetRequiredService<OrderService>();
        private static CustomerService CustomerServicio() =>
            Program.ServiceProvider.GetRequiredService<CustomerService>();
        private static UserService UserServicio() =>
            Program.ServiceProvider.GetRequiredService<UserService>();

        private int _selectedId = 0;
        private bool _editando = false;

        public OrderForm()
        {
            InitializeComponent();
        }

        private async void OrderForm_Load(object? sender, EventArgs e)
        {
            await CargarOrdenes();
            await CargarClientes();
            await CargarUsuarios();
        }

        private async Task CargarOrdenes()
        {
            try
            {
                SetCargando(true);
                string filtro = txtSearch.Text.Trim().ToLower();

                var lista = await Servicio().GetListConRelaciones(
                    o => filtro == string.Empty
                      || o.OrderId.ToString().Contains(filtro)
                      || (o.Customer != null && (o.Customer.FirstName + " " + o.Customer.LastName).ToLower().Contains(filtro))
                      || (o.Status != null && o.Status.ToLower().Contains(filtro)));

                var vista = lista.Select(o => new
                {
                    o.OrderId,
                    Cliente = o.Customer != null ? o.Customer.FirstName + " " + o.Customer.LastName : "—",
                    Usuario = o.User != null ? o.User.FullName : "—",
                    Fecha = o.OrderDate.HasValue ? o.OrderDate.Value.ToString("dd/MM/yyyy") : "—",
                    o.TotalAmount,
                    o.Status
                }).ToList();

                dgvOrdenes.DataSource = null;
                dgvOrdenes.DataSource = vista;

                lblEstado.Text = $"✔  {vista.Count} orden(es) encontrada(s).";
                lblEstado.ForeColor = Color.FromArgb(166, 227, 161);
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async Task CargarClientes()
        {
            try
            {
                var clientes = await CustomerServicio().GetList(c => true);
                cmbCliente.DataSource = null;
                cmbCliente.DisplayMember = "NombreCompleto";
                cmbCliente.ValueMember = "CustomerId";
                cmbCliente.DataSource = clientes
                    .Select(c => new { c.CustomerId, NombreCompleto = c.FirstName + " " + c.LastName })
                    .ToList();
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar clientes: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
        }

        private async Task CargarUsuarios()
        {
            try
            {
                var usuarios = await UserServicio().GetList(u => true);
                cmbUsuario.DataSource = null;
                cmbUsuario.DisplayMember = "FullName";
                cmbUsuario.ValueMember = "UserId";
                cmbUsuario.DataSource = usuarios
                    .Select(u => new { u.UserId, u.FullName })
                    .ToList();
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar usuarios: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
        }

        private async Task GuardarOrden()
        {
            if (!Validar()) return;
            try
            {
                SetCargando(true);
                var entidad = new Order
                {
                    OrderId = _editando ? _selectedId : 0,
                    CustomerId = (int?)cmbCliente.SelectedValue,
                    UserId = (int?)cmbUsuario.SelectedValue,
                    OrderDate = dtpFecha.Value,
                    TotalAmount = string.IsNullOrWhiteSpace(txtTotal.Text) ? null : decimal.Parse(txtTotal.Text),
                    Status = cmbEstado.SelectedItem?.ToString(),
                    Notes = string.IsNullOrWhiteSpace(txtNotas.Text) ? null : txtNotas.Text.Trim()
                };

                bool ok = await Servicio().Guardar(entidad);
                lblEstado.Text = ok
                    ? (_editando ? "✔  Orden actualizada." : "✔  Orden guardada.")
                    : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);

                if (ok) { LimpiarFormulario(); await CargarOrdenes(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async Task EliminarOrden()
        {
            if (_selectedId == 0)
            {
                MessageBox.Show("Selecciona una orden de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"¿Eliminar la orden #{_selectedId}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            try
            {
                SetCargando(true);
                bool ok = await Servicio().Eliminar(_selectedId);
                lblEstado.Text = ok ? "✔  Orden eliminada." : "✘  No se encontró.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);
                if (ok) { LimpiarFormulario(); await CargarOrdenes(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async void btnGuardar_Click(object s, EventArgs e) => await GuardarOrden();
        private async void btnEliminar_Click(object s, EventArgs e) => await EliminarOrden();
        private void btnNuevo_Click(object s, EventArgs e) => LimpiarFormulario();
        private async void btnBuscar_Click(object s, EventArgs e) => await CargarOrdenes();

        private async void txtSearch_KeyDown(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) await CargarOrdenes();
        }

        private async void dgvOrdenes_SelectionChanged(object s, EventArgs e)
        {
            if (dgvOrdenes.SelectedRows.Count == 0) return;
            if (dgvOrdenes.SelectedRows[0].Cells["OrderId"].Value is not int id) return;

            var orden = await Servicio().Buscar(id);
            if (orden == null) return;

            _selectedId = orden.OrderId;
            _editando = true;
            if (orden.CustomerId.HasValue)
                cmbCliente.SelectedValue = orden.CustomerId.Value;
            if (orden.UserId.HasValue)
                cmbUsuario.SelectedValue = orden.UserId.Value;
            dtpFecha.Value = orden.OrderDate ?? DateTime.Now;
            cmbEstado.SelectedItem = orden.Status;
            txtTotal.Text = orden.TotalAmount?.ToString("F2") ?? "0.00";
            txtNotas.Text = orden.Notes ?? string.Empty;

            lblTituloForm.Text = "✏  Editar Orden";
            btnGuardar.Text = "💾  Actualizar";
            btnEliminar.Enabled = true;
        }

        private bool Validar()
        {
            if (cmbCliente.SelectedIndex == -1)
            {
                lblEstado.Text = "⚠  Selecciona un cliente.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                cmbCliente.Focus();
                return false;
            }
            if (cmbUsuario.SelectedIndex == -1)
            {
                lblEstado.Text = "⚠  Selecciona un vendedor.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                cmbUsuario.Focus();
                return false;
            }
            if (cmbEstado.SelectedIndex == -1)
            {
                lblEstado.Text = "⚠  Selecciona un estado.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                cmbEstado.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            _selectedId = 0; _editando = false;
            cmbCliente.SelectedIndex = -1;
            cmbUsuario.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            cmbEstado.SelectedIndex = -1;
            txtTotal.Text = "0.00";
            txtNotas.Clear();
            lblTituloForm.Text = "＋  Nueva Orden";
            btnGuardar.Text = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgvOrdenes.ClearSelection();
            lblEstado.Text = "Listo.";
            lblEstado.ForeColor = Color.FromArgb(127, 132, 156);
        }

        private void SetCargando(bool v)
        {
            btnGuardar.Enabled = !v;
            btnNuevo.Enabled = !v;
            btnBuscar.Enabled = !v;
            btnEliminar.Enabled = !v && _selectedId != 0;
            progressBar.Visible = v;
            Cursor = v ? Cursors.WaitCursor : Cursors.Default;
        }
    }
}
