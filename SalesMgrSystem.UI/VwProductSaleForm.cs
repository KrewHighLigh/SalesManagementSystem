using Microsoft.Extensions.DependencyInjection;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.UI
{
    public partial class VwProductSaleForm : Form
    {
        private static VwProductSaleService Servicio() =>
            Program.ServiceProvider.GetRequiredService<VwProductSaleService>();

        public VwProductSaleForm()
        {
            InitializeComponent();
            Load += VwProductSaleForm_Load;
        }

        private async void VwProductSaleForm_Load(object? sender, EventArgs e) =>
            await CargarDatos();

        private async Task CargarDatos()
        {
            try
            {
                SetCargando(true);
                string filtro = txtBuscar.Text.Trim().ToLower();

                var lista = await Servicio().GetList(
                    v => filtro == string.Empty
                      || v.ProductName.ToLower().Contains(filtro)
                      || v.CategoryName.ToLower().Contains(filtro));

                dgvProductSales.DataSource = null;
                dgvProductSales.DataSource = lista;

                lblEstado.Text = $"✔  {lista.Count} registro(s) encontrado(s).";
                lblEstado.ForeColor = Color.FromArgb(166, 227, 161);
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"✘  Error al cargar: {ex.Message}";
                lblEstado.ForeColor = Color.FromArgb(243, 139, 168);
            }
            finally
            {
                SetCargando(false);
            }
        }

        private async void btnBuscar_Click(object? sender, EventArgs e) =>
            await CargarDatos();

        private async void txtBuscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                await CargarDatos();
        }

        private void SetCargando(bool cargando)
        {
            btnBuscar.Enabled = !cargando;
            progressBar.Visible = cargando;
            Cursor = cargando ? Cursors.WaitCursor : Cursors.Default;
        }
    }
}
