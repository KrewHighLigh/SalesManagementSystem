using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Ui.Services;
using System.Linq.Expressions;

namespace SalesMgrSystem.Ui.Forms;

public partial class ProductForm : Form
{
    // ─── Servicios ────────────────────────────────────────────────────────────
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    // ─── Estado interno ───────────────────────────────────────────────────────
    private int _productIdSeleccionado = 0;   // 0 → modo inserción

    // ═════════════════════════════════════════════════════════════════════════
    //  Constructor
    // ═════════════════════════════════════════════════════════════════════════
    public ProductForm(ProductService productService, CategoryService categoryService)
    {
        InitializeComponent();
        _productService = productService;
        _categoryService = categoryService;
    }

    // ═════════════════════════════════════════════════════════════════════════
    //  Carga inicial
    // ═════════════════════════════════════════════════════════════════════════
    private async void frmProductos_Load(object sender, EventArgs e)
    {
        await CargarCategorias();
        ConfigurarDataGridView();
        await CargarProductos();
        LimpiarFormulario();
    }

    // ─── Columnas del DataGridView ────────────────────────────────────────────
    private void ConfigurarDataGridView()
    {
        dgvProductos.AutoGenerateColumns = false;
        if (dgvProductos.Columns.Count > 0) return;

        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colId",
            HeaderText = "ID",
            DataPropertyName = "ProductId",
            Width = 50
        });
        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colNombre",
            HeaderText = "Nombre",
            DataPropertyName = "ProductName",
            Width = 200
        });
        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colPrecio",
            HeaderText = "Precio unitario",
            DataPropertyName = "UnitPrice",
            Width = 110,
            DefaultCellStyle = { Format = "C2" }
        });
        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colStock",
            HeaderText = "Stock",
            DataPropertyName = "StockQuantity",
            Width = 70
        });
        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colCategoria",
            HeaderText = "Categoría",
            DataPropertyName = "CategoryName",
            Width = 150
        });
        dgvProductos.Columns.Add(new DataGridViewCheckBoxColumn
        {
            Name = "colActivo",
            HeaderText = "Activo",
            DataPropertyName = "IsActive",
            Width = 60
        });
    }

    // ═════════════════════════════════════════════════════════════════════════
    //  Carga de datos
    // ═════════════════════════════════════════════════════════════════════════

    private async Task CargarCategorias()
    {
        try
        {
            var categorias = await _categoryService.GetList(c => true);
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "CategoryName";
            cmbCategoria.ValueMember = "CategoryId";
            cmbCategoria.SelectedIndex = -1;
        }
        catch (Exception ex) { MostrarError("Error al cargar categorías", ex); }
    }

    private async Task CargarProductos(string filtro = "")
    {
        try
        {
            Expression<Func<Product, bool>> criterio = string.IsNullOrWhiteSpace(filtro)
                ? p => true
                : p => p.ProductName.Contains(filtro);

            var productos = await _productService.GetListConRelaciones(criterio);

            // Proyección anónima: expone CategoryName como columna plana
            var vista = productos.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.UnitPrice,
                p.StockQuantity,
                p.IsActive,
                CategoryName = p.Category?.CategoryName ?? "—"
            }).ToList();

            dgvProductos.DataSource = vista;
        }
        catch (Exception ex) { MostrarError("Error al cargar productos", ex); }
    }

    // ═════════════════════════════════════════════════════════════════════════
    //  Eventos de controles
    // ═════════════════════════════════════════════════════════════════════════

    private async void txtBuscar_TextChanged(object sender, EventArgs e)
        => await CargarProductos(txtBuscar.Text.Trim());

    private async void dgvProductos_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvProductos.CurrentRow is null) return;

        if (dgvProductos.CurrentRow.Cells["colId"].Value is int id && id != 0)
            await CargarProductoEnFormulario(id);
    }

    // ─── Botones CRUD ─────────────────────────────────────────────────────────

    private void btnNuevo_Click(object sender, EventArgs e)
        => LimpiarFormulario();

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        var producto = ConstruirProductoDesdeFormulario();

        try
        {
            bool ok = await _productService.Guardar(producto);
            if (ok)
            {
                MessageBox.Show(
                    _productIdSeleccionado == 0
                        ? "Producto creado correctamente."
                        : "Producto actualizado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarProductos(txtBuscar.Text.Trim());
                LimpiarFormulario();
            }
            else
                MostrarAviso("No se pudo guardar el producto.");
        }
        catch (Exception ex) { MostrarError("Error al guardar", ex); }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (_productIdSeleccionado == 0)
        {
            MostrarAviso("Seleccione un producto para eliminar.");
            return;
        }

        if (MessageBox.Show(
                $"¿Eliminar el producto \"{txtNombre.Text}\"?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            != DialogResult.Yes) return;

        try
        {
            bool ok = await _productService.Eliminar(_productIdSeleccionado);
            if (ok)
            {
                MessageBox.Show("Producto eliminado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarProductos(txtBuscar.Text.Trim());
                LimpiarFormulario();
            }
            else
                MostrarAviso("No se encontró el producto o ya fue eliminado.");
        }
        catch (Exception ex) { MostrarError("Error al eliminar", ex); }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
        => LimpiarFormulario();

    // ═════════════════════════════════════════════════════════════════════════
    //  Helpers
    // ═════════════════════════════════════════════════════════════════════════

    private async Task CargarProductoEnFormulario(int id)
    {
        var p = await _productService.Buscar(id);
        if (p is null) return;

        _productIdSeleccionado = p.ProductId;
        txtNombre.Text = p.ProductName;
        txtPrecio.Text = p.UnitPrice.ToString("F2");
        txtStock.Text = p.StockQuantity.ToString();
        txtDescripcion.Text = p.Description ?? string.Empty;
        chkActivo.Checked = p.IsActive ?? true;
        cmbCategoria.SelectedValue = p.CategoryId ?? 0;

        ActualizarEstadoBotones(modoEdicion: true);
    }

    private Product ConstruirProductoDesdeFormulario() => new()
    {
        ProductId = _productIdSeleccionado,
        ProductName = txtNombre.Text.Trim(),
        UnitPrice = decimal.Parse(txtPrecio.Text.Trim()),
        StockQuantity = int.Parse(txtStock.Text.Trim()),
        Description = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
        IsActive = chkActivo.Checked,
        CategoryId = cmbCategoria.SelectedValue is int cid ? cid : null
    };

    private bool ValidarFormulario()
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MostrarAviso("El nombre del producto es obligatorio.");
            txtNombre.Focus();
            return false;
        }
        if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0)
        {
            MostrarAviso("Ingrese un precio unitario válido (número positivo).");
            txtPrecio.Focus();
            return false;
        }
        if (!int.TryParse(txtStock.Text.Trim(), out int stock) || stock < 0)
        {
            MostrarAviso("Ingrese un stock válido (entero no negativo).");
            txtStock.Focus();
            return false;
        }
        return true;
    }

    private void LimpiarFormulario()
    {
        _productIdSeleccionado = 0;
        txtNombre.Clear();
        txtPrecio.Clear();
        txtStock.Clear();
        txtDescripcion.Clear();
        chkActivo.Checked = true;
        cmbCategoria.SelectedIndex = -1;
        dgvProductos.ClearSelection();
        ActualizarEstadoBotones(modoEdicion: false);
        txtNombre.Focus();
    }

    private void ActualizarEstadoBotones(bool modoEdicion)
    {
        btnEliminar.Enabled = modoEdicion;
        btnGuardar.Text = modoEdicion ? "💾 Actualizar" : "💾 Guardar";
        lblModo.Text = modoEdicion ? "✏️  Modo edición" : "➕  Nuevo producto";
    }

    private static void MostrarAviso(string msg) =>
        MessageBox.Show(msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    private static void MostrarError(string ctx, Exception ex) =>
        MessageBox.Show($"{ctx}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}