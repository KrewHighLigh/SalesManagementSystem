namespace SalesMgrSystem.UI
{
    partial class OrderDetailForm
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
            lblProducto = new Label();
            cmbProducto = new ComboBox();
            lblCantidad = new Label();
            txtCantidad = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblSubtotal = new Label();
            txtSubtotal = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            lblEstado = new Label();
            progressBar = new ProgressBar();
            pnlRight = new Panel();
            pnlBuscar = new Panel();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvDetalles = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();

            // ── FORM ───────────────────────────────────────────────────────
            Name = "OrderDetailForm";
            Text = "Gestión de Detalles de Órdenes";
            ClientSize = new Size(1000, 640);
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(900, 560);
            Font = new Font("Segoe UI", 9.5f);
            BackColor = Color.FromArgb(24, 24, 37);
            ForeColor = Color.FromArgb(205, 214, 244);
            Load += OrderDetailForm_Load;

            // ── HEADER ─────────────────────────────────────────────────────
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 58;
            pnlHeader.BackColor = Color.FromArgb(30, 30, 46);
            pnlHeader.Padding = new Padding(20, 0, 0, 0);

            lblHeader.AutoSize = false;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Text = "📋  Gestión de Detalles de Órdenes  —  SalesMgrSystem";
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
            lblTituloForm.Text = "＋  Nuevo Detalle";
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
            cmbOrden.DisplayMember = "OrderId";
            cmbOrden.ValueMember = "OrderId";

            lblProducto.Location = new Point(24, 124);
            lblProducto.Size = new Size(272, 18);
            lblProducto.Text = "Producto *";
            lblProducto.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblProducto.ForeColor = Color.FromArgb(166, 173, 200);

            cmbProducto.Location = new Point(24, 144);
            cmbProducto.Size = new Size(272, 28);
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.BackColor = Color.FromArgb(49, 50, 68);
            cmbProducto.ForeColor = Color.FromArgb(205, 214, 244);
            cmbProducto.FlatStyle = FlatStyle.Flat;
            cmbProducto.Font = new Font("Segoe UI", 10f);
            cmbProducto.DisplayMember = "ProductName";
            cmbProducto.ValueMember = "ProductId";
            cmbProducto.SelectedIndexChanged += CmbProducto_SelectedIndexChanged;

            lblCantidad.Location = new Point(24, 186);
            lblCantidad.Size = new Size(272, 18);
            lblCantidad.Text = "Cantidad *";
            lblCantidad.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblCantidad.ForeColor = Color.FromArgb(166, 173, 200);

            txtCantidad.Location = new Point(24, 206);
            txtCantidad.Size = new Size(272, 28);
            txtCantidad.MaxLength = 10;
            txtCantidad.BackColor = Color.FromArgb(49, 50, 68);
            txtCantidad.ForeColor = Color.FromArgb(205, 214, 244);
            txtCantidad.BorderStyle = BorderStyle.FixedSingle;
            txtCantidad.Font = new Font("Segoe UI", 10f);
            txtCantidad.TextChanged += TxtCantidad_TextChanged;

            lblPrecio.Location = new Point(24, 248);
            lblPrecio.Size = new Size(272, 18);
            lblPrecio.Text = "Precio Unit.";
            lblPrecio.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblPrecio.ForeColor = Color.FromArgb(166, 173, 200);

            txtPrecio.Location = new Point(24, 268);
            txtPrecio.Size = new Size(272, 28);
            txtPrecio.BackColor = Color.FromArgb(49, 50, 68);
            txtPrecio.ForeColor = Color.FromArgb(205, 214, 244);
            txtPrecio.BorderStyle = BorderStyle.FixedSingle;
            txtPrecio.Font = new Font("Segoe UI", 10f);
            txtPrecio.ReadOnly = true;
            txtPrecio.TextChanged += TxtPrecio_TextChanged;

            lblSubtotal.Location = new Point(24, 310);
            lblSubtotal.Size = new Size(272, 18);
            lblSubtotal.Text = "Subtotal";
            lblSubtotal.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblSubtotal.ForeColor = Color.FromArgb(166, 173, 200);

            txtSubtotal.Location = new Point(24, 330);
            txtSubtotal.Size = new Size(272, 28);
            txtSubtotal.BackColor = Color.FromArgb(49, 50, 68);
            txtSubtotal.ForeColor = Color.FromArgb(166, 227, 161);
            txtSubtotal.BorderStyle = BorderStyle.FixedSingle;
            txtSubtotal.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Text = "0.00";

            // Botones
            btnNuevo.Location = new Point(24, 376);
            btnNuevo.Size = new Size(80, 36);
            btnNuevo.Text = "🗋  Nuevo";
            btnNuevo.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnNuevo.BackColor = Color.FromArgb(49, 50, 68);
            btnNuevo.ForeColor = Color.FromArgb(205, 214, 244);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(88, 91, 112);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Click += BtnNuevo_Click;

            btnGuardar.Location = new Point(114, 376);
            btnGuardar.Size = new Size(96, 36);
            btnGuardar.Text = "💾  Guardar";
            btnGuardar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnGuardar.BackColor = Color.FromArgb(137, 180, 250);
            btnGuardar.ForeColor = Color.FromArgb(30, 30, 46);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Click += BtnGuardar_Click;

            btnEliminar.Location = new Point(220, 376);
            btnEliminar.Size = new Size(76, 36);
            btnEliminar.Text = "🗑  Borrar";
            btnEliminar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnEliminar.BackColor = Color.FromArgb(243, 139, 168);
            btnEliminar.ForeColor = Color.FromArgb(30, 30, 46);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Enabled = false;
            btnEliminar.Click += BtnEliminar_Click;

            lblEstado.Location = new Point(24, 428);
            lblEstado.Size = new Size(272, 50);
            lblEstado.Text = "Listo.";
            lblEstado.Font = new Font("Segoe UI", 8.5f);
            lblEstado.ForeColor = Color.FromArgb(127, 132, 156);

            progressBar.Location = new Point(24, 486);
            progressBar.Size = new Size(272, 6);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Visible = false;

            pnlLeft.Controls.Add(lblTituloForm);
            pnlLeft.Controls.Add(lblOrden);
            pnlLeft.Controls.Add(cmbOrden);
            pnlLeft.Controls.Add(lblProducto);
            pnlLeft.Controls.Add(cmbProducto);
            pnlLeft.Controls.Add(lblCantidad);
            pnlLeft.Controls.Add(txtCantidad);
            pnlLeft.Controls.Add(lblPrecio);
            pnlLeft.Controls.Add(txtPrecio);
            pnlLeft.Controls.Add(lblSubtotal);
            pnlLeft.Controls.Add(txtSubtotal);
            pnlLeft.Controls.Add(btnNuevo);
            pnlLeft.Controls.Add(btnGuardar);
            pnlLeft.Controls.Add(btnEliminar);
            pnlLeft.Controls.Add(lblEstado);
            pnlLeft.Controls.Add(progressBar);

            // ── PANEL DERECHO (lista) ────────────────────────────────────────
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
            txtBuscar.PlaceholderText = "🔍  Buscar por # de orden o nombre del producto...";
            txtBuscar.KeyDown += TxtBuscar_KeyDown;

            btnBuscar.Location = new Point(550, 4);
            btnBuscar.Size = new Size(88, 30);
            btnBuscar.Text = "Buscar";
            btnBuscar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnBuscar.BackColor = Color.FromArgb(137, 180, 250);
            btnBuscar.ForeColor = Color.FromArgb(30, 30, 46);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Click += BtnBuscar_Click;

            pnlBuscar.Controls.Add(txtBuscar);
            pnlBuscar.Controls.Add(btnBuscar);

            // DataGridView
            dgvDetalles.Location = new Point(16, 66);
            dgvDetalles.Size = new Size(648, 540);
            dgvDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Left
                                | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.MultiSelect = false;
            dgvDetalles.ReadOnly = true;
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.RowHeadersVisible = false;
            dgvDetalles.BackgroundColor = Color.FromArgb(30, 30, 46);
            dgvDetalles.GridColor = Color.FromArgb(60, 60, 85);
            dgvDetalles.BorderStyle = BorderStyle.None;
            dgvDetalles.ColumnHeadersHeight = 38;
            dgvDetalles.RowTemplate.Height = 32;
            dgvDetalles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 50, 68);
            dgvDetalles.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(137, 180, 250);
            dgvDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvDetalles.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 46);
            dgvDetalles.DefaultCellStyle.ForeColor = Color.FromArgb(205, 214, 244);
            dgvDetalles.DefaultCellStyle.SelectionBackColor = Color.FromArgb(137, 180, 250);
            dgvDetalles.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 30, 46);
            dgvDetalles.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgvDetalles.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 54);
            dgvDetalles.SelectionChanged += DgvDetalles_SelectionChanged;

            // Columnas
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderDetailId",
                HeaderText = "ID",
                Width = 60
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderId",
                HeaderText = "Orden #",
                Width = 80
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreProducto",
                HeaderText = "Producto",
                Width = 180
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Cant.",
                Width = 70
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Precio Unit.",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Subtotal",
                HeaderText = "Subtotal",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            pnlRight.Controls.Add(pnlBuscar);
            pnlRight.Controls.Add(dgvDetalles);

            // ── Agregar al Form ────────────────────────────────────────────
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);

            pnlHeader.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeader;
        private Panel pnlLeft;
        private Label lblTituloForm;
        private Label lblOrden;
        private ComboBox cmbOrden;
        private Label lblProducto;
        private ComboBox cmbProducto;
        private Label lblCantidad;
        private TextBox txtCantidad;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblSubtotal;
        private TextBox txtSubtotal;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Label lblEstado;
        private ProgressBar progressBar;
        private Panel pnlRight;
        private Panel pnlBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvDetalles;
    }
}
