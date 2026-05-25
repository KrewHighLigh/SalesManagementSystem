namespace SalesMgrSystem.UI
{
    partial class UserForm
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
            DataGridViewTextBoxColumn colId = new();
            DataGridViewTextBoxColumn colUsername = new();
            DataGridViewTextBoxColumn colFullName = new();
            DataGridViewTextBoxColumn colEmail = new();
            DataGridViewTextBoxColumn colRole = new();
            DataGridViewCheckBoxColumn colActive = new();

            pnlHeader = new Panel();
            lblHeader = new Label();
            pnlLeft = new Panel();
            lblTituloForm = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblNombreCompleto = new Label();
            txtNombreCompleto = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            chkActivo = new CheckBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            lblEstado = new Label();
            progressBar = new ProgressBar();
            pnlRight = new Panel();
            pnlBuscar = new Panel();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvUsuarios = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();

            // ── FORM ───────────────────────────────────────────────────────
            Name = "UserForm";
            Text = "Gestión de Usuarios";
            ClientSize = new Size(1000, 640);
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 560);
            Font = new Font("Segoe UI", 9.5f);
            BackColor = Color.FromArgb(24, 24, 37);
            ForeColor = Color.FromArgb(205, 214, 244);

            // ── HEADER ─────────────────────────────────────────────────────
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 58;
            pnlHeader.BackColor = Color.FromArgb(30, 30, 46);
            pnlHeader.Padding = new Padding(20, 0, 0, 0);

            lblHeader.AutoSize = false;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Text = "👤  Gestión de Usuarios  —  SalesMgrSystem";
            lblHeader.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(137, 180, 250);

            pnlHeader.Controls.Add(lblHeader);

            // ── PANEL IZQUIERDO (formulario) ────────────────────────────────
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Width = 320;
            pnlLeft.BackColor = Color.FromArgb(30, 30, 46);
            pnlLeft.Padding = new Padding(24, 20, 24, 20);

            lblTituloForm.Location = new Point(24, 20);
            lblTituloForm.Size = new Size(272, 26);
            lblTituloForm.Text = "＋  Nuevo Usuario";
            lblTituloForm.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.FromArgb(137, 180, 250);

            lblUsername.Location = new Point(24, 62);
            lblUsername.Size = new Size(272, 18);
            lblUsername.Text = "Usuario *";
            lblUsername.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(166, 173, 200);

            txtUsername.Location = new Point(24, 82);
            txtUsername.Size = new Size(272, 28);
            txtUsername.MaxLength = 50;
            txtUsername.BackColor = Color.FromArgb(49, 50, 68);
            txtUsername.ForeColor = Color.FromArgb(205, 214, 244);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 10f);

            lblPassword.Location = new Point(24, 120);
            lblPassword.Size = new Size(272, 18);
            lblPassword.Text = "Contraseña *";
            lblPassword.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(166, 173, 200);

            txtPassword.Location = new Point(24, 140);
            txtPassword.Size = new Size(272, 28);
            txtPassword.MaxLength = 255;
            txtPassword.PasswordChar = '●';
            txtPassword.BackColor = Color.FromArgb(49, 50, 68);
            txtPassword.ForeColor = Color.FromArgb(205, 214, 244);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10f);

            lblNombreCompleto.Location = new Point(24, 178);
            lblNombreCompleto.Size = new Size(272, 18);
            lblNombreCompleto.Text = "Nombre Completo *";
            lblNombreCompleto.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblNombreCompleto.ForeColor = Color.FromArgb(166, 173, 200);

            txtNombreCompleto.Location = new Point(24, 198);
            txtNombreCompleto.Size = new Size(272, 28);
            txtNombreCompleto.MaxLength = 150;
            txtNombreCompleto.BackColor = Color.FromArgb(49, 50, 68);
            txtNombreCompleto.ForeColor = Color.FromArgb(205, 214, 244);
            txtNombreCompleto.BorderStyle = BorderStyle.FixedSingle;
            txtNombreCompleto.Font = new Font("Segoe UI", 10f);

            lblEmail.Location = new Point(24, 236);
            lblEmail.Size = new Size(272, 18);
            lblEmail.Text = "Email";
            lblEmail.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(166, 173, 200);

            txtEmail.Location = new Point(24, 256);
            txtEmail.Size = new Size(272, 28);
            txtEmail.MaxLength = 150;
            txtEmail.BackColor = Color.FromArgb(49, 50, 68);
            txtEmail.ForeColor = Color.FromArgb(205, 214, 244);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10f);

            lblRole.Location = new Point(24, 294);
            lblRole.Size = new Size(272, 18);
            lblRole.Text = "Rol";
            lblRole.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(166, 173, 200);

            cmbRole.Location = new Point(24, 314);
            cmbRole.Size = new Size(272, 28);
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.BackColor = Color.FromArgb(49, 50, 68);
            cmbRole.ForeColor = Color.FromArgb(205, 214, 244);
            cmbRole.Font = new Font("Segoe UI", 10f);
            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.Items.AddRange(new object[] { "Admin", "SalesRep", "Manager" });
            cmbRole.SelectedItem = "SalesRep";

            chkActivo.Location = new Point(24, 356);
            chkActivo.Size = new Size(272, 24);
            chkActivo.Text = "Activo";
            chkActivo.Checked = true;
            chkActivo.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            chkActivo.ForeColor = Color.FromArgb(166, 173, 200);
            chkActivo.BackColor = Color.Transparent;

            // Botones
            btnNuevo.Location = new Point(24, 402);
            btnNuevo.Size = new Size(80, 36);
            btnNuevo.Text = "🗋  Nuevo";
            btnNuevo.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnNuevo.BackColor = Color.FromArgb(49, 50, 68);
            btnNuevo.ForeColor = Color.FromArgb(205, 214, 244);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(88, 91, 112);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Click += btnNuevo_Click;

            btnGuardar.Location = new Point(114, 402);
            btnGuardar.Size = new Size(96, 36);
            btnGuardar.Text = "💾  Guardar";
            btnGuardar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnGuardar.BackColor = Color.FromArgb(137, 180, 250);
            btnGuardar.ForeColor = Color.FromArgb(30, 30, 46);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Click += btnGuardar_Click;

            btnEliminar.Location = new Point(220, 402);
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

            lblEstado.Location = new Point(24, 456);
            lblEstado.Size = new Size(272, 50);
            lblEstado.Text = "Listo.";
            lblEstado.Font = new Font("Segoe UI", 8.5f);
            lblEstado.ForeColor = Color.FromArgb(127, 132, 156);

            progressBar.Location = new Point(24, 520);
            progressBar.Size = new Size(272, 6);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Visible = false;

            pnlLeft.Controls.Add(lblTituloForm);
            pnlLeft.Controls.Add(lblUsername);
            pnlLeft.Controls.Add(txtUsername);
            pnlLeft.Controls.Add(lblPassword);
            pnlLeft.Controls.Add(txtPassword);
            pnlLeft.Controls.Add(lblNombreCompleto);
            pnlLeft.Controls.Add(txtNombreCompleto);
            pnlLeft.Controls.Add(lblEmail);
            pnlLeft.Controls.Add(txtEmail);
            pnlLeft.Controls.Add(lblRole);
            pnlLeft.Controls.Add(cmbRole);
            pnlLeft.Controls.Add(chkActivo);
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
            pnlBuscar.Size = new Size(648, 38);
            pnlBuscar.BackColor = Color.FromArgb(49, 50, 68);
            pnlBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            txtBuscar.Location = new Point(12, 7);
            txtBuscar.Size = new Size(520, 24);
            txtBuscar.BackColor = Color.FromArgb(49, 50, 68);
            txtBuscar.ForeColor = Color.FromArgb(205, 214, 244);
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Segoe UI", 10f);
            txtBuscar.PlaceholderText = "🔍  Buscar por usuario, nombre o email...";
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

            // DataGridView — columnas manuales
            colId.HeaderText = "ID";
            colId.DataPropertyName = "UserId";
            colId.Width = 50;
            colId.ReadOnly = true;

            colUsername.HeaderText = "Usuario";
            colUsername.DataPropertyName = "Username";
            colUsername.Width = 120;
            colUsername.ReadOnly = true;

            colFullName.HeaderText = "Nombre Completo";
            colFullName.DataPropertyName = "FullName";
            colFullName.Width = 160;
            colFullName.ReadOnly = true;

            colEmail.HeaderText = "Email";
            colEmail.DataPropertyName = "Email";
            colEmail.Width = 140;
            colEmail.ReadOnly = true;

            colRole.HeaderText = "Rol";
            colRole.DataPropertyName = "Role";
            colRole.Width = 70;
            colRole.ReadOnly = true;

            colActive.HeaderText = "Activo";
            colActive.DataPropertyName = "IsActive";
            colActive.Width = 55;
            colActive.ReadOnly = true;

            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { colId, colUsername, colFullName, colEmail, colRole, colActive });

            dgvUsuarios.Location = new Point(16, 66);
            dgvUsuarios.Size = new Size(648, 540);
            dgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Left
                                | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.BackgroundColor = Color.FromArgb(30, 30, 46);
            dgvUsuarios.GridColor = Color.FromArgb(60, 60, 85);
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.ColumnHeadersHeight = 38;
            dgvUsuarios.RowTemplate.Height = 32;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 50, 68);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(137, 180, 250);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvUsuarios.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 46);
            dgvUsuarios.DefaultCellStyle.ForeColor = Color.FromArgb(205, 214, 244);
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(137, 180, 250);
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 30, 46);
            dgvUsuarios.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 54);
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;

            pnlRight.Controls.Add(pnlBuscar);
            pnlRight.Controls.Add(dgvUsuarios);

            // ── Agregar al Form ────────────────────────────────────────────
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);

            pnlHeader.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeader;
        private Panel pnlLeft;
        private Label lblTituloForm;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblNombreCompleto;
        private TextBox txtNombreCompleto;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblRole;
        private ComboBox cmbRole;
        private CheckBox chkActivo;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Label lblEstado;
        private ProgressBar progressBar;
        private Panel pnlRight;
        private Panel pnlBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvUsuarios;
    }
}
