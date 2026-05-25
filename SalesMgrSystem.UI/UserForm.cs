using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.UI
{
    public partial class UserForm : Form
    {
        private static UserService Servicio() =>
            Program.ServiceProvider.GetRequiredService<UserService>();

        private int _selectedId = 0;
        private bool _editando = false;
        private DateTime? _createdDateOriginal;

        public UserForm()
        {
            InitializeComponent();
            this.Load += UserForm_Load;
        }

        private async void UserForm_Load(object? sender, EventArgs e)
        {
            await CargarUsuarios();
        }

        private static string HashPassword(string password)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes).ToLower();
        }

        private async Task CargarUsuarios()
        {
            try
            {
                SetCargando(true);
                string filtro = txtBuscar.Text.Trim().ToLower();

                var lista = await Servicio().GetList(
                    u => filtro == string.Empty
                      || u.Username.ToLower().Contains(filtro)
                      || u.FullName.ToLower().Contains(filtro)
                      || (u.Email != null && u.Email.ToLower().Contains(filtro)));

                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = lista;

                lblEstado.Text = $"✔  {lista.Count} usuario(s) encontrado(s).";
                lblEstado.ForeColor = Color.FromArgb(166, 227, 161);
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async Task GuardarUsuario()
        {
            if (!Validar()) return;
            try
            {
                SetCargando(true);

                var entidad = new User
                {
                    UserId = _editando ? _selectedId : 0,
                    Username = txtUsername.Text.Trim(),
                    FullName = txtNombreCompleto.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text)
                            ? null : txtEmail.Text.Trim(),
                    Role = cmbRole.SelectedItem?.ToString(),
                    IsActive = chkActivo.Checked,
                    CreatedDate = _editando ? _createdDateOriginal : DateTime.Now
                };

                if (_editando)
                {
                    if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        var existing = await Servicio().Buscar(_selectedId);
                        if (existing == null)
                        {
                            lblEstado.Text = "✘  Usuario no encontrado.";
                            lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
                            return;
                        }
                        entidad.PasswordHash = existing.PasswordHash;
                    }
                    else
                    {
                        entidad.PasswordHash = HashPassword(txtPassword.Text);
                    }
                }
                else
                {
                    entidad.PasswordHash = HashPassword(txtPassword.Text);
                }

                bool ok = await Servicio().Guardar(entidad);
                lblEstado.Text = ok
                    ? (_editando ? "✔  Usuario actualizado." : "✔  Usuario guardado.")
                    : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);

                if (ok) { LimpiarFormulario(); await CargarUsuarios(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async Task EliminarUsuario()
        {
            if (_selectedId == 0)
            {
                MessageBox.Show("Selecciona un usuario de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"¿Eliminar \"{txtUsername.Text}\"?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            try
            {
                SetCargando(true);
                bool ok = await Servicio().Eliminar(_selectedId);
                lblEstado.Text = ok ? "✔  Usuario eliminado." : "✘  No se encontró.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);
                if (ok) { LimpiarFormulario(); await CargarUsuarios(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async void btnGuardar_Click(object s, EventArgs e) => await GuardarUsuario();
        private async void btnEliminar_Click(object s, EventArgs e) => await EliminarUsuario();
        private void btnNuevo_Click(object s, EventArgs e) => LimpiarFormulario();
        private async void btnBuscar_Click(object s, EventArgs e) => await CargarUsuarios();

        private async void txtBuscar_KeyDown(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) await CargarUsuarios();
        }

        private async void dgvUsuarios_SelectionChanged(object s, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count == 0) return;
                if (dgvUsuarios.SelectedRows[0].Cells["UserId"].Value is not int id) return;

                var user = await Servicio().Buscar(id);
                if (user == null) return;

                _selectedId = id;
                _editando = true;
                _createdDateOriginal = user.CreatedDate;
                txtUsername.Text = user.Username;
                txtPassword.Clear();
                txtNombreCompleto.Text = user.FullName;
                txtEmail.Text = user.Email ?? string.Empty;
                cmbRole.SelectedItem = user.Role ?? "SalesRep";
                chkActivo.Checked = user.IsActive ?? true;

                lblTituloForm.Text = "✏  Editar Usuario";
                btnGuardar.Text = "💾  Actualizar";
                btnEliminar.Enabled = true;
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar usuario: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblEstado.Text = "⚠  El usuario es obligatorio.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                lblEstado.Text = "⚠  El nombre completo es obligatorio.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                txtNombreCompleto.Focus();
                return false;
            }
            if (!_editando && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblEstado.Text = "⚠  La contraseña es obligatoria.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            _selectedId = 0; _editando = false;
            txtUsername.Clear();
            txtPassword.Clear();
            txtNombreCompleto.Clear();
            txtEmail.Clear();
            cmbRole.SelectedItem = "SalesRep";
            chkActivo.Checked = true;
            lblTituloForm.Text = "＋  Nuevo Usuario";
            btnGuardar.Text = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgvUsuarios.ClearSelection();
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
