namespace SalesMgrSystem.UI
{
    partial class PaymentForm
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
            pnlHeader = new Panel();
            lblHeader = new Label();
            pnlLeft = new Panel();
            lblTituloForm = new Label();
            lblOrden = new Label();
            cmbOrden = new ComboBox();
            lblMonto = new Label();
            txtMonto = new TextBox();
            lblMetodo = new Label();
            cmbMetodo = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblNotas = new Label();
            txtNotas = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            lblEstado = new Label();
            progressBar = new ProgressBar();
            pnlRight = new Panel();
            pnlBuscar = new Panel();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvPagos = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            SuspendLayout();

            // ── FORM ───────────────────────────────────────────────────────
            Name = "PaymentForm";
            Text = "Gestión de Pagos";
            ClientSize = new Size(1000, 640);
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 560);
            Font = new Font("Segoe UI", 9.5f);
            BackColor = Color.FromArgb(24, 24, 37);
            ForeColor = Color.FromArgb(205, 214, 244);
            Load += PaymentForm_Load;

            // ── HEADER ─────────────────────────────────────────────────────
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 58;
            pnlHeader.BackColor = Color.FromArgb(30, 30, 46);
            pnlHeader.Padding = new Padding(20, 0, 0, 0);

            lblHeader.AutoSize = false;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Text = "💳  Gestión de Pagos  —  SalesMgrSystem";
            lblHeader.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(137, 180, 250);

            pnlHeader.Controls.Add(lblHeader);

            // ── PANEL IZQUIERDO (formulario) ──────────────────────────────
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Width = 320;
            pnlLeft.BackColor = Color.FromArgb(30, 30, 46);
            pnlLeft.Padding = new Padding(24, 20, 24, 20);

            lblTituloForm.Location = new Point(24, 20);
            lblTituloForm.Size = new Size(272, 26);
            lblTituloForm.Text = "＋  Nuevo Pago";
            lblTituloForm.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.FromArgb(137, 180, 250);

            lblOrden.Location = new Point(24, 62);
            lblOrden.Size = new Size(272, 18);
            lblOrden.Text = "Orden *";
            lblOrden.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblOrden.ForeColor = Color.FromArgb(166, 173, 200);

            cmbOrden.Location = new Point(24, 82);
            cmbOrden.Size = new Size(272, 28);
            cmbOrden.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrden.BackColor = Color.FromArgb(49, 50, 68);
            cmbOrden.ForeColor = Color.FromArgb(205, 214, 244);
            cmbOrden.FlatStyle = FlatStyle.Flat;
            cmbOrden.Font = new Font("Segoe UI", 10f);

            lblMonto.Location = new Point(24, 124);
            lblMonto.Size = new Size(272, 18);
            lblMonto.Text = "Monto *";
            lblMonto.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblMonto.ForeColor = Color.FromArgb(166, 173, 200);

            txtMonto.Location = new Point(24, 144);
            txtMonto.Size = new Size(272, 28);
            txtMonto.MaxLength = 18;
            txtMonto.BackColor = Color.FromArgb(49, 50, 68);
            txtMonto.ForeColor = Color.FromArgb(205, 214, 244);
            txtMonto.BorderStyle = BorderStyle.FixedSingle;
            txtMonto.Font = new Font("Segoe UI", 10f);

            lblMetodo.Location = new Point(24, 186);
            lblMetodo.Size = new Size(272, 18);
            lblMetodo.Text = "Método de Pago *";
            lblMetodo.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblMetodo.ForeColor = Color.FromArgb(166, 173, 200);

            cmbMetodo.Location = new Point(24, 206);
            cmbMetodo.Size = new Size(272, 28);
            cmbMetodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodo.BackColor = Color.FromArgb(49, 50, 68);
            cmbMetodo.ForeColor = Color.FromArgb(205, 214, 244);
            cmbMetodo.FlatStyle = FlatStyle.Flat;
            cmbMetodo.Font = new Font("Segoe UI", 10f);
            cmbMetodo.Items.AddRange(new object[] {
                "Cash", "Credit Card", "Debit Card", "Transfer", "Check"
            });

            lblFecha.Location = new Point(24, 248);
            lblFecha.Size = new Size(272, 18);
            lblFecha.Text = "Fecha de Pago";
            lblFecha.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblFecha.ForeColor = Color.FromArgb(166, 173, 200);

            dtpFecha.Location = new Point(24, 268);
            dtpFecha.Size = new Size(272, 28);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.BackColor = Color.FromArgb(49, 50, 68);
            dtpFecha.ForeColor = Color.FromArgb(205, 214, 244);
            dtpFecha.Font = new Font("Segoe UI", 10f);

            lblNotas.Location = new Point(24, 310);
            lblNotas.Size = new Size(272, 18);
            lblNotas.Text = "Notas";
            lblNotas.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblNotas.ForeColor = Color.FromArgb(166, 173, 200);

            txtNotas.Location = new Point(24, 330);
            txtNotas.Size = new Size(272, 60);
            txtNotas.Multiline = true;
            txtNotas.MaxLength = 200;
            txtNotas.ScrollBars = ScrollBars.Vertical;
            txtNotas.BackColor = Color.FromArgb(49, 50, 68);
            txtNotas.ForeColor = Color.FromArgb(205, 214, 244);
            txtNotas.BorderStyle = BorderStyle.FixedSingle;
            txtNotas.Font = new Font("Segoe UI", 9.5f);

            // Botones
            btnNuevo.Location = new Point(24, 408);
            btnNuevo.Size = new Size(80, 36);
            btnNuevo.Text = "🗋  Nuevo";
            btnNuevo.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnNuevo.BackColor = Color.FromArgb(49, 50, 68);
            btnNuevo.ForeColor = Color.FromArgb(205, 214, 244);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(88, 91, 112);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Click += btnNuevo_Click;

            btnGuardar.Location = new Point(114, 408);
            btnGuardar.Size = new Size(96, 36);
            btnGuardar.Text = "💾  Guardar";
            btnGuardar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnGuardar.BackColor = Color.FromArgb(137, 180, 250);
            btnGuardar.ForeColor = Color.FromArgb(30, 30, 46);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Click += btnGuardar_Click;

            btnEliminar.Location = new Point(220, 408);
            btnEliminar.Size = new Size(76, 36);
            btnEliminar.Text = "🗑  Borrar";
            btnEliminar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnEliminar.BackColor = Color.FromArgb(243, 139, 168);
            btnEliminar.ForeColor = Color.FromArgb(30, 30, 46);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Enabled = false;
            btnEliminar.Click += btnEliminar_Click;

            lblEstado.Location = new Point(24, 460);
            lblEstado.Size = new Size(272, 50);
            lblEstado.Text = "Listo.";
            lblEstado.Font = new Font("Segoe UI", 8.5f);
            lblEstado.ForeColor = Color.FromArgb(127, 132, 156);

            progressBar.Location = new Point(24, 518);
            progressBar.Size = new Size(272, 6);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Visible = false;

            pnlLeft.Controls.Add(lblTituloForm);
            pnlLeft.Controls.Add(lblOrden);
            pnlLeft.Controls.Add(cmbOrden);
            pnlLeft.Controls.Add(lblMonto);
            pnlLeft.Controls.Add(txtMonto);
            pnlLeft.Controls.Add(lblMetodo);
            pnlLeft.Controls.Add(cmbMetodo);
            pnlLeft.Controls.Add(lblFecha);
            pnlLeft.Controls.Add(dtpFecha);
            pnlLeft.Controls.Add(lblNotas);
            pnlLeft.Controls.Add(txtNotas);
            pnlLeft.Controls.Add(btnNuevo);
            pnlLeft.Controls.Add(btnGuardar);
            pnlLeft.Controls.Add(btnEliminar);
            pnlLeft.Controls.Add(lblEstado);
            pnlLeft.Controls.Add(progressBar);

            // ── PANEL DERECHO (lista) ─────────────────────────────────────
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.BackColor = Color.FromArgb(24, 24, 37);
            pnlRight.Padding = new Padding(16, 16, 16, 16);

            pnlBuscar.Location = new Point(16, 16);
            pnlBuscar.Size = new Size(648, 38);
            pnlBuscar.BackColor = Color.FromArgb(49, 50, 68);
            pnlBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            txtBuscar.Location = new Point(12, 7);
            txtBuscar.Size = new Size(520, 24);
            txtBuscar.BackColor = Color.FromArgb(49, 50, 68);
            txtBuscar.ForeColor = Color.FromArgb(205, 214, 244);
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Segoe UI", 10f);
            txtBuscar.PlaceholderText = "🔍  Buscar por OrderID o método de pago...";
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            btnBuscar.Location = new Point(550, 4);
            btnBuscar.Size = new Size(88, 30);
            btnBuscar.Text = "Buscar";
            btnBuscar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnBuscar.BackColor = Color.FromArgb(137, 180, 250);
            btnBuscar.ForeColor = Color.FromArgb(30, 30, 46);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Click += btnBuscar_Click;

            pnlBuscar.Controls.Add(txtBuscar);
            pnlBuscar.Controls.Add(btnBuscar);

            // DataGridView
            dgvPagos.Location = new Point(16, 66);
            dgvPagos.Size = new Size(648, 540);
            dgvPagos.Anchor = AnchorStyles.Top | AnchorStyles.Left
                            | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvPagos.AutoGenerateColumns = false;
            dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagos.MultiSelect = false;
            dgvPagos.ReadOnly = true;
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.RowHeadersVisible = false;
            dgvPagos.BackgroundColor = Color.FromArgb(30, 30, 46);
            dgvPagos.GridColor = Color.FromArgb(60, 60, 85);
            dgvPagos.BorderStyle = BorderStyle.None;
            dgvPagos.ColumnHeadersHeight = 38;
            dgvPagos.RowTemplate.Height = 32;
            dgvPagos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 50, 68);
            dgvPagos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(137, 180, 250);
            dgvPagos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvPagos.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 46);
            dgvPagos.DefaultCellStyle.ForeColor = Color.FromArgb(205, 214, 244);
            dgvPagos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(137, 180, 250);
            dgvPagos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 30, 46);
            dgvPagos.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgvPagos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 54);
            dgvPagos.SelectionChanged += dgvPagos_SelectionChanged;

            // Columns
            dgvPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PaymentId",
                HeaderText = "ID",
                DataPropertyName = "PaymentId",
                Width = 50
            });
            dgvPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OrderId",
                HeaderText = "OrderID",
                DataPropertyName = "OrderId",
                Width = 70
            });
            dgvPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Monto",
                HeaderText = "Monto",
                DataPropertyName = "Monto",
                Width = 100
            });
            dgvPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PaymentMethod",
                HeaderText = "Método",
                DataPropertyName = "PaymentMethod",
                Width = 110
            });
            dgvPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                Width = 100
            });
            dgvPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Notes",
                HeaderText = "Notas",
                DataPropertyName = "Notes",
                Width = 180
            });

            pnlRight.Controls.Add(pnlBuscar);
            pnlRight.Controls.Add(dgvPagos);

            // ── Agregar al Form ──────────────────────────────────────────
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);

            pnlHeader.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeader;
        private Panel pnlLeft;
        private Label lblTituloForm;
        private Label lblOrden;
        private ComboBox cmbOrden;
        private Label lblMonto;
        private TextBox txtMonto;
        private Label lblMetodo;
        private ComboBox cmbMetodo;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblNotas;
        private TextBox txtNotas;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Label lblEstado;
        private ProgressBar progressBar;
        private Panel pnlRight;
        private Panel pnlBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvPagos;
    }
}
