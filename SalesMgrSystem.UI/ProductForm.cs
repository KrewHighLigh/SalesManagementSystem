using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.UI.Services;

namespace SalesMgrSystem.UI
{
    public partial class ProductForm : Form
    {
        private readonly ProductService  _service;
        private readonly CategoryService _catService;
        private int  _selectedId = 0;
        private bool _editando   = false;

        public ProductForm()
        {
            InitializeComponent();
            var ctx = new SalesMgrContext();
            _service    = new ProductService(ctx);
            _catService = new CategoryService(ctx);
            _ = CargarCategorias();
            _ = Cargar();
        }

        private async Task CargarCategorias()
        {
            var cats = await _catService.GetList(c => true);
            cmbCategoria.DataSource    = cats;
            cmbCategoria.DisplayMember = "CategoryName";
            cmbCategoria.ValueMember   = "CategoryId";
        }

        private async Task Cargar()
        {
            try
            {
                SetCargando(true);
                string f = txtBuscar.Text.Trim().ToLower();
                var lista = await _service.GetListConRelaciones(
                    p => f == string.Empty
                      || p.ProductName.ToLower().Contains(f)
                      || (p.Description != null && p.Description.ToLower().Contains(f)));

                var vista = lista.Select(p => new {
                    p.ProductId,
                    p.ProductName,
                    Categoria  = p.Category?.CategoryName ?? "—",
                    Precio     = p.UnitPrice,
                    Stock      = p.StockQuantity,
                    Activo     = p.IsActive == true ? "Sí" : "No"
                }).ToList();

                dgv.DataSource = null;
                dgv.DataSource = vista;
                lblEstado.Text      = $"✔  {vista.Count} producto(s).";
                lblEstado.ForeColor = Color.FromArgb(166,227,161);
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Guardar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MostrarWarning("El nombre es obligatorio."); return; }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio)) { MostrarWarning("Precio inválido."); return; }
            if (!int.TryParse(txtStock.Text, out int stock)) { MostrarWarning("Stock inválido."); return; }

            try
            {
                SetCargando(true);
                var e = new Product {
                    ProductId    = _editando ? _selectedId : 0,
                    ProductName  = txtNombre.Text.Trim(),
                    CategoryId   = cmbCategoria.SelectedValue as int?,
                    UnitPrice    = precio,
                    StockQuantity = stock,
                    Description  = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
                    IsActive     = chkActivo.Checked,
                    CreatedDate  = _editando ? null : DateTime.Now
                };
                bool ok = await _service.Guardar(e);
                lblEstado.Text      = ok ? (_editando ? "✔  Producto actualizado." : "✔  Producto guardado.") : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok ? Color.FromArgb(166,227,161) : Color.FromArgb(243,139,168);
                if (ok) { Limpiar(); await Cargar(); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Eliminar()
        {
            if (_selectedId == 0) { MessageBox.Show("Selecciona un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"¿Eliminar \"{txtNombre.Text}\"?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                SetCargando(true);
                bool ok = await _service.Eliminar(_selectedId);
                lblEstado.Text      = ok ? "✔  Producto eliminado." : "✘  No encontrado.";
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
            if (dgv.SelectedRows[0].Cells["ProductId"].Value is not int id) return;
            var p = await _service.Buscar(id);
            if (p == null) return;
            _selectedId = p.ProductId; _editando = true;
            txtNombre.Text      = p.ProductName;
            txtPrecio.Text      = p.UnitPrice.ToString("F2");
            txtStock.Text       = p.StockQuantity.ToString();
            txtDescripcion.Text = p.Description ?? string.Empty;
            chkActivo.Checked   = p.IsActive ?? true;
            if (p.CategoryId.HasValue) cmbCategoria.SelectedValue = p.CategoryId.Value;
            lblTituloForm.Text  = "✏  Editar Producto";
            btnGuardar.Text     = "💾  Actualizar";
            btnEliminar.Enabled = true;
        }

        private void Limpiar()
        {
            _selectedId = 0; _editando = false;
            txtNombre.Clear(); txtPrecio.Clear(); txtStock.Clear(); txtDescripcion.Clear();
            chkActivo.Checked = true;
            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
            lblTituloForm.Text  = "＋  Nuevo Producto";
            btnGuardar.Text     = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgv.ClearSelection();
        }

        private void SetCargando(bool v) { btnGuardar.Enabled=!v; btnNuevo.Enabled=!v; btnBuscar.Enabled=!v; btnEliminar.Enabled=!v&&_selectedId!=0; progressBar.Visible=v; Cursor=v?Cursors.WaitCursor:Cursors.Default; }
        private void MostrarError(string m) { lblEstado.Text=$"✘  {m}"; lblEstado.ForeColor=Color.FromArgb(243,139,168); }
        private void MostrarWarning(string m) { lblEstado.Text=$"⚠  {m}"; lblEstado.ForeColor=Color.FromArgb(249,226,175); }
    }
}
