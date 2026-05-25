namespace SalesMgrSystem.UI
{
    partial class VwSalesSummaryForm
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
            pnlBuscar       = new Panel();
            txtBuscar       = new TextBox();
            btnBuscar       = new Button();
            dgvResumen      = new DataGridView();
            progressBar     = new ProgressBar();
            lblEstado       = new Label();

            pnlHeader.SuspendLayout();
            pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).BeginInit();
            SuspendLayout();

            // ── FORM ───────────────────────────────────────────────────────
            Name            = "VwSalesSummaryForm";
            Text            = "Resumen de Ventas";
            ClientSize      = new Size(1100, 640);
            StartPosition   = FormStartPosition.CenterScreen;
            MinimumSize     = new Size(800, 560);
            Font            = new Font("Segoe UI", 9.5f);
            BackColor       = Color.FromArgb(24, 24, 37);
            ForeColor       = Color.FromArgb(205, 214, 244);
            Load           += VwSalesSummaryForm_Load;

            // ── HEADER ─────────────────────────────────────────────────────
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 58;
            pnlHeader.BackColor = Color.FromArgb(30, 30, 46);
            pnlHeader.Padding   = new Padding(20, 0, 0, 0);

            lblHeader.AutoSize  = false;
            lblHeader.Dock      = DockStyle.Fill;
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Text      = "📊  Resumen de Ventas  —  SalesMgrSystem";
            lblHeader.Font      = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(137, 180, 250);

            pnlHeader.Controls.Add(lblHeader);

            // ── SEARCH BAR ──────────────────────────────────────────────────
            pnlBuscar.Location  = new Point(16, 74);
            pnlBuscar.Size      = new Size(1068, 38);
            pnlBuscar.BackColor = Color.FromArgb(49, 50, 68);
            pnlBuscar.Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            txtBuscar.Location       = new Point(12, 7);
            txtBuscar.Size           = new Size(920, 24);
            txtBuscar.BackColor      = Color.FromArgb(49, 50, 68);
            txtBuscar.ForeColor      = Color.FromArgb(205, 214, 244);
            txtBuscar.BorderStyle    = BorderStyle.None;
            txtBuscar.Font           = new Font("Segoe UI", 10f);
            txtBuscar.PlaceholderText = "🔍  Buscar por orden, cliente, vendedor o estado...";
            txtBuscar.Anchor         = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.KeyDown       += txtBuscar_KeyDown;

            btnBuscar.Location  = new Point(948, 4);
            btnBuscar.Size      = new Size(106, 30);
            btnBuscar.Text      = "Buscar";
            btnBuscar.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnBuscar.BackColor = Color.FromArgb(137, 180, 250);
            btnBuscar.ForeColor = Color.FromArgb(30, 30, 46);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.Cursor    = Cursors.Hand;
            btnBuscar.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.Click    += btnBuscar_Click;

            pnlBuscar.Controls.Add(txtBuscar);
            pnlBuscar.Controls.Add(btnBuscar);

            // ── DATAGRIDVIEW ────────────────────────────────────────────────
            dgvResumen.Location              = new Point(16, 124);
            dgvResumen.Size                  = new Size(1068, 478);
            dgvResumen.Anchor                = AnchorStyles.Top | AnchorStyles.Left
                                              | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvResumen.AutoGenerateColumns   = true;
            dgvResumen.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgvResumen.MultiSelect           = false;
            dgvResumen.ReadOnly              = true;
            dgvResumen.AllowUserToAddRows    = false;
            dgvResumen.AllowUserToDeleteRows = false;
            dgvResumen.RowHeadersVisible     = false;
            dgvResumen.BackgroundColor       = Color.FromArgb(30, 30, 46);
            dgvResumen.GridColor             = Color.FromArgb(60, 60, 85);
            dgvResumen.BorderStyle           = BorderStyle.None;
            dgvResumen.ColumnHeadersHeight   = 38;
            dgvResumen.RowTemplate.Height    = 32;
            dgvResumen.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(49, 50, 68);
            dgvResumen.ColumnHeadersDefaultCellStyle.ForeColor  = Color.FromArgb(137, 180, 250);
            dgvResumen.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvResumen.DefaultCellStyle.BackColor               = Color.FromArgb(30, 30, 46);
            dgvResumen.DefaultCellStyle.ForeColor               = Color.FromArgb(205, 214, 244);
            dgvResumen.DefaultCellStyle.SelectionBackColor      = Color.FromArgb(137, 180, 250);
            dgvResumen.DefaultCellStyle.SelectionForeColor      = Color.FromArgb(30, 30, 46);
            dgvResumen.DefaultCellStyle.Font                    = new Font("Segoe UI", 9f);
            dgvResumen.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 54);
            dgvResumen.DataBindingComplete += dgvResumen_DataBindingComplete;

            // ── PROGRESS BAR ───────────────────────────────────────────────
            progressBar.Location = new Point(16, 610);
            progressBar.Size     = new Size(1068, 6);
            progressBar.Style    = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Visible  = false;
            progressBar.Anchor   = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // ── STATUS LABEL ───────────────────────────────────────────────
            lblEstado.Location  = new Point(16, 620);
            lblEstado.Size      = new Size(1068, 18);
            lblEstado.Text      = "Listo.";
            lblEstado.Font      = new Font("Segoe UI", 8.5f);
            lblEstado.ForeColor = Color.FromArgb(127, 132, 156);
            lblEstado.Anchor    = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // ── Agregar al Form ────────────────────────────────────────────
            Controls.Add(pnlHeader);
            Controls.Add(pnlBuscar);
            Controls.Add(dgvResumen);
            Controls.Add(progressBar);
            Controls.Add(lblEstado);

            pnlHeader.ResumeLayout(false);
            pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResumen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel           pnlHeader;
        private Label           lblHeader;
        private Panel           pnlBuscar;
        private TextBox         txtBuscar;
        private Button          btnBuscar;
        private DataGridView    dgvResumen;
        private ProgressBar     progressBar;
        private Label           lblEstado;
    }
}
