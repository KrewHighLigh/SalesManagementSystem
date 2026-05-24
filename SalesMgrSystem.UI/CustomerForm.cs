using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.UI.Services;

namespace SalesMgrSystem.UI
{
    public partial class CustomerForm : Form
    {
        private readonly CustomerService _service;
        private int  _selectedId = 0;
        private bool _editando   = false;

        public CustomerForm()
        {
            InitializeComponent();
            _service = new CustomerService(new SalesMgrContext());
            _ = Cargar();
        }

        private async Task Cargar()
        {
            try
            {
                SetCargando(true);
                string f = txtBuscar.Text.Trim().ToLower();
                var lista = await _service.GetListConRelaciones(
                    c => f == string.Empty
                      || c.FirstName.ToLower().Contains(f)
                      || c.LastName.ToLower().Contains(f)
                      || (c.Email != null && c.Email.ToLower().Contains(f)));

                var vista = lista.Select(c => new {
                    c.CustomerId,
                    Nombre   = c.FirstName + " " + c.LastName,
                    c.Email,
                    Telefono = c.Phone   ?? "—",
                    Ciudad   = c.City    ?? "—",
                    Pais     = c.Country ?? "—",
                    Ordenes  = c.Orders.Count
                }).ToList();

                dgv.DataSource = null;
                dgv.DataSource = vista;
                lblEstado.Text      = $"✔  {vista.Count} cliente(s) encontrado(s).";
                lblEstado.ForeColor = Color.FromArgb(166, 227, 161);
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Guardar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            { MostrarWarning("Nombre y apellido son obligatorios."); return; }

            try
            {
                SetCargando(true);
                var e = new Customer {
                    CustomerId = _editando ? _selectedId : 0,
                    FirstName  = txtNombre.Text.Trim(),
                    LastName   = txtApellido.Text.Trim(),
                    Email      = Nulo(txtEmail.Text),
                    Phone      = Nulo(txtTelefono.Text),
                    Address    = Nulo(txtDireccion.Text),
                    City       = Nulo(txtCiudad.Text),
                    Country    = Nulo(txtPais.Text),
                    CreatedDate = _editando ? null : DateTime.Now
                };
                bool ok = await _service.Guardar(e);
                lblEstado.Text      = ok ? (_editando ? "✔  Cliente actualizado." : "✔  Cliente guardado.") : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok ? Color.FromArgb(166,227,161) : Color.FromArgb(243,139,168);
                if (ok) { Limpiar(); await Cargar(); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Eliminar()
        {
            if (_selectedId == 0) { MessageBox.Show("Selecciona un cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"¿Eliminar a {txtNombre.Text} {txtApellido.Text}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                SetCargando(true);
                bool ok = await _service.Eliminar(_selectedId);
                lblEstado.Text      = ok ? "✔  Cliente eliminado." : "✘  No encontrado.";
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
            if (dgv.SelectedRows[0].Cells["CustomerId"].Value is not int id) return;
            var c = await _service.Buscar(id);
            if (c == null) return;
            _selectedId = c.CustomerId; _editando = true;
            txtNombre.Text    = c.FirstName;
            txtApellido.Text  = c.LastName;
            txtEmail.Text     = c.Email     ?? string.Empty;
            txtTelefono.Text  = c.Phone     ?? string.Empty;
            txtDireccion.Text = c.Address   ?? string.Empty;
            txtCiudad.Text    = c.City      ?? string.Empty;
            txtPais.Text      = c.Country   ?? string.Empty;
            lblTituloForm.Text = "✏  Editar Cliente";
            btnGuardar.Text    = "💾  Actualizar";
            btnEliminar.Enabled = true;
        }

        private void Limpiar()
        {
            _selectedId = 0; _editando = false;
            txtNombre.Clear(); txtApellido.Clear(); txtEmail.Clear();
            txtTelefono.Clear(); txtDireccion.Clear(); txtCiudad.Clear(); txtPais.Clear();
            lblTituloForm.Text = "＋  Nuevo Cliente";
            btnGuardar.Text    = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgv.ClearSelection();
        }

        private void SetCargando(bool v) { btnGuardar.Enabled = !v; btnNuevo.Enabled = !v; btnBuscar.Enabled = !v; btnEliminar.Enabled = !v && _selectedId != 0; progressBar.Visible = v; Cursor = v ? Cursors.WaitCursor : Cursors.Default; }
        private void MostrarError(string msg) { lblEstado.Text = $"✘  {msg}"; lblEstado.ForeColor = Color.FromArgb(243,139,168); }
        private void MostrarWarning(string msg) { lblEstado.Text = $"⚠  {msg}"; lblEstado.ForeColor = Color.FromArgb(249,226,175); }
        private static string? Nulo(string s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();
    }
}
