namespace SalesMgrSystem.UI
{
    partial class OrderForm
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
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            lblUsuario = new Label();
            cmbUsuario = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblStatus = new Label();
            cmbEstado = new ComboBox();
            lblTotal = new Label();
            txtTotal = new TextBox();
            lblNotas = new Label();
            txtNotas = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            lblEstado = new Label();
            progressBar = new ProgressBar();
            pnlRight = new Panel();
            pnlBuscar = new Panel();
            txtSearch = new TextBox();
            btnBuscar = new Button();
            dgvOrdenes = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
            SuspendLayout();

            // ── FORM ───────────────────────────────────────────────────────
            Name = "OrderForm";
            Text = "Gestión de Órdenes";
            ClientSize = new Size(1000, 640);
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 560);
            Font = new Font("Segoe UI", 9.5f);
            BackColor = Color.FromArgb(24, 24, 37);
            ForeColor = Color.FromArgb(205, 214, 244);
            Load += OrderForm_Load;

            // ── HEADER ─────────────────────────────────────────────────────
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 58;
            pnlHeader.BackColor = Color.FromArgb(30, 30, 46);
            pnlHeader.Padding = new Padding(20, 0, 0, 0);

            lblHeader.AutoSize = false;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Text = "📦  Gestión de Órdenes  —  SalesMgrSystem";
            lblHeader.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(137, 180, 250);

            pnlHeader.Controls.Add(lblHeader);

            // ── PANEL IZQUIERDO (formulario) ────────────────────────────────
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Width = 340;
            pnlLeft.BackColor = Color.FromArgb(30, 30, 46);
            pnlLeft.Padding = new Padding(24, 20, 24, 20);

            lblTituloForm.Location = new Point(24, 20);
            lblTituloForm.Size = new Size(292, 26);
            lblTituloForm.Text = "＋  Nueva Orden";
            lblTituloForm.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.FromArgb(137, 180, 250);

            // Cliente
            lblCliente.Location = new Point(24, 56);
            lblCliente.Size = new Size(292, 18);
            lblCliente.Text = "Cliente *";
            lblCliente.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblCliente.ForeColor = Color.FromArgb(166, 173, 200);

            cmbCliente.Location = new Point(24, 76);
            cmbCliente.Size = new Size(292, 28);
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.BackColor = Color.FromArgb(49, 50, 68);
            cmbCliente.ForeColor = Color.FromArgb(205, 214, 244);
            cmbCliente.FlatStyle = FlatStyle.Flat;
            cmbCliente.Font = new Font("Segoe UI", 10f);

            // Usuario / Vendedor
            lblUsuario.Location = new Point(24, 114);
            lblUsuario.Size = new Size(292, 18);
            lblUsuario.Text = "Vendedor *";
            lblUsuario.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(166, 173, 200);

            cmbUsuario.Location = new Point(24, 134);
            cmbUsuario.Size = new Size(292, 28);
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.BackColor = Color.FromArgb(49, 50, 68);
            cmbUsuario.ForeColor = Color.FromArgb(205, 214, 244);
            cmbUsuario.FlatStyle = FlatStyle.Flat;
            cmbUsuario.Font = new Font("Segoe UI", 10f);

            // Fecha
            lblFecha.Location = new Point(24, 172);
            lblFecha.Size = new Size(292, 18);
            lblFecha.Text = "Fecha de Orden";
            lblFecha.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblFecha.ForeColor = Color.FromArgb(166, 173, 200);

            dtpFecha.Location = new Point(24, 192);
            dtpFecha.Size = new Size(292, 28);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Value = DateTime.Now;
            dtpFecha.BackColor = Color.FromArgb(49, 50, 68);
            dtpFecha.ForeColor = Color.FromArgb(205, 214, 244);
            dtpFecha.Font = new Font("Segoe UI", 10f);

            // Estado
            lblStatus.Location = new Point(24, 230);
            lblStatus.Size = new Size(292, 18);
            lblStatus.Text = "Estado *";
            lblStatus.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(166, 173, 200);

            cmbEstado.Location = new Point(24, 250);
            cmbEstado.Size = new Size(292, 28);
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.BackColor = Color.FromArgb(49, 50, 68);
            cmbEstado.ForeColor = Color.FromArgb(205, 214, 244);
            cmbEstado.FlatStyle = FlatStyle.Flat;
            cmbEstado.Font = new Font("Segoe UI", 10f);
            cmbEstado.Items.AddRange(new object[] {
                "Pending", "Processing", "Shipped", "Delivered", "Cancelled"
            });

            // Total
            lblTotal.Location = new Point(24, 288);
            lblTotal.Size = new Size(292, 18);
            lblTotal.Text = "Total";
            lblTotal.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(166, 173, 200);

            txtTotal.Location = new Point(24, 308);
            txtTotal.Size = new Size(292, 28);
            txtTotal.Text = "0.00";
            txtTotal.ReadOnly = true;
            txtTotal.BackColor = Color.FromArgb(49, 50, 68);
            txtTotal.ForeColor = Color.FromArgb(166, 227, 161);
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            txtTotal.TextAlign = HorizontalAlignment.Right;

            // Notas
            lblNotas.Location = new Point(24, 346);
            lblNotas.Size = new Size(292, 18);
            lblNotas.Text = "Notas";
            lblNotas.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblNotas.ForeColor = Color.FromArgb(166, 173, 200);

            txtNotas.Location = new Point(24, 366);
            txtNotas.Size = new Size(292, 60);
            txtNotas.Multiline = true;
            txtNotas.MaxLength = 500;
            txtNotas.ScrollBars = ScrollBars.Vertical;
            txtNotas.BackColor = Color.FromArgb(49, 50, 68);
            txtNotas.ForeColor = Color.FromArgb(205, 214, 244);
            txtNotas.BorderStyle = BorderStyle.FixedSingle;
            txtNotas.Font = new Font("Segoe UI", 9.5f);

            // Botones
            btnNuevo.Location = new Point(24, 446);
            btnNuevo.Size = new Size(80, 36);
            btnNuevo.Text = "🗋  Nuevo";
            btnNuevo.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnNuevo.BackColor = Color.FromArgb(49, 50, 68);
            btnNuevo.ForeColor = Color.FromArgb(205, 214, 244);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(88, 91, 112);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Click += btnNuevo_Click;

            btnGuardar.Location = new Point(114, 446);
            btnGuardar.Size = new Size(96, 36);
            btnGuardar.Text = "💾  Guardar";
            btnGuardar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnGuardar.BackColor = Color.FromArgb(137, 180, 250);
            btnGuardar.ForeColor = Color.FromArgb(30, 30, 46);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Click += btnGuardar_Click;

            btnEliminar.Location = new Point(220, 446);
            btnEliminar.Size = new Size(96, 36);
            btnEliminar.Text = "🗑  Borrar";
            btnEliminar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnEliminar.BackColor = Color.FromArgb(243, 139, 168);
            btnEliminar.ForeColor = Color.FromArgb(30, 30, 46);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Enabled = false;
            btnEliminar.Click += btnEliminar_Click;

            lblEstado.Location = new Point(24, 498);
            lblEstado.Size = new Size(292, 20);
            lblEstado.Text = "Listo.";
            lblEstado.Font = new Font("Segoe UI", 8.5f);
            lblEstado.ForeColor = Color.FromArgb(127, 132, 156);

            progressBar.Location = new Point(24, 530);
            progressBar.Size = new Size(292, 6);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Visible = false;

            pnlLeft.Controls.Add(lblTituloForm);
            pnlLeft.Controls.Add(lblCliente);
            pnlLeft.Controls.Add(cmbCliente);
            pnlLeft.Controls.Add(lblUsuario);
            pnlLeft.Controls.Add(cmbUsuario);
            pnlLeft.Controls.Add(lblFecha);
            pnlLeft.Controls.Add(dtpFecha);
            pnlLeft.Controls.Add(lblStatus);
            pnlLeft.Controls.Add(cmbEstado);
            pnlLeft.Controls.Add(lblTotal);
            pnlLeft.Controls.Add(txtTotal);
            pnlLeft.Controls.Add(lblNotas);
            pnlLeft.Controls.Add(txtNotas);
            pnlLeft.Controls.Add(btnNuevo);
            pnlLeft.Controls.Add(btnGuardar);
            pnlLeft.Controls.Add(btnEliminar);
            pnlLeft.Controls.Add(lblEstado);
            pnlLeft.Controls.Add(progressBar);

            // ── PANEL DERECHO (lista) ───────────────────────────────────────
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.BackColor = Color.FromArgb(24, 24, 37);
            pnlRight.Padding = new Padding(16, 16, 16, 16);

            pnlBuscar.Location = new Point(16, 16);
            pnlBuscar.Size = new Size(628, 38);
            pnlBuscar.BackColor = Color.FromArgb(49, 50, 68);
            pnlBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            txtSearch.Location = new Point(12, 7);
            txtSearch.Size = new Size(500, 24);
            txtSearch.BackColor = Color.FromArgb(49, 50, 68);
            txtSearch.ForeColor = Color.FromArgb(205, 214, 244);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10f);
            txtSearch.PlaceholderText = "🔍  Buscar por ID, cliente o estado...";
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.KeyDown += txtSearch_KeyDown;

            btnBuscar.Location = new Point(530, 4);
            btnBuscar.Size = new Size(88, 30);
            btnBuscar.Text = "Buscar";
            btnBuscar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnBuscar.BackColor = Color.FromArgb(137, 180, 250);
            btnBuscar.ForeColor = Color.FromArgb(30, 30, 46);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.Click += btnBuscar_Click;

            pnlBuscar.Controls.Add(txtSearch);
            pnlBuscar.Controls.Add(btnBuscar);

            // DataGridView
            dgvOrdenes.Location = new Point(16, 66);
            dgvOrdenes.Size = new Size(628, 540);
            dgvOrdenes.Anchor = AnchorStyles.Top | AnchorStyles.Left
                                | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvOrdenes.AutoGenerateColumns = false;
            dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenes.MultiSelect = false;
            dgvOrdenes.ReadOnly = true;
            dgvOrdenes.AllowUserToAddRows = false;
            dgvOrdenes.RowHeadersVisible = false;
            dgvOrdenes.BackgroundColor = Color.FromArgb(30, 30, 46);
            dgvOrdenes.GridColor = Color.FromArgb(60, 60, 85);
            dgvOrdenes.BorderStyle = BorderStyle.None;
            dgvOrdenes.ColumnHeadersHeight = 38;
            dgvOrdenes.RowTemplate.Height = 32;
            dgvOrdenes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 50, 68);
            dgvOrdenes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(137, 180, 250);
            dgvOrdenes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvOrdenes.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 46);
            dgvOrdenes.DefaultCellStyle.ForeColor = Color.FromArgb(205, 214, 244);
            dgvOrdenes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(137, 180, 250);
            dgvOrdenes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 30, 46);
            dgvOrdenes.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgvOrdenes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 54);
            dgvOrdenes.SelectionChanged += dgvOrdenes_SelectionChanged;

            // ── Columnas ─────────────────────────────────────────────────────
            DataGridViewTextBoxColumn colOrderId = new DataGridViewTextBoxColumn();
            colOrderId.Name = "OrderId";
            colOrderId.DataPropertyName = "OrderId";
            colOrderId.HeaderText = "ID";
            colOrderId.Width = 60;
            colOrderId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn colCliente = new DataGridViewTextBoxColumn();
            colCliente.Name = "Cliente";
            colCliente.DataPropertyName = "Cliente";
            colCliente.HeaderText = "Cliente";
            colCliente.Width = 150;
            colCliente.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
            colUsuario.Name = "Usuario";
            colUsuario.DataPropertyName = "Usuario";
            colUsuario.HeaderText = "Vendedor";
            colUsuario.Width = 120;

            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
            colFecha.Name = "Fecha";
            colFecha.DataPropertyName = "Fecha";
            colFecha.HeaderText = "Fecha";
            colFecha.Width = 90;
            colFecha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "TotalAmount";
            colTotal.DataPropertyName = "TotalAmount";
            colTotal.HeaderText = "Total";
            colTotal.Width = 100;
            colTotal.DefaultCellStyle.Format = "C2";
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "Status";
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Estado";
            colStatus.Width = 90;
            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrdenes.Columns.AddRange(new DataGridViewColumn[] {
                colOrderId, colCliente, colUsuario, colFecha, colTotal, colStatus
            });

            pnlRight.Controls.Add(pnlBuscar);
            pnlRight.Controls.Add(dgvOrdenes);

            // ── Agregar al Form ────────────────────────────────────────────
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);

            pnlHeader.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeader;
        private Panel pnlLeft;
        private Label lblTituloForm;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Label lblUsuario;
        private ComboBox cmbUsuario;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblStatus;
        private ComboBox cmbEstado;
        private Label lblTotal;
        private TextBox txtTotal;
        private Label lblNotas;
        private TextBox txtNotas;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Label lblEstado;
        private ProgressBar progressBar;
        private Panel pnlRight;
        private Panel pnlBuscar;
        private TextBox txtSearch;
        private Button btnBuscar;
        private DataGridView dgvOrdenes;
    }
}
