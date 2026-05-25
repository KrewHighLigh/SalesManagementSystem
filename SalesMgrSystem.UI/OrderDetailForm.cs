using Microsoft.Extensions.DependencyInjection;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.UI
{
    public partial class OrderDetailForm : Form
    {
        private static OrderDetailService Servicio() =>
            Program.ServiceProvider.GetRequiredService<OrderDetailService>();

        private static OrderService NuevoOrderService() =>
            Program.ServiceProvider.GetRequiredService<OrderService>();

        private static ProductService NuevoProductService() =>
            Program.ServiceProvider.GetRequiredService<ProductService>();

        private int _selectedId = 0;
        private bool _editando = false;

        public OrderDetailForm()
        {
            InitializeComponent();
        }

        private async void OrderDetailForm_Load(object? sender, EventArgs e)
        {
            await CargarOrdenes();
            await CargarProductos();
            await CargarDetalles();
        }

        private async Task CargarDetalles()
        {
            try
            {
                SetCargando(true);
                string filtro = txtBuscar.Text.Trim().ToLower();

                var lista = await Servicio().GetListConRelaciones(
                    d => filtro == string.Empty
                      || (d.Order != null && d.Order.OrderId.ToString().Contains(filtro, StringComparison.OrdinalIgnoreCase))
                      || (d.Product != null && d.Product.ProductName.Contains(filtro, StringComparison.OrdinalIgnoreCase)));

                var vista = lista.Select(d => new
                {
                    d.OrderDetailId,
                    d.OrderId,
                    NombreProducto = d.Product?.ProductName ?? "—",
                    d.Quantity,
                    d.UnitPrice,
                    d.Subtotal
                }).ToList();

                dgvDetalles.DataSource = null;
                dgvDetalles.DataSource = vista;

                lblEstado.Text = $"✔  {vista.Count} detalle(s) encontrado(s).";
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
                var ordenes = await NuevoOrderService().GetList(o => true);
                cmbOrden.DataSource = ordenes
                    .Select(o => new { o.OrderId, DisplayText = $"Orden #{o.OrderId}" })
                    .ToList();
                cmbOrden.DisplayMember = "DisplayText";
                cmbOrden.ValueMember = "OrderId";
                cmbOrden.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar órdenes: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
        }

        private async Task CargarProductos()
        {
            try
            {
                var productos = await NuevoProductService().GetList(p => true);
                cmbProducto.DataSource = productos
                    .Select(p => new { p.ProductId, p.ProductName, p.UnitPrice })
                    .ToList();
                cmbProducto.DisplayMember = "ProductName";
                cmbProducto.ValueMember = "ProductId";
                cmbProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar productos: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
        }

        private async Task GuardarDetalle()
        {
            if (!Validar()) return;
            try
            {
                SetCargando(true);
                var entidad = new OrderDetail
                {
                    OrderDetailId = _editando ? _selectedId : 0,
                    OrderId = (int)cmbOrden.SelectedValue!,
                    ProductId = (int)cmbProducto.SelectedValue!,
                    Quantity = int.Parse(txtCantidad.Text),
                    UnitPrice = decimal.Parse(txtPrecio.Text),
                    Subtotal = decimal.Parse(txtSubtotal.Text)
                };

                bool ok = await Servicio().Guardar(entidad);
                lblEstado.Text = ok
                    ? (_editando ? "✔  Detalle actualizado." : "✔  Detalle guardado.")
                    : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);

                if (ok) { LimpiarFormulario(); await CargarDetalles(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async Task EliminarDetalle()
        {
            if (_selectedId == 0)
            {
                MessageBox.Show("Selecciona un detalle de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"¿Eliminar detalle #{_selectedId}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            try
            {
                SetCargando(true);
                bool ok = await Servicio().Eliminar(_selectedId);
                lblEstado.Text = ok ? "✔  Detalle eliminado." : "✘  No se encontró.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);
                if (ok) { LimpiarFormulario(); await CargarDetalles(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private void CalcularSubtotal()
        {
            if (int.TryParse(txtCantidad.Text, out int qty) && qty > 0
                && decimal.TryParse(txtPrecio.Text, out decimal price) && price > 0)
            {
                txtSubtotal.Text = (qty * price).ToString("F2");
            }
            else
            {
                txtSubtotal.Text = "0.00";
            }
        }

        private async void BtnGuardar_Click(object s, EventArgs e) => await GuardarDetalle();
        private async void BtnEliminar_Click(object s, EventArgs e) => await EliminarDetalle();
        private void BtnNuevo_Click(object s, EventArgs e) => LimpiarFormulario();
        private async void BtnBuscar_Click(object s, EventArgs e) => await CargarDetalles();

        private async void TxtBuscar_KeyDown(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) await CargarDetalles();
        }

        private void TxtCantidad_TextChanged(object? sender, EventArgs e) => CalcularSubtotal();
        private void TxtPrecio_TextChanged(object? sender, EventArgs e) => CalcularSubtotal();

        private async void CmbProducto_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                if (cmbProducto.SelectedValue is int productId && productId > 0)
                {
                    var product = await NuevoProductService().Buscar(productId);
                    if (product != null)
                        txtPrecio.Text = product.UnitPrice.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar producto: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
        }

        private async void DgvDetalles_SelectionChanged(object s, EventArgs e)
        {
            try
            {
                if (dgvDetalles.SelectedRows.Count == 0) return;
                if (dgvDetalles.SelectedRows[0].Cells["OrderDetailId"].Value is not int id) return;

                var det = await Servicio().Buscar(id);
                if (det == null) return;

                _selectedId = det.OrderDetailId;
                _editando = true;
                cmbOrden.SelectedValue = det.OrderId.HasValue ? (object)det.OrderId.Value : (object)0;
                cmbProducto.SelectedValue = det.ProductId.HasValue ? (object)det.ProductId.Value : (object)0;
                txtCantidad.Text = det.Quantity.ToString();
                txtPrecio.Text = det.UnitPrice.ToString("F2");
                CalcularSubtotal();

                lblTituloForm.Text = "✏  Editar Detalle";
                btnGuardar.Text = "💾  Actualizar";
                btnEliminar.Enabled = true;
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar detalle: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
        }

        private bool Validar()
        {
            if (cmbOrden.SelectedIndex < 0)
            {
                lblEstado.Text = "⚠  Selecciona una orden.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                cmbOrden.Focus();
                return false;
            }
            if (cmbProducto.SelectedIndex < 0)
            {
                lblEstado.Text = "⚠  Selecciona un producto.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                cmbProducto.Focus();
                return false;
            }
            if (!int.TryParse(txtCantidad.Text, out int qty) || qty <= 0)
            {
                lblEstado.Text = "⚠  Cantidad debe ser un número positivo.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                txtCantidad.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            _selectedId = 0; _editando = false;
            cmbOrden.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtSubtotal.Text = "0.00";
            lblTituloForm.Text = "＋  Nuevo Detalle";
            btnGuardar.Text = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgvDetalles.ClearSelection();
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
