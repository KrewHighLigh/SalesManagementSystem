using Microsoft.Extensions.DependencyInjection;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.UI
{
    public partial class PaymentForm : Form
    {
        private static PaymentService Servicio() =>
            Program.ServiceProvider.GetRequiredService<PaymentService>();

        private static OrderService ServicioOrden() =>
            Program.ServiceProvider.GetRequiredService<OrderService>();

        private int _selectedId = 0;
        private bool _editando = false;

        public PaymentForm()
        {
            InitializeComponent();
        }

        private async void PaymentForm_Load(object? sender, EventArgs e)
        {
            await CargarPagos();
            await CargarOrdenes();
        }

        private async Task CargarPagos()
        {
            try
            {
                SetCargando(true);
                string filtro = txtBuscar.Text.Trim().ToLower();

                var lista = await Servicio().GetListConRelaciones(
                    p => filtro == string.Empty
                      || (p.OrderId != null && p.OrderId.ToString()!.Contains(filtro))
                      || (p.PaymentMethod != null && p.PaymentMethod.ToLower().Contains(filtro)));

                var vista = lista.Select(p => new
                {
                    p.PaymentId,
                    p.OrderId,
                    Monto = p.Amount.ToString("C2"),
                    p.PaymentMethod,
                    Fecha = p.PaymentDate?.ToString("dd/MM/yyyy") ?? "—",
                    p.Notes
                }).ToList();

                dgvPagos.DataSource = null;
                dgvPagos.DataSource = vista;

                lblEstado.Text = $"✔  {vista.Count} pago(s) encontrado(s).";
                lblEstado.ForeColor = Color.FromArgb(166, 227, 161);
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async Task CargarOrdenes()
        {
            try
            {
                var ordenes = await ServicioOrden().GetListConRelaciones(
                    o => o.Status != "Canceled" && o.Status != "Completed");

                cmbOrden.DisplayMember = "DisplayText";
                cmbOrden.ValueMember = "OrderId";
                cmbOrden.DataSource = ordenes.Select(o => new
                {
                    o.OrderId,
                    DisplayText = $"Order #{o.OrderId}" +
                        (o.Customer != null ? $" — {o.Customer!.FirstName} {o.Customer.LastName}" : "")
                }).ToList();
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar órdenes: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
        }

        private async Task GuardarPago()
        {
            if (!Validar()) return;
            try
            {
                SetCargando(true);

                var entidad = new Payment
                {
                    PaymentId = _editando ? _selectedId : 0,
                    OrderId = (int?)cmbOrden.SelectedValue,
                    Amount = decimal.Parse(txtMonto.Text.Trim()),
                    PaymentMethod = cmbMetodo.SelectedItem?.ToString() ?? string.Empty,
                    PaymentDate = dtpFecha.Value,
                    Notes = string.IsNullOrWhiteSpace(txtNotas.Text) ? null : txtNotas.Text.Trim()
                };

                bool ok = await Servicio().Guardar(entidad);
                lblEstado.Text = ok
                    ? (_editando ? "✔  Pago actualizado." : "✔  Pago guardado.")
                    : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);

                if (ok) { LimpiarFormulario(); await CargarPagos(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async Task EliminarPago()
        {
            if (_selectedId == 0)
            {
                MessageBox.Show("Selecciona un pago de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"¿Eliminar pago #{_selectedId}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            try
            {
                SetCargando(true);
                bool ok = await Servicio().Eliminar(_selectedId);
                lblEstado.Text = ok ? "✔  Pago eliminado." : "✘  No se encontró.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);
                if (ok) { LimpiarFormulario(); await CargarPagos(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async void btnGuardar_Click(object s, EventArgs e) => await GuardarPago();
        private async void btnEliminar_Click(object s, EventArgs e) => await EliminarPago();
        private void btnNuevo_Click(object s, EventArgs e) => LimpiarFormulario();
        private async void btnBuscar_Click(object s, EventArgs e) => await CargarPagos();

        private async void txtBuscar_KeyDown(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) await CargarPagos();
        }

        private async void dgvPagos_SelectionChanged(object s, EventArgs e)
        {
            if (dgvPagos.SelectedRows.Count == 0) return;
            if (dgvPagos.SelectedRows[0].Cells["PaymentId"].Value is not int id) return;

            var pago = await Servicio().Buscar(id);
            if (pago == null) return;

            _selectedId = pago.PaymentId;
            _editando = true;

            if (pago.OrderId.HasValue)
                cmbOrden.SelectedValue = pago.OrderId.Value;
            else
                cmbOrden.SelectedIndex = -1;
            txtMonto.Text = pago.Amount.ToString("F2");
            cmbMetodo.SelectedItem = pago.PaymentMethod;
            dtpFecha.Value = pago.PaymentDate ?? DateTime.Now;
            txtNotas.Text = pago.Notes ?? string.Empty;

            lblTituloForm.Text = "✏  Editar Pago";
            btnGuardar.Text = "💾  Actualizar";
            btnEliminar.Enabled = true;
        }

        private bool Validar()
        {
            if (cmbOrden.SelectedIndex == -1)
            {
                lblEstado.Text = "⚠  Selecciona una orden.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                cmbOrden.Focus();
                return false;
            }
            if (!decimal.TryParse(txtMonto.Text.Trim(), out decimal monto) || monto <= 0)
            {
                lblEstado.Text = "⚠  Ingresa un monto válido.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                txtMonto.Focus();
                return false;
            }
            if (cmbMetodo.SelectedIndex == -1)
            {
                lblEstado.Text = "⚠  Selecciona un método de pago.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                cmbMetodo.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            _selectedId = 0; _editando = false;
            cmbOrden.SelectedIndex = -1;
            txtMonto.Clear();
            cmbMetodo.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            txtNotas.Clear();
            lblTituloForm.Text = "＋  Nuevo Pago";
            btnGuardar.Text = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgvPagos.ClearSelection();
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
