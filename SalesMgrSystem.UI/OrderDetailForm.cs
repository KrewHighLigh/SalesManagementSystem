using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.UI.Services;

namespace SalesMgrSystem.UI
{
    public partial class OrderDetailForm : Form
    {
        private readonly OrderDetailService _service;
        private readonly OrderService       _orderService;
        private readonly ProductService     _productService;
        private int  _selectedId = 0;
        private bool _editando   = false;

        public OrderDetailForm()
        {
            InitializeComponent();
            var ctx = new SalesMgrContext();
            _service        = new OrderDetailService(ctx);
            _orderService   = new OrderService(ctx);
            _productService = new ProductService(ctx);
            _ = CargarCombos();
            _ = Cargar();
        }

        private async Task CargarCombos()
        {
            var ordenes = await _orderService.GetList(o => true);
            cmbOrden.DataSource = ordenes; cmbOrden.DisplayMember = "OrderId"; cmbOrden.ValueMember = "OrderId";

            var productos = await _productService.GetList(p => true);
            cmbProducto.DataSource = productos; cmbProducto.DisplayMember = "ProductName"; cmbProducto.ValueMember = "ProductId";
        }

        private async Task Cargar()
        {
            try
            {
                SetCargando(true);
                string f = txtBuscar.Text.Trim().ToLower();
                var lista = await _service.GetListConRelaciones(
                    d => f == string.Empty
                      || (d.Product != null && d.Product.ProductName.ToLower().Contains(f)));

                var vista = lista.Select(d => new {
                    d.OrderDetailId,
                    Orden    = d.OrderId.HasValue ? $"#{d.OrderId}" : "—",
                    Producto = d.Product?.ProductName ?? "—",
                    d.Quantity,
                    PrecioUnit = d.UnitPrice.ToString("C2"),
                    Subtotal   = d.Subtotal.HasValue ? d.Subtotal.Value.ToString("C2") : "—"
                }).ToList();

                dgv.DataSource = null;
                dgv.DataSource = vista;
                lblEstado.Text      = $"✔  {vista.Count} detalle(s).";
                lblEstado.ForeColor = Color.FromArgb(166,227,161);
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Guardar()
        {
            if (!int.TryParse(txtCantidad.Text, out int qty) || qty <= 0) { MostrarWarning("Cantidad inválida."); return; }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio)) { MostrarWarning("Precio inválido."); return; }
            try
            {
                SetCargando(true);
                var e = new OrderDetail {
                    OrderDetailId = _editando ? _selectedId : 0,
                    OrderId       = cmbOrden.SelectedValue as int?,
                    ProductId     = cmbProducto.SelectedValue as int?,
                    Quantity      = qty,
                    UnitPrice     = precio
                };
                bool ok = await _service.Guardar(e);
                lblEstado.Text      = ok ? (_editando ? "✔  Detalle actualizado." : "✔  Detalle guardado.") : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok ? Color.FromArgb(166,227,161) : Color.FromArgb(243,139,168);
                if (ok) { Limpiar(); await Cargar(); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Eliminar()
        {
            if (_selectedId == 0) { MessageBox.Show("Selecciona un detalle.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"¿Eliminar Detalle #{_selectedId}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                SetCargando(true);
                bool ok = await _service.Eliminar(_selectedId);
                lblEstado.Text      = ok ? "✔  Detalle eliminado." : "✘  No encontrado.";
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
            if (dgv.SelectedRows[0].Cells["OrderDetailId"].Value is not int id) return;
            var d = await _service.Buscar(id);
            if (d == null) return;
            _selectedId = d.OrderDetailId; _editando = true;
            if (d.OrderId.HasValue)   cmbOrden.SelectedValue    = d.OrderId.Value;
            if (d.ProductId.HasValue) cmbProducto.SelectedValue = d.ProductId.Value;
            txtCantidad.Text = d.Quantity.ToString();
            txtPrecio.Text   = d.UnitPrice.ToString("F2");
            lblTituloForm.Text  = $"✏  Editar Detalle #{id}";
            btnGuardar.Text     = "💾  Actualizar";
            btnEliminar.Enabled = true;
        }

        private void Limpiar()
        {
            _selectedId = 0; _editando = false;
            txtCantidad.Clear(); txtPrecio.Clear();
            if (cmbOrden.Items.Count > 0) cmbOrden.SelectedIndex = 0;
            if (cmbProducto.Items.Count > 0) cmbProducto.SelectedIndex = 0;
            lblTituloForm.Text  = "＋  Nuevo Detalle";
            btnGuardar.Text     = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgv.ClearSelection();
        }

        private void SetCargando(bool v) { btnGuardar.Enabled=!v; btnNuevo.Enabled=!v; btnBuscar.Enabled=!v; btnEliminar.Enabled=!v&&_selectedId!=0; progressBar.Visible=v; Cursor=v?Cursors.WaitCursor:Cursors.Default; }
        private void MostrarError(string m) { lblEstado.Text=$"✘  {m}"; lblEstado.ForeColor=Color.FromArgb(243,139,168); }
        private void MostrarWarning(string m) { lblEstado.Text=$"⚠  {m}"; lblEstado.ForeColor=Color.FromArgb(249,226,175); }
    }
}
