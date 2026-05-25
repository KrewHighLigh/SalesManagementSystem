using Microsoft.Extensions.DependencyInjection;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.UI
{
    public partial class CustomerForm : Form
    {
        private static CustomerService Servicio() =>
            Program.ServiceProvider.GetRequiredService<CustomerService>();

        private int _selectedId = 0;
        private bool _editando = false;

        public CustomerForm()
        {
            InitializeComponent();
        }

        private async void CustomerForm_Load(object? sender, EventArgs e)
        {
            await CargarClientes();
        }

        private async Task CargarClientes()
        {
            try
            {
                SetCargando(true);
                string filtro = txtBuscar.Text.Trim().ToLower();

                var lista = await Servicio().GetListConRelaciones(
                    c => filtro == string.Empty
                      || c.FirstName.ToLower().Contains(filtro)
                      || c.LastName.ToLower().Contains(filtro)
                      || (c.Email != null && c.Email.ToLower().Contains(filtro))
                      || (c.Phone != null && c.Phone.Contains(filtro))
                      || (c.City != null && c.City.ToLower().Contains(filtro))
                      || (c.Country != null && c.Country.ToLower().Contains(filtro)));

                var vista = lista.Select(c => new
                {
                    c.CustomerId,
                    Nombre = c.FirstName,
                    Apellido = c.LastName,
                    Email = c.Email ?? "—",
                    Teléfono = c.Phone ?? "—",
                    Ciudad = c.City ?? "—",
                    País = c.Country ?? "—",
                    Pedidos = c.Orders.Count
                }).ToList();

                dgvClientes.DataSource = null;
                dgvClientes.DataSource = vista;

                lblEstado.Text = $"✔  {vista.Count} cliente(s) encontrado(s).";
                lblEstado.ForeColor = Color.FromArgb(166, 227, 161);
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async Task GuardarCliente()
        {
            if (!Validar()) return;
            try
            {
                SetCargando(true);
                var entidad = new Customer
                {
                    CustomerId = _editando ? _selectedId : 0,
                    FirstName = txtNombre.Text.Trim(),
                    LastName = txtApellido.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Phone = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                    Address = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim(),
                    City = string.IsNullOrWhiteSpace(txtCiudad.Text) ? null : txtCiudad.Text.Trim(),
                    Country = string.IsNullOrWhiteSpace(txtPais.Text) ? null : txtPais.Text.Trim(),
                    CreatedDate = _editando ? null : DateTime.Now
                };

                bool ok = await Servicio().Guardar(entidad);
                lblEstado.Text = ok
                    ? (_editando ? "✔  Cliente actualizado." : "✔  Cliente guardado.")
                    : "✘  No se pudo guardar.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);

                if (ok) { LimpiarFormulario(); await CargarClientes(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async Task EliminarCliente()
        {
            if (_selectedId == 0)
            {
                MessageBox.Show("Selecciona un cliente de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"¿Eliminar cliente \"{txtNombre.Text} {txtApellido.Text}\"?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            try
            {
                SetCargando(true);
                bool ok = await Servicio().Eliminar(_selectedId);
                lblEstado.Text = ok ? "✔  Cliente eliminado." : "✘  No se encontró.";
                lblEstado.ForeColor = ok
                    ? Color.FromArgb(166, 227, 161)
                    : Color.FromArgb(243, 139, 168);
                if (ok) { LimpiarFormulario(); await CargarClientes(); }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally { SetCargando(false); }
        }

        private async void btnGuardar_Click(object s, EventArgs e) => await GuardarCliente();
        private async void btnEliminar_Click(object s, EventArgs e) => await EliminarCliente();
        private void btnNuevo_Click(object s, EventArgs e) => LimpiarFormulario();
        private async void btnBuscar_Click(object s, EventArgs e) => await CargarClientes();

        private async void txtBuscar_KeyDown(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) await CargarClientes();
        }

        private async void dgvClientes_SelectionChanged(object s, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0) return;
            if (dgvClientes.SelectedRows[0].Cells["CustomerId"].Value is not int id) return;

            var cli = await Servicio().Buscar(id);
            if (cli == null) return;

            _selectedId = cli.CustomerId;
            _editando = true;
            txtNombre.Text = cli.FirstName;
            txtApellido.Text = cli.LastName;
            txtEmail.Text = cli.Email ?? string.Empty;
            txtTelefono.Text = cli.Phone ?? string.Empty;
            txtDireccion.Text = cli.Address ?? string.Empty;
            txtCiudad.Text = cli.City ?? string.Empty;
            txtPais.Text = cli.Country ?? string.Empty;

            lblTituloForm.Text = "✏  Editar Cliente";
            btnGuardar.Text = "💾  Actualizar";
            btnEliminar.Enabled = true;
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblEstado.Text = "⚠  El nombre es obligatorio.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                lblEstado.Text = "⚠  El apellido es obligatorio.";
                lblEstado.ForeColor = Color.FromArgb(249, 226, 175);
                txtApellido.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            _selectedId = 0; _editando = false;
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            txtPais.Text = "España";
            lblTituloForm.Text = "＋  Nuevo Cliente";
            btnGuardar.Text = "💾  Guardar";
            btnEliminar.Enabled = false;
            dgvClientes.ClearSelection();
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
