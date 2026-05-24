namespace SalesMgrSystem.Ui.Forms;

partial class ProductosForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        pnlSuperior = new Panel();
        lblTitulo = new Label();
        pnlBusqueda = new Panel();
        lblBuscar = new Label();
        txtBuscar = new TextBox();
        dgvProductos = new DataGridView();
        pnlFormulario = new Panel();
        grpDatos = new GroupBox();
        lblModo = new Label();
        lblNombre = new Label();
        txtNombre = new TextBox();
        lblPrecio = new Label();
        txtPrecio = new TextBox();
        lblStock = new Label();
        txtStock = new TextBox();
        lblDescripcion = new Label();
        txtDescripcion = new TextBox();
        lblCategoria = new Label();
        cmbCategoria = new ComboBox();
        chkActivo = new CheckBox();
        pnlBotones = new Panel();
        btnNuevo = new Button();
        btnGuardar = new Button();
        btnEliminar = new Button();
        btnCancelar = new Button();

        // ── frmProductos ──────────────────────────────────────────────────────
        SuspendLayout();
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1020, 660);
        Font = new Font("Segoe UI", 10F);
        MinimumSize = new Size(900, 600);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gestión de Productos";
        Load += frmProductos_Load;

        // ── Panel superior ────────────────────────────────────────────────────
        pnlSuperior.BackColor = Color.FromArgb(30, 115, 190);
        pnlSuperior.Dock = DockStyle.Top;
        pnlSuperior.Height = 56;

        lblTitulo.AutoSize = false;
        lblTitulo.Dock = DockStyle.Fill;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Text = "📦  Gestión de Productos";
        lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
        lblTitulo.Padding = new Padding(14, 0, 0, 0);
        pnlSuperior.Controls.Add(lblTitulo);

        // ── Panel búsqueda ────────────────────────────────────────────────────
        pnlBusqueda.Dock = DockStyle.Top;
        pnlBusqueda.Height = 48;
        pnlBusqueda.Padding = new Padding(10, 8, 10, 4);
        pnlBusqueda.BackColor = Color.FromArgb(240, 245, 255);

        lblBuscar.AutoSize = true;
        lblBuscar.Location = new Point(10, 13);
        lblBuscar.Text = "Buscar:";

        txtBuscar.Location = new Point(72, 9);
        txtBuscar.Size = new Size(300, 28);
        txtBuscar.PlaceholderText = "Nombre del producto…";
        txtBuscar.TextChanged += txtBuscar_TextChanged;

        pnlBusqueda.Controls.AddRange(new Control[] { lblBuscar, txtBuscar });

        // ── DataGridView ──────────────────────────────────────────────────────
        dgvProductos.AllowUserToAddRows = false;
        dgvProductos.AllowUserToDeleteRows = false;
        dgvProductos.AutoGenerateColumns = false;
        dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProductos.BackgroundColor = Color.White;
        dgvProductos.BorderStyle = BorderStyle.None;
        dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvProductos.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProductos.ColumnHeadersDefaultCellStyle.BackColor =
            Color.FromArgb(220, 235, 255);
        dgvProductos.ColumnHeadersDefaultCellStyle.Font =
            new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dgvProductos.AlternatingRowsDefaultCellStyle.BackColor =
            Color.FromArgb(245, 248, 255);
        dgvProductos.Dock = DockStyle.Fill;
        dgvProductos.GridColor = Color.FromArgb(210, 220, 235);
        dgvProductos.MultiSelect = false;
        dgvProductos.ReadOnly = true;
        dgvProductos.RowHeadersVisible = false;
        dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;

        // ── Panel formulario (lado derecho) ───────────────────────────────────
        pnlFormulario.Dock = DockStyle.Right;
        pnlFormulario.Width = 310;
        pnlFormulario.Padding = new Padding(10, 8, 10, 8);
        pnlFormulario.BackColor = Color.FromArgb(248, 250, 255);

        // lblModo
        lblModo.AutoSize = false;
        lblModo.Dock = DockStyle.Top;
        lblModo.Height = 28;
        lblModo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        lblModo.ForeColor = Color.FromArgb(30, 115, 190);
        lblModo.Text = "➕  Nuevo producto";
        lblModo.TextAlign = ContentAlignment.MiddleLeft;

        // GroupBox datos
        grpDatos.Dock = DockStyle.Top;
        grpDatos.Height = 360;
        grpDatos.Text = "Datos del Producto";
        grpDatos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        grpDatos.Padding = new Padding(10, 14, 10, 6);

        // — Nombre —
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(10, 46);
        lblNombre.Text = "Nombre: *";
        lblNombre.Font = new Font("Segoe UI", 9F);

        txtNombre.Location = new Point(10, 64);
        txtNombre.Size = new Size(272, 28);
        txtNombre.MaxLength = 200;

        // — Precio unitario —
        lblPrecio.AutoSize = true;
        lblPrecio.Location = new Point(10, 102);
        lblPrecio.Text = "Precio unitario: *";
        lblPrecio.Font = new Font("Segoe UI", 9F);

        txtPrecio.Location = new Point(10, 120);
        txtPrecio.Size = new Size(128, 28);

        // — Stock —
        lblStock.AutoSize = true;
        lblStock.Location = new Point(152, 102);
        lblStock.Text = "Stock: *";
        lblStock.Font = new Font("Segoe UI", 9F);

        txtStock.Location = new Point(152, 120);
        txtStock.Size = new Size(130, 28);

        // — Categoría —
        lblCategoria.AutoSize = true;
        lblCategoria.Location = new Point(10, 160);
        lblCategoria.Text = "Categoría:";
        lblCategoria.Font = new Font("Segoe UI", 9F);

        cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCategoria.FormattingEnabled = true;
        cmbCategoria.Location = new Point(10, 178);
        cmbCategoria.Size = new Size(272, 28);

        // — Descripción —
        lblDescripcion.AutoSize = true;
        lblDescripcion.Location = new Point(10, 218);
        lblDescripcion.Text = "Descripción:";
        lblDescripcion.Font = new Font("Segoe UI", 9F);

        txtDescripcion.Location = new Point(10, 236);
        txtDescripcion.Size = new Size(272, 64);
        txtDescripcion.Multiline = true;
        txtDescripcion.MaxLength = 500;
        txtDescripcion.ScrollBars = ScrollBars.Vertical;

        // — Activo —
        chkActivo.AutoSize = true;
        chkActivo.Location = new Point(10, 312);
        chkActivo.Text = "Producto activo";
        chkActivo.Checked = true;
        chkActivo.Font = new Font("Segoe UI", 9F);

        grpDatos.Controls.AddRange(new Control[]
        {
            lblNombre,    txtNombre,
            lblPrecio,    txtPrecio,
            lblStock,     txtStock,
            lblCategoria, cmbCategoria,
            lblDescripcion, txtDescripcion,
            chkActivo
        });

        // ── Panel botones ─────────────────────────────────────────────────────
        pnlBotones.Dock = DockStyle.Top;
        pnlBotones.Height = 185;
        pnlBotones.Padding = new Padding(0, 8, 0, 0);

        Btn(btnNuevo, "➕  Nuevo", Color.FromArgb(30, 115, 190), new Point(0, 8));
        Btn(btnGuardar, "💾  Guardar", Color.FromArgb(39, 174, 96), new Point(0, 53));
        Btn(btnEliminar, "🗑  Eliminar", Color.FromArgb(231, 76, 60), new Point(0, 98));
        Btn(btnCancelar, "✖  Cancelar", Color.FromArgb(127, 140, 141), new Point(0, 143));

        btnNuevo.Click += btnNuevo_Click;
        btnGuardar.Click += btnGuardar_Click;
        btnEliminar.Click += btnEliminar_Click;
        btnCancelar.Click += btnCancelar_Click;

        pnlBotones.Controls.AddRange(new Control[]
            { btnNuevo, btnGuardar, btnEliminar, btnCancelar });

        // ── Ensamblado ────────────────────────────────────────────────────────
        pnlFormulario.Controls.Add(pnlBotones);
        pnlFormulario.Controls.Add(grpDatos);
        pnlFormulario.Controls.Add(lblModo);

        Controls.Add(dgvProductos);   // Fill (debe agregarse antes que Right)
        Controls.Add(pnlFormulario);
        Controls.Add(pnlBusqueda);
        Controls.Add(pnlSuperior);

        ResumeLayout(false);
        PerformLayout();
    }

    private static void Btn(Button b, string texto, Color color, Point loc)
    {
        b.BackColor = color;
        b.FlatStyle = FlatStyle.Flat;
        b.FlatAppearance.BorderSize = 0;
        b.ForeColor = Color.White;
        b.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        b.Location = loc;
        b.Size = new Size(282, 38);
        b.Text = texto;
        b.Cursor = Cursors.Hand;
        b.UseVisualStyleBackColor = false;
    }

    #endregion

    // ── Declaraciones ─────────────────────────────────────────────────────────
    private Panel pnlSuperior;
    private Label lblTitulo;
    private Panel pnlBusqueda;
    private Label lblBuscar;
    private TextBox txtBuscar;
    private DataGridView dgvProductos;
    private Panel pnlFormulario;
    private GroupBox grpDatos;
    private Label lblModo;
    private Label lblNombre;
    private TextBox txtNombre;
    private Label lblPrecio;
    private TextBox txtPrecio;
    private Label lblStock;
    private TextBox txtStock;
    private Label lblDescripcion;
    private TextBox txtDescripcion;
    private Label lblCategoria;
    private ComboBox cmbCategoria;
    private CheckBox chkActivo;
    private Panel pnlBotones;
    private Button btnNuevo;
    private Button btnGuardar;
    private Button btnEliminar;
    private Button btnCancelar;
}