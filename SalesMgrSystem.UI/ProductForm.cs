using Microsoft.Extensions.DependencyInjection;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Data.Services;
using SalesMgrSystem.UI;
using System.Linq.Expressions;

namespace SalesMgrSystem.Ui.Forms;

public partial class ProductForm : Form
{
    private int _productIdSeleccionado = 0;
    private bool _ocupado = false;

    private static ProductService NuevoProductService() =>
        Program.ServiceProvider.GetRequiredService<ProductService>();
    private static CategoryService NuevoCategoryService() =>
        Program.ServiceProvider.GetRequiredService<CategoryService>();

    public ProductForm()
    {
        InitializeComponent();
    }


    private async void ProductForm_Load(object sender, EventArgs e)
    {
        // Evitamos que SelectionChanged dispare operaciones durante la carga
        dgvProductos.SelectionChanged -= dgvProductos_SelectionChanged;

        ConfigurarDataGridView();
        await CargarCategorias();
        await CargarProductos();
        LimpiarFormulario();

        dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
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



    private async Task CargarCategorias()
    {
        try
        {
            var categorias = await NuevoCategoryService().GetList(c => true);
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

            var productos = await NuevoProductService().GetListConRelaciones(criterio);

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
    {
        if (_ocupado) return;
        await EjecutarConGuard(() => CargarProductos(txtBuscar.Text.Trim()));
    }

    private async void dgvProductos_SelectionChanged(object? sender, EventArgs e)
    {
        if (_ocupado || dgvProductos.CurrentRow is null) return;

        if (dgvProductos.CurrentRow.Cells["colId"].Value is int id && id != 0)
            await EjecutarConGuard(() => CargarProductoEnFormulario(id));
    }

    // ─── Botones CRUD ─────────────────────────────────────────────────────────

    private void btnNuevo_Click(object sender, EventArgs e)
        => LimpiarFormulario();

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (_ocupado || !ValidarFormulario()) return;

        await EjecutarConGuard(async () =>
        {
            var producto = ConstruirProductoDesdeFormulario();

            // Servicio fresco para guardar
            bool ok = await NuevoProductService().Guardar(producto);

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
        });
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (_ocupado) return;

        if (_productIdSeleccionado == 0)
        {
            MostrarAviso("Seleccione un producto para eliminar.");
            return;
        }

        if (MessageBox.Show(
                $"¿Eliminar el producto \"{txtNombre.Text}\"?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            != DialogResult.Yes) return;

        await EjecutarConGuard(async () =>
        {
            // Servicio fresco para eliminar
            bool ok = await NuevoProductService().Eliminar(_productIdSeleccionado);

            if (ok)
            {
                MessageBox.Show("Producto eliminado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarProductos(txtBuscar.Text.Trim());
                LimpiarFormulario();
            }
            else
                MostrarAviso("No se encontró el producto o ya fue eliminado.");
        });
    }

    private void btnCancelar_Click(object sender, EventArgs e)
        => LimpiarFormulario();

    // ═════════════════════════════════════════════════════════════════════════
    //  Helpers
    // ═════════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Garantiza que ninguna operación async se solape con otra.
    /// Deshabilita controles mientras trabaja y los restaura al terminar.
    /// </summary>
    private async Task EjecutarConGuard(Func<Task> operacion)
    {
        _ocupado = true;
        EstadoBotones(false);
        try
        {
            await operacion();
        }
        catch (Exception ex)
        {
            MostrarError("Error inesperado", ex);
        }
        finally
        {
            _ocupado = false;
            EstadoBotones(true);
        }
    }

    private async Task CargarProductoEnFormulario(int id)
    {
        // Servicio fresco para buscar
        var p = await NuevoProductService().Buscar(id);
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
        Description = string.IsNullOrWhiteSpace(txtDescripcion.Text)
                            ? null : txtDescripcion.Text.Trim(),
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

    private void EstadoBotones(bool habilitado)
    {
        btnNuevo.Enabled = habilitado;
        btnGuardar.Enabled = habilitado;
        btnEliminar.Enabled = habilitado && _productIdSeleccionado != 0;
        btnCancelar.Enabled = habilitado;
        txtBuscar.Enabled = habilitado;
    }

    private static void MostrarAviso(string msg) =>
        MessageBox.Show(msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    private static void MostrarError(string ctx, Exception ex) =>
        MessageBox.Show($"{ctx}:\n{ex.Message}", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
}