namespace SalesMgrSystem.UI
{
    partial class CustomerForm
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            lblCiudad = new Label();
            txtCiudad = new TextBox();
            lblPais = new Label();
            txtPais = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            lblEstado = new Label();
            progressBar = new ProgressBar();
            pnlRight = new Panel();
            pnlBuscar = new Panel();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvClientes = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();

            // ── FORM ───────────────────────────────────────────────────────
            Name = "CustomerForm";
            Text = "Gestión de Clientes";
            ClientSize = new Size(1000, 640);
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 560);
            Font = new Font("Segoe UI", 9.5f);
            BackColor = Color.FromArgb(24, 24, 37);
            ForeColor = Color.FromArgb(205, 214, 244);
            Load += CustomerForm_Load;

            // ── HEADER ─────────────────────────────────────────────────────
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 58;
            pnlHeader.BackColor = Color.FromArgb(30, 30, 46);
            pnlHeader.Padding = new Padding(20, 0, 0, 0);

            lblHeader.AutoSize = false;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Text = "👤  Gestión de Clientes  —  SalesMgrSystem";
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
            lblTituloForm.Text = "＋  Nuevo Cliente";
            lblTituloForm.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.FromArgb(137, 180, 250);

            // Nombre
            lblNombre.Location = new Point(24, 62);
            lblNombre.Size = new Size(272, 18);
            lblNombre.Text = "Nombre *";
            lblNombre.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(166, 173, 200);

            txtNombre.Location = new Point(24, 82);
            txtNombre.Size = new Size(272, 28);
            txtNombre.MaxLength = 100;
            txtNombre.BackColor = Color.FromArgb(49, 50, 68);
            txtNombre.ForeColor = Color.FromArgb(205, 214, 244);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10f);

            // Apellido
            lblApellido.Location = new Point(24, 124);
            lblApellido.Size = new Size(272, 18);
            lblApellido.Text = "Apellido *";
            lblApellido.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(166, 173, 200);

            txtApellido.Location = new Point(24, 144);
            txtApellido.Size = new Size(272, 28);
            txtApellido.MaxLength = 100;
            txtApellido.BackColor = Color.FromArgb(49, 50, 68);
            txtApellido.ForeColor = Color.FromArgb(205, 214, 244);
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Font = new Font("Segoe UI", 10f);

            // Email
            lblEmail.Location = new Point(24, 186);
            lblEmail.Size = new Size(272, 18);
            lblEmail.Text = "Email";
            lblEmail.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(166, 173, 200);

            txtEmail.Location = new Point(24, 206);
            txtEmail.Size = new Size(272, 28);
            txtEmail.MaxLength = 150;
            txtEmail.BackColor = Color.FromArgb(49, 50, 68);
            txtEmail.ForeColor = Color.FromArgb(205, 214, 244);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10f);

            // Teléfono
            lblTelefono.Location = new Point(24, 248);
            lblTelefono.Size = new Size(272, 18);
            lblTelefono.Text = "Teléfono";
            lblTelefono.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblTelefono.ForeColor = Color.FromArgb(166, 173, 200);

            txtTelefono.Location = new Point(24, 268);
            txtTelefono.Size = new Size(272, 28);
            txtTelefono.MaxLength = 20;
            txtTelefono.BackColor = Color.FromArgb(49, 50, 68);
            txtTelefono.ForeColor = Color.FromArgb(205, 214, 244);
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 10f);

            // Dirección
            lblDireccion.Location = new Point(24, 310);
            lblDireccion.Size = new Size(272, 18);
            lblDireccion.Text = "Dirección";
            lblDireccion.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblDireccion.ForeColor = Color.FromArgb(166, 173, 200);

            txtDireccion.Location = new Point(24, 330);
            txtDireccion.Size = new Size(272, 28);
            txtDireccion.MaxLength = 300;
            txtDireccion.BackColor = Color.FromArgb(49, 50, 68);
            txtDireccion.ForeColor = Color.FromArgb(205, 214, 244);
            txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            txtDireccion.Font = new Font("Segoe UI", 10f);

            // Ciudad
            lblCiudad.Location = new Point(24, 372);
            lblCiudad.Size = new Size(130, 18);
            lblCiudad.Text = "Ciudad";
            lblCiudad.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblCiudad.ForeColor = Color.FromArgb(166, 173, 200);

            txtCiudad.Location = new Point(24, 392);
            txtCiudad.Size = new Size(130, 28);
            txtCiudad.MaxLength = 100;
            txtCiudad.BackColor = Color.FromArgb(49, 50, 68);
            txtCiudad.ForeColor = Color.FromArgb(205, 214, 244);
            txtCiudad.BorderStyle = BorderStyle.FixedSingle;
            txtCiudad.Font = new Font("Segoe UI", 10f);

            // País
            lblPais.Location = new Point(166, 372);
            lblPais.Size = new Size(130, 18);
            lblPais.Text = "País";
            lblPais.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblPais.ForeColor = Color.FromArgb(166, 173, 200);

            txtPais.Location = new Point(166, 392);
            txtPais.Size = new Size(130, 28);
            txtPais.MaxLength = 100;
            txtPais.Text = "España";
            txtPais.BackColor = Color.FromArgb(49, 50, 68);
            txtPais.ForeColor = Color.FromArgb(205, 214, 244);
            txtPais.BorderStyle = BorderStyle.FixedSingle;
            txtPais.Font = new Font("Segoe UI", 10f);

            // Botones
            btnNuevo.Location = new Point(24, 436);
            btnNuevo.Size = new Size(80, 36);
            btnNuevo.Text = "🗋  Nuevo";
            btnNuevo.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnNuevo.BackColor = Color.FromArgb(49, 50, 68);
            btnNuevo.ForeColor = Color.FromArgb(205, 214, 244);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(88, 91, 112);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Click += btnNuevo_Click;

            btnGuardar.Location = new Point(114, 436);
            btnGuardar.Size = new Size(96, 36);
            btnGuardar.Text = "💾  Guardar";
            btnGuardar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnGuardar.BackColor = Color.FromArgb(137, 180, 250);
            btnGuardar.ForeColor = Color.FromArgb(30, 30, 46);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Click += btnGuardar_Click;

            btnEliminar.Location = new Point(220, 436);
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

            lblEstado.Location = new Point(24, 488);
            lblEstado.Size = new Size(272, 50);
            lblEstado.Text = "Listo.";
            lblEstado.Font = new Font("Segoe UI", 8.5f);
            lblEstado.ForeColor = Color.FromArgb(127, 132, 156);

            progressBar.Location = new Point(24, 546);
            progressBar.Size = new Size(272, 6);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Visible = false;

            pnlLeft.Controls.Add(lblTituloForm);
            pnlLeft.Controls.Add(lblNombre);
            pnlLeft.Controls.Add(txtNombre);
            pnlLeft.Controls.Add(lblApellido);
            pnlLeft.Controls.Add(txtApellido);
            pnlLeft.Controls.Add(lblEmail);
            pnlLeft.Controls.Add(txtEmail);
            pnlLeft.Controls.Add(lblTelefono);
            pnlLeft.Controls.Add(txtTelefono);
            pnlLeft.Controls.Add(lblDireccion);
            pnlLeft.Controls.Add(txtDireccion);
            pnlLeft.Controls.Add(lblCiudad);
            pnlLeft.Controls.Add(txtCiudad);
            pnlLeft.Controls.Add(lblPais);
            pnlLeft.Controls.Add(txtPais);
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
            txtBuscar.PlaceholderText = "🔍  Buscar por nombre, apellido, email, teléfono...";
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
            dgvClientes.Location = new Point(16, 66);
            dgvClientes.Size = new Size(648, 540);
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Left
                                                | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.BackgroundColor = Color.FromArgb(30, 30, 46);
            dgvClientes.GridColor = Color.FromArgb(60, 60, 85);
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.ColumnHeadersHeight = 38;
            dgvClientes.RowTemplate.Height = 32;
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 50, 68);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(137, 180, 250);
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvClientes.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 46);
            dgvClientes.DefaultCellStyle.ForeColor = Color.FromArgb(205, 214, 244);
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(137, 180, 250);
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 30, 46);
            dgvClientes.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 54);
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;

            pnlRight.Controls.Add(pnlBuscar);
            pnlRight.Controls.Add(dgvClientes);

            // ── Agregar al Form ────────────────────────────────────────────
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);

            pnlHeader.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeader;
        private Panel pnlLeft;
        private Label lblTituloForm;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblDireccion;
        private TextBox txtDireccion;
        private Label lblCiudad;
        private TextBox txtCiudad;
        private Label lblPais;
        private TextBox txtPais;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Label lblEstado;
        private ProgressBar progressBar;
        private Panel pnlRight;
        private Panel pnlBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvClientes;
    }
}
