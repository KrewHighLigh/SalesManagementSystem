namespace SalesMgrSystem.UI
{
    partial class VwProductSaleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader       = new Panel();
            lblHeader       = new Label();
            pnlMain         = new Panel();
            pnlStatus       = new Panel();
            lblEstado       = new Label();
            progressBar     = new ProgressBar();
            pnlBuscar       = new Panel();
            txtBuscar       = new TextBox();
            btnBuscar       = new Button();
            dgvProductSales = new DataGridView();
            colProductName  = new DataGridViewTextBoxColumn();
            colCategoryName = new DataGridViewTextBoxColumn();
            colTotalSold    = new DataGridViewTextBoxColumn();
            colTotalRevenue = new DataGridViewTextBoxColumn();
            colStock        = new DataGridViewTextBoxColumn();

            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlBuscar.SuspendLayout();
            pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductSales).BeginInit();
            SuspendLayout();

            // ── FORM ───────────────────────────────────────────────────────
            Name            = "VwProductSaleForm";
            Text            = "Consulta de Ventas por Producto";
            ClientSize      = new Size(1100, 640);
            StartPosition   = FormStartPosition.CenterScreen;
            MinimumSize     = new Size(900, 500);
            Font            = new Font("Segoe UI", 9.5f);
            BackColor       = Color.FromArgb(24, 24, 37);
            ForeColor       = Color.FromArgb(205, 214, 244);

            // ── HEADER ─────────────────────────────────────────────────────
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 58;
            pnlHeader.BackColor = Color.FromArgb(30, 30, 46);
            pnlHeader.Padding   = new Padding(20, 0, 0, 0);

            lblHeader.AutoSize  = false;
            lblHeader.Dock      = DockStyle.Fill;
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Text      = "📊  Ventas por Producto  —  SalesMgrSystem";
            lblHeader.Font      = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(137, 180, 250);

            pnlHeader.Controls.Add(lblHeader);

            // ── PANEL PRINCIPAL ────────────────────────────────────────────
            pnlMain.Dock      = DockStyle.Fill;
            pnlMain.BackColor = Color.FromArgb(24, 24, 37);

            // ── BARRA DE BÚSQUEDA ──────────────────────────────────────────
            pnlBuscar.Dock      = DockStyle.Top;
            pnlBuscar.Height    = 50;
            pnlBuscar.BackColor = Color.FromArgb(49, 50, 68);
            pnlBuscar.Padding   = new Padding(16, 0, 16, 0);

            txtBuscar.Location        = new Point(0, 11);
            txtBuscar.Height          = 28;
            txtBuscar.Anchor          = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BackColor       = Color.FromArgb(49, 50, 68);
            txtBuscar.ForeColor       = Color.FromArgb(205, 214, 244);
            txtBuscar.BorderStyle     = BorderStyle.None;
            txtBuscar.Font            = new Font("Segoe UI", 10f);
            txtBuscar.PlaceholderText = "🔍  Buscar por producto o categoría...";
            txtBuscar.KeyDown        += txtBuscar_KeyDown;

            btnBuscar.Location               = new Point(0, 8);
            btnBuscar.Size                   = new Size(88, 30);
            btnBuscar.Anchor                 = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.Text                   = "Buscar";
            btnBuscar.Font                   = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnBuscar.BackColor              = Color.FromArgb(137, 180, 250);
            btnBuscar.ForeColor              = Color.FromArgb(30, 30, 46);
            btnBuscar.FlatStyle              = FlatStyle.Flat;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.Cursor                 = Cursors.Hand;
            btnBuscar.Click                 += btnBuscar_Click;

            pnlBuscar.Controls.Add(txtBuscar);
            pnlBuscar.Controls.Add(btnBuscar);

            // ── TABLA ──────────────────────────────────────────────────────
            dgvProductSales.Dock                        = DockStyle.Fill;
            dgvProductSales.AutoGenerateColumns          = false;
            dgvProductSales.SelectionMode                = DataGridViewSelectionMode.FullRowSelect;
            dgvProductSales.MultiSelect                  = false;
            dgvProductSales.ReadOnly                     = true;
            dgvProductSales.AllowUserToAddRows           = false;
            dgvProductSales.AllowUserToDeleteRows        = false;
            dgvProductSales.RowHeadersVisible            = false;
            dgvProductSales.BackgroundColor              = Color.FromArgb(30, 30, 46);
            dgvProductSales.GridColor                    = Color.FromArgb(60, 60, 85);
            dgvProductSales.BorderStyle                  = BorderStyle.None;
            dgvProductSales.ColumnHeadersHeight          = 38;
            dgvProductSales.RowTemplate.Height           = 32;
            dgvProductSales.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(49, 50, 68);
            dgvProductSales.ColumnHeadersDefaultCellStyle.ForeColor  = Color.FromArgb(137, 180, 250);
            dgvProductSales.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvProductSales.DefaultCellStyle.BackColor               = Color.FromArgb(30, 30, 46);
            dgvProductSales.DefaultCellStyle.ForeColor               = Color.FromArgb(205, 214, 244);
            dgvProductSales.DefaultCellStyle.SelectionBackColor      = Color.FromArgb(137, 180, 250);
            dgvProductSales.DefaultCellStyle.SelectionForeColor      = Color.FromArgb(30, 30, 46);
            dgvProductSales.DefaultCellStyle.Font                    = new Font("Segoe UI", 9f);
            dgvProductSales.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 54);

            // ── COLUMNAS ──────────────────────────────────────────────────
            colProductName.Name             = "ProductName";
            colProductName.HeaderText       = "Producto";
            colProductName.DataPropertyName = "ProductName";
            colProductName.Width            = 220;
            colProductName.MinimumWidth     = 120;

            colCategoryName.Name             = "CategoryName";
            colCategoryName.HeaderText       = "Categoría";
            colCategoryName.DataPropertyName = "CategoryName";
            colCategoryName.Width            = 160;
            colCategoryName.MinimumWidth     = 100;

            colTotalSold.Name                 = "TotalSold";
            colTotalSold.HeaderText           = "Total Vendido";
            colTotalSold.DataPropertyName     = "TotalSold";
            colTotalSold.Width                = 140;
            colTotalSold.MinimumWidth         = 80;
            colTotalSold.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            colTotalRevenue.Name                 = "TotalRevenue";
            colTotalRevenue.HeaderText           = "Ingresos Totales";
            colTotalRevenue.DataPropertyName     = "TotalRevenue";
            colTotalRevenue.Width                = 160;
            colTotalRevenue.MinimumWidth         = 100;
            colTotalRevenue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTotalRevenue.DefaultCellStyle.Format    = "N2";

            colStock.Name                 = "StockQuantity";
            colStock.HeaderText           = "Stock";
            colStock.DataPropertyName     = "StockQuantity";
            colStock.Width                = 100;
            colStock.MinimumWidth         = 60;
            colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvProductSales.Columns.Add(colProductName);
            dgvProductSales.Columns.Add(colCategoryName);
            dgvProductSales.Columns.Add(colTotalSold);
            dgvProductSales.Columns.Add(colTotalRevenue);
            dgvProductSales.Columns.Add(colStock);

            // ── BARRA DE ESTADO ────────────────────────────────────────────
            pnlStatus.Dock      = DockStyle.Bottom;
            pnlStatus.Height    = 36;
            pnlStatus.BackColor = Color.FromArgb(30, 30, 46);
            pnlStatus.Padding   = new Padding(16, 0, 16, 0);

            lblEstado.Location  = new Point(0, 8);
            lblEstado.Size      = new Size(500, 22);
            lblEstado.Text      = "Listo.";
            lblEstado.Font      = new Font("Segoe UI", 8.5f);
            lblEstado.ForeColor = Color.FromArgb(127, 132, 156);

            progressBar.Location       = new Point(0, 14);
            progressBar.Size           = new Size(200, 6);
            progressBar.Style          = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Visible        = false;

            pnlStatus.Controls.Add(lblEstado);
            pnlStatus.Controls.Add(progressBar);

            // ── ENSAMBLAR ──────────────────────────────────────────────────
            pnlMain.Controls.Add(dgvProductSales);
            pnlMain.Controls.Add(pnlBuscar);
            pnlMain.Controls.Add(pnlStatus);

            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);

            // ── RESUMEN ────────────────────────────────────────────────────
            pnlHeader.ResumeLayout(false);
            pnlBuscar.ResumeLayout(false);
            pnlBuscar.PerformLayout();
            pnlStatus.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductSales).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel   pnlHeader;
        private Label   lblHeader;
        private Panel   pnlMain;
        private Panel   pnlBuscar;
        private TextBox txtBuscar;
        private Button  btnBuscar;
        private DataGridView dgvProductSales;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colCategoryName;
        private DataGridViewTextBoxColumn colTotalSold;
        private DataGridViewTextBoxColumn colTotalRevenue;
        private DataGridViewTextBoxColumn colStock;
        private Panel   pnlStatus;
        private Label   lblEstado;
        private ProgressBar progressBar;
    }
}
