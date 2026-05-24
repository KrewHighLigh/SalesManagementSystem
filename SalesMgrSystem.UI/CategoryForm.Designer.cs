namespace SalesMgrSystem.UI
{
    partial class CategoryForm
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
            // ── Controles ──────────────────────────────────────────────────
            pnlHeader       = new Panel();
            lblHeader       = new Label();
            pnlLeft         = new Panel();
            lblTituloForm   = new Label();
            lblNombre       = new Label();
            txtNombre       = new TextBox();
            lblDescripcion  = new Label();
            txtDescripcion  = new TextBox();
            btnNuevo        = new Button();
            btnGuardar      = new Button();
            btnEliminar     = new Button();
            lblEstado       = new Label();
            progressBar     = new ProgressBar();
            pnlRight        = new Panel();
            pnlBuscar       = new Panel();
            txtBuscar       = new TextBox();
            btnBuscar       = new Button();
            dgvCategorias   = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();

            // ── FORM ───────────────────────────────────────────────────────
            Name            = "CategoryForm";
            Text            = "Gestión de Categorías";
            ClientSize      = new Size(1000, 640);
            StartPosition   = FormStartPosition.CenterScreen;
            MinimumSize     = new Size(800, 560);
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
            lblHeader.Text      = "📂  Gestión de Categorías  —  SalesMgrSystem";
            lblHeader.Font      = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(137, 180, 250);

            pnlHeader.Controls.Add(lblHeader);

            // ── PANEL IZQUIERDO (formulario) ────────────────────────────────
            pnlLeft.Dock      = DockStyle.Left;
            pnlLeft.Width     = 320;
            pnlLeft.BackColor = Color.FromArgb(30, 30, 46);
            pnlLeft.Padding   = new Padding(24, 20, 24, 20);

            lblTituloForm.Location  = new Point(24, 20);
            lblTituloForm.Size      = new Size(272, 26);
            lblTituloForm.Text      = "＋  Nueva Categoría";
            lblTituloForm.Font      = new Font("Segoe UI", 11f, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.FromArgb(137, 180, 250);

            lblNombre.Location  = new Point(24, 62);
            lblNombre.Size      = new Size(272, 18);
            lblNombre.Text      = "Nombre *";
            lblNombre.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(166, 173, 200);

            txtNombre.Location    = new Point(24, 82);
            txtNombre.Size        = new Size(272, 28);
            txtNombre.MaxLength   = 100;
            txtNombre.BackColor   = Color.FromArgb(49, 50, 68);
            txtNombre.ForeColor   = Color.FromArgb(205, 214, 244);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font        = new Font("Segoe UI", 10f);

            lblDescripcion.Location  = new Point(24, 124);
            lblDescripcion.Size      = new Size(272, 18);
            lblDescripcion.Text      = "Descripción";
            lblDescripcion.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(166, 173, 200);

            txtDescripcion.Location    = new Point(24, 144);
            txtDescripcion.Size        = new Size(272, 90);
            txtDescripcion.Multiline   = true;
            txtDescripcion.MaxLength   = 500;
            txtDescripcion.ScrollBars  = ScrollBars.Vertical;
            txtDescripcion.BackColor   = Color.FromArgb(49, 50, 68);
            txtDescripcion.ForeColor   = Color.FromArgb(205, 214, 244);
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font        = new Font("Segoe UI", 9.5f);

            // Botones
            btnNuevo.Location  = new Point(24, 252);
            btnNuevo.Size      = new Size(80, 36);
            btnNuevo.Text      = "🗋  Nuevo";
            btnNuevo.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnNuevo.BackColor = Color.FromArgb(49, 50, 68);
            btnNuevo.ForeColor = Color.FromArgb(205, 214, 244);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(88, 91, 112);
            btnNuevo.Cursor    = Cursors.Hand;
            btnNuevo.Click    += btnNuevo_Click;

            btnGuardar.Location  = new Point(114, 252);
            btnGuardar.Size      = new Size(96, 36);
            btnGuardar.Text      = "💾  Guardar";
            btnGuardar.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnGuardar.BackColor = Color.FromArgb(137, 180, 250);
            btnGuardar.ForeColor = Color.FromArgb(30, 30, 46);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Cursor    = Cursors.Hand;
            btnGuardar.Click    += btnGuardar_Click;

            btnEliminar.Location  = new Point(220, 252);
            btnEliminar.Size      = new Size(76, 36);
            btnEliminar.Text      = "🗑  Borrar";
            btnEliminar.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnEliminar.BackColor = Color.FromArgb(243, 139, 168);
            btnEliminar.ForeColor = Color.FromArgb(30, 30, 46);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Cursor    = Cursors.Hand;
            btnEliminar.Enabled   = false;
            btnEliminar.Click    += btnEliminar_Click;

            lblEstado.Location  = new Point(24, 304);
            lblEstado.Size      = new Size(272, 50);
            lblEstado.Text      = "Listo.";
            lblEstado.Font      = new Font("Segoe UI", 8.5f);
            lblEstado.ForeColor = Color.FromArgb(127, 132, 156);

            progressBar.Location = new Point(24, 362);
            progressBar.Size     = new Size(272, 6);
            progressBar.Style    = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Visible  = false;

            pnlLeft.Controls.Add(lblTituloForm);
            pnlLeft.Controls.Add(lblNombre);
            pnlLeft.Controls.Add(txtNombre);
            pnlLeft.Controls.Add(lblDescripcion);
            pnlLeft.Controls.Add(txtDescripcion);
            pnlLeft.Controls.Add(btnNuevo);
            pnlLeft.Controls.Add(btnGuardar);
            pnlLeft.Controls.Add(btnEliminar);
            pnlLeft.Controls.Add(lblEstado);
            pnlLeft.Controls.Add(progressBar);

            // ── PANEL DERECHO (lista) ───────────────────────────────────────
            pnlRight.Dock      = DockStyle.Fill;
            pnlRight.BackColor = Color.FromArgb(24, 24, 37);
            pnlRight.Padding   = new Padding(16, 16, 16, 16);

            pnlBuscar.Location  = new Point(16, 16);
            pnlBuscar.Size      = new Size(648, 38);
            pnlBuscar.BackColor = Color.FromArgb(49, 50, 68);
            pnlBuscar.Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            txtBuscar.Location       = new Point(12, 7);
            txtBuscar.Size           = new Size(520, 24);
            txtBuscar.BackColor      = Color.FromArgb(49, 50, 68);
            txtBuscar.ForeColor      = Color.FromArgb(205, 214, 244);
            txtBuscar.BorderStyle    = BorderStyle.None;
            txtBuscar.Font           = new Font("Segoe UI", 10f);
            txtBuscar.PlaceholderText = "🔍  Buscar por nombre o descripción...";
            txtBuscar.KeyDown       += txtBuscar_KeyDown;

            btnBuscar.Location  = new Point(550, 4);
            btnBuscar.Size      = new Size(88, 30);
            btnBuscar.Text      = "Buscar";
            btnBuscar.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnBuscar.BackColor = Color.FromArgb(137, 180, 250);
            btnBuscar.ForeColor = Color.FromArgb(30, 30, 46);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.Cursor    = Cursors.Hand;
            btnBuscar.Click    += btnBuscar_Click;

            pnlBuscar.Controls.Add(txtBuscar);
            pnlBuscar.Controls.Add(btnBuscar);

            // DataGridView
            dgvCategorias.Location              = new Point(16, 66);
            dgvCategorias.Size                  = new Size(648, 540);
            dgvCategorias.Anchor                = AnchorStyles.Top | AnchorStyles.Left
                                                | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvCategorias.AutoGenerateColumns   = true;
            dgvCategorias.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.MultiSelect           = false;
            dgvCategorias.ReadOnly              = true;
            dgvCategorias.AllowUserToAddRows    = false;
            dgvCategorias.RowHeadersVisible     = false;
            dgvCategorias.BackgroundColor       = Color.FromArgb(30, 30, 46);
            dgvCategorias.GridColor             = Color.FromArgb(60, 60, 85);
            dgvCategorias.BorderStyle           = BorderStyle.None;
            dgvCategorias.ColumnHeadersHeight   = 38;
            dgvCategorias.RowTemplate.Height    = 32;
            dgvCategorias.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(49, 50, 68);
            dgvCategorias.ColumnHeadersDefaultCellStyle.ForeColor  = Color.FromArgb(137, 180, 250);
            dgvCategorias.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvCategorias.DefaultCellStyle.BackColor               = Color.FromArgb(30, 30, 46);
            dgvCategorias.DefaultCellStyle.ForeColor               = Color.FromArgb(205, 214, 244);
            dgvCategorias.DefaultCellStyle.SelectionBackColor      = Color.FromArgb(137, 180, 250);
            dgvCategorias.DefaultCellStyle.SelectionForeColor      = Color.FromArgb(30, 30, 46);
            dgvCategorias.DefaultCellStyle.Font                    = new Font("Segoe UI", 9f);
            dgvCategorias.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 36, 54);
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;

            pnlRight.Controls.Add(pnlBuscar);
            pnlRight.Controls.Add(dgvCategorias);

            // ── Agregar al Form ────────────────────────────────────────────
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);

            pnlHeader.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel           pnlHeader;
        private Label           lblHeader;
        private Panel           pnlLeft;
        private Label           lblTituloForm;
        private Label           lblNombre;
        private TextBox         txtNombre;
        private Label           lblDescripcion;
        private TextBox         txtDescripcion;
        private Button          btnNuevo;
        private Button          btnGuardar;
        private Button          btnEliminar;
        private Label           lblEstado;
        private ProgressBar     progressBar;
        private Panel           pnlRight;
        private Panel           pnlBuscar;
        private TextBox         txtBuscar;
        private Button          btnBuscar;
        private DataGridView    dgvCategorias;
    }
}
