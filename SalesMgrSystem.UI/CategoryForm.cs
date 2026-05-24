using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.UI.Services;

namespace SalesMgrSystem.UI
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryService _service;
        private int  _selectedId = 0;
        private bool _editando   = false;

        public CategoryForm()
        {
            InitializeComponent();

            _service = new CategoryService(new SalesMgrContext());

            _ = CargarCategorias();
        }

        // ─── GetList ──────────────────────────────────────────────────────────
        private async Task CargarCategorias()
        {
            try
            {
                SetCargando(true);
                string filtro = txtBuscar.Text.Trim().ToLower();

                var lista = await _service.GetListConRelaciones(
                    c => filtro == string.Empty
                      || c.CategoryName.ToLower().Contains(filtro)
                      || (c.Description != null && c.Description.ToLower().Contains(filtro)));

                var vista = lista.Select(c => new
                {
                    c.CategoryId,
                    c.CategoryName,
                    Descripcion  = c.Description ?? "—",
                    FechaCreacion = c.CreatedDate.HasValue
                                    ? c.CreatedDate.Value.ToString("dd/MM/yyyy")
                                    : "—",
                    Productos = c.Products.Count
                }).ToList();

                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = vista;

                lblEstado.Text      = $"✔  {vista.Count} categoría(s) encontrada(s).";
                lblEstado.ForeColor = Color.FromArgb(166, 227, 161);
            }
            catch (Exception ex)
            {
                lblEstado.Text      = $"✘  Error al cargar: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        // ─── Guardar (Insert / Update) ────────────────────────────────────────
        private async Task GuardarCategoria()
        {
            if (!Validar()) return;
            try
            {
                SetCargando(true);
                var entidad = new Category
                {
                    CategoryId   = _editando ? _selectedId : 0,
                    CategoryName = txtNombre.Text.Trim(),
                    Description  = string.IsNullOrWhiteSpace(txtDescripcion.Text)
                                    ? null : txtDescripcion.Text.Trim(),
                    CreatedDate  = _editando ? null : DateTime.Now
                };

                bool ok = await _service.Guardar(entidad);
                lblEstado.Text = ok
                    ? (_editando ? "✔  Categoría actualizada." : "✔  Categoría guardada.")
                    : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);

                if (ok) { LimpiarFormulario(); await CargarCategorias(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text      = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        // ─── Eliminar ─────────────────────────────────────────────────────────
        private async Task EliminarCategoria()
        {
            if (_selectedId == 0)
            {
                MessageBox.Show("Selecciona una categoría de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"¿Eliminar \"{txtNombre.Text}\"?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            try
            {
                SetCargando(true);
                bool ok = await _service.Eliminar(_selectedId);
                lblEstado.Text      = ok ? "✔  Categoría eliminada." : "✘  No se encontró.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);
                if (ok) { LimpiarFormulario(); await CargarCategorias(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text      = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        // ─── Eventos ──────────────────────────────────────────────────────────
        private async void btnGuardar_Click(object s, EventArgs e) => await GuardarCategoria();
        private async void btnEliminar_Click(object s, EventArgs e) => await EliminarCategoria();
        private void btnNuevo_Click(object s, EventArgs e)          => LimpiarFormulario();
        private async void btnBuscar_Click(object s, EventArgs e)   => await CargarCategorias();

        private async void txtBuscar_KeyDown(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) await CargarCategorias();
        }

        private async void dgvCategorias_SelectionChanged(object s, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0) return;
            if (dgvCategorias.SelectedRows[0].Cells["CategoryId"].Value is not int id) return;

            var cat = await _service.Buscar(id);
            if (cat == null) return;

            _selectedId        = cat.CategoryId;
            _editando          = true;
            txtNombre.Text     = cat.CategoryName;
            txtDescripcion.Text = cat.Description ?? string.Empty;

            lblTituloForm.Text  = "✏  Editar Categoría";
            btnGuardar.Text     = "💾  Actualizar";
            btnEliminar.Enabled = true;
        }

        // ─── Helpers ──────────────────────────────────────────────────────────
        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblEstado.Text      = "⚠  El nombre es obligatorio.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            _selectedId = 0; _editando = false;
            txtNombre.Clear(); txtDescripcion.Clear();
            lblTituloForm.Text  = "＋  Nueva Categoría";
            btnGuardar.Text     = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgvCategorias.ClearSelection();
            lblEstado.Text      = "Listo.";
            lblEstado.ForeColor = Color.FromArgb(127, 132, 156);
        }

        private void SetCargando(bool v)
        {
            btnGuardar.Enabled  = !v;
            btnNuevo.Enabled    = !v;
            btnBuscar.Enabled   = !v;
            btnEliminar.Enabled = !v && _selectedId != 0;
            progressBar.Visible = v;
            Cursor = v ? Cursors.WaitCursor : Cursors.Default;
        }
    }
}
