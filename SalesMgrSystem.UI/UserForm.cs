using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.UI.Services;

namespace SalesMgrSystem.UI
{
    public partial class UserForm : Form
    {
        private readonly UserService _service;
        private int  _selectedId = 0;
        private bool _editando   = false;

        public UserForm()
        {
            InitializeComponent();
            _service = new UserService(new SalesMgrContext());
            _ = Cargar();
        }

        private async Task Cargar()
        {
            try
            {
                SetCargando(true);
                string f = txtBuscar.Text.Trim().ToLower();
                var lista = await _service.GetList(
                    u => f == string.Empty
                      || u.Username.ToLower().Contains(f)
                      || u.FullName.ToLower().Contains(f)
                      || (u.Email != null && u.Email.ToLower().Contains(f)));

                var vista = lista.Select(u => new {
                    u.UserId,
                    u.Username,
                    u.FullName,
                    u.Email,
                    u.Role,
                    Activo = u.IsActive == true ? "Sí" : "No"
                }).ToList();

                dgv.DataSource = null;
                dgv.DataSource = vista;
                lblEstado.Text      = $"✔  {vista.Count} usuario(s).";
                lblEstado.ForeColor = Color.FromArgb(166,227,161);
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Guardar()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            { MostrarWarning("Username y nombre completo son obligatorios."); return; }
            if (!_editando && string.IsNullOrWhiteSpace(txtPassword.Text))
            { MostrarWarning("La contraseña es obligatoria."); return; }

            try
            {
                SetCargando(true);
                var e = new User {
                    UserId       = _editando ? _selectedId : 0,
                    Username     = txtUsername.Text.Trim(),
                    PasswordHash = string.IsNullOrWhiteSpace(txtPassword.Text) ? "***" : txtPassword.Text.Trim(),
                    FullName     = txtFullName.Text.Trim(),
                    Email        = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Role         = cmbRole.Text,
                    IsActive     = chkActivo.Checked,
                    CreatedDate  = _editando ? null : DateTime.Now
                };
                bool ok = await _service.Guardar(e);
                lblEstado.Text      = ok ? (_editando ? "✔  Usuario actualizado." : "✔  Usuario guardado.") : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok ? Color.FromArgb(166,227,161) : Color.FromArgb(243,139,168);
                if (ok) { Limpiar(); await Cargar(); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
            finally { SetCargando(false); }
        }

        private async Task Eliminar()
        {
            if (_selectedId == 0) { MessageBox.Show("Selecciona un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"¿Eliminar a {txtUsername.Text}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                SetCargando(true);
                bool ok = await _service.Eliminar(_selectedId);
                lblEstado.Text      = ok ? "✔  Usuario eliminado." : "✘  No encontrado.";
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
            if (dgv.SelectedRows[0].Cells["UserId"].Value is not int id) return;
            var u = await _service.Buscar(id);
            if (u == null) return;
            _selectedId = u.UserId; _editando = true;
            txtUsername.Text = u.Username; txtFullName.Text = u.FullName;
            txtEmail.Text    = u.Email ?? string.Empty; txtPassword.Text = string.Empty;
            cmbRole.Text     = u.Role ?? "SalesRep"; chkActivo.Checked = u.IsActive ?? true;
            lblTituloForm.Text  = "✏  Editar Usuario";
            btnGuardar.Text     = "💾  Actualizar";
            btnEliminar.Enabled = true;
        }

        private void Limpiar()
        {
            _selectedId = 0; _editando = false;
            txtUsername.Clear(); txtFullName.Clear(); txtEmail.Clear(); txtPassword.Clear();
            cmbRole.SelectedIndex = 0; chkActivo.Checked = true;
            lblTituloForm.Text  = "＋  Nuevo Usuario";
            btnGuardar.Text     = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgv.ClearSelection();
        }

        private void SetCargando(bool v) { btnGuardar.Enabled=!v; btnNuevo.Enabled=!v; btnBuscar.Enabled=!v; btnEliminar.Enabled=!v&&_selectedId!=0; progressBar.Visible=v; Cursor=v?Cursors.WaitCursor:Cursors.Default; }
        private void MostrarError(string m) { lblEstado.Text=$"✘  {m}"; lblEstado.ForeColor=Color.FromArgb(243,139,168); }
        private void MostrarWarning(string m) { lblEstado.Text=$"⚠  {m}"; lblEstado.ForeColor=Color.FromArgb(249,226,175); }
    }
}
