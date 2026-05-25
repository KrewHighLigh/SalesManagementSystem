using Microsoft.Extensions.DependencyInjection;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.UI
{
    public partial class VwSalesSummaryForm : Form
    {
        private static VwSalesSummaryService Servicio() =>
            Program.ServiceProvider.GetRequiredService<VwSalesSummaryService>();

        public VwSalesSummaryForm()
        {
            InitializeComponent();
        }

        private async void VwSalesSummaryForm_Load(object sender, EventArgs e)
        {
            await CargarDatos();
        }

        private async Task CargarDatos(string? filtro = null)
        {
            try
            {
                progressBar.Visible = true;

                List<VwSalesSummary> lista;

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    lista = await Servicio().GetList(v => true);
                }
                else
                {
                    var f = filtro.Trim().ToLower();
                    lista = await Servicio().GetList(v =>
                        v.OrderId.ToString().Contains(f) ||
                        v.CustomerName.ToLower().Contains(f) ||
                        v.SalesRep.ToLower().Contains(f) ||
                        (v.Status != null && v.Status.ToLower().Contains(f)));
                }

                dgvResumen.DataSource = null;
                dgvResumen.DataSource = lista;

                lblEstado.Text = $"{lista.Count} registro(s) encontrado(s).";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        private async void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await CargarDatos(txtBuscar.Text);
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await CargarDatos(txtBuscar.Text);
        }

        private void dgvResumen_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvResumen.Columns.Count == 0) return;

            if (dgvResumen.Columns.Contains("OrderId"))
                dgvResumen.Columns["OrderId"]!.HeaderText = "Orden #";

            if (dgvResumen.Columns.Contains("CustomerName"))
                dgvResumen.Columns["CustomerName"]!.HeaderText = "Cliente";

            if (dgvResumen.Columns.Contains("SalesRep"))
                dgvResumen.Columns["SalesRep"]!.HeaderText = "Vendedor";

            if (dgvResumen.Columns.Contains("OrderDate"))
            {
                dgvResumen.Columns["OrderDate"]!.HeaderText = "Fecha";
                dgvResumen.Columns["OrderDate"]!.DefaultCellStyle.Format = "d";
            }

            if (dgvResumen.Columns.Contains("TotalAmount"))
            {
                dgvResumen.Columns["TotalAmount"]!.HeaderText = "Total";
                dgvResumen.Columns["TotalAmount"]!.DefaultCellStyle.Format = "C2";
            }

            if (dgvResumen.Columns.Contains("Status"))
                dgvResumen.Columns["Status"]!.HeaderText = "Estado";

            if (dgvResumen.Columns.Contains("ItemsCount"))
                dgvResumen.Columns["ItemsCount"]!.HeaderText = "Artículos";
        }
    }
}
