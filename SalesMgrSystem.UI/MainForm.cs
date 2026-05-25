using Microsoft.Extensions.DependencyInjection;
using SalesMgrSystem.Ui.Forms;

namespace SalesMgrSystem.UI;

public partial class MainForm : Form
{
    public MainForm()
    {
        DoubleBuffered = true;
        InitializeComponent();
        InicializarCards();
    }

    private void InicializarCards()
    {
        int w = 280, h = 165, gap = 24;
        int startX = 106, startY = 124;

        CrearCard("📂", "Categorías", "Gestión de categorías de productos",
            Color.FromArgb(88, 166, 255), startX, startY, w, h, BtnCategories_Click);

        CrearCard("📦", "Productos", "Catálogo de productos y precios",
            Color.FromArgb(63, 185, 80), startX + w + gap, startY, w, h, BtnProducts_Click);

        CrearCard("👥", "Clientes", "Administración de clientes",
            Color.FromArgb(188, 140, 255), startX + 2 * (w + gap), startY, w, h, BtnCustomers_Click);

        CrearCard("👤", "Usuarios", "Usuarios del sistema y roles",
            Color.FromArgb(121, 192, 255), startX, startY + h + gap, w, h, BtnUsers_Click);

        CrearCard("📋", "Órdenes", "Órdenes de venta y seguimiento",
            Color.FromArgb(210, 153, 34), startX + w + gap, startY + h + gap, w, h, BtnOrders_Click);

        CrearCard("📝", "Detalles", "Detalle de productos por orden",
            Color.FromArgb(247, 120, 186), startX + 2 * (w + gap), startY + h + gap, w, h, BtnOrderDetails_Click);

        CrearCard("💰", "Pagos", "Registro de pagos y métodos",
            Color.FromArgb(86, 212, 221), startX, startY + 2 * (h + gap), w, h, BtnPayments_Click);

        CrearCard("📊", "Ventas x Producto", "Reporte de ventas por producto",
            Color.FromArgb(240, 136, 62), startX + w + gap, startY + 2 * (h + gap), w, h, BtnProductSales_Click);

        CrearCard("📈", "Resumen Ventas", "Resumen global de ventas",
            Color.FromArgb(255, 107, 107), startX + 2 * (w + gap), startY + 2 * (h + gap), w, h, BtnSalesSummary_Click);
    }

    private void CrearCard(string emoji, string titulo, string desc, Color accent, int x, int y, int w, int h, EventHandler onClick)
    {
        var card = new Panel
        {
            Location = new Point(x, y),
            Size = new Size(w, h),
            BackColor = Color.FromArgb(22, 27, 34),
        };

        var stripe = new Panel
        {
            Dock = DockStyle.Top,
            Height = 3,
            BackColor = accent,
        };

        var lblEmoji = new Label
        {
            AutoSize = false,
            Size = new Size(w, 54),
            Location = new Point(0, 20),
            Text = emoji,
            Font = new Font("Segoe UI", 28f),
            ForeColor = Color.FromArgb(240, 246, 252),
            TextAlign = ContentAlignment.MiddleCenter,
        };

        var lblTitle = new Label
        {
            AutoSize = false,
            Size = new Size(w - 24, 26),
            Location = new Point(12, 84),
            Text = titulo,
            Font = new Font("Segoe UI", 12f, FontStyle.Bold),
            ForeColor = Color.FromArgb(240, 246, 252),
            TextAlign = ContentAlignment.MiddleCenter,
        };

        var lblDesc = new Label
        {
            AutoSize = false,
            Size = new Size(w - 24, 36),
            Location = new Point(12, 113),
            Text = desc,
            Font = new Font("Segoe UI", 9f),
            ForeColor = Color.FromArgb(139, 148, 158),
            TextAlign = ContentAlignment.MiddleCenter,
        };

        card.Controls.AddRange(new Control[] { lblDesc, lblTitle, lblEmoji, stripe });

        Color normalBg = Color.FromArgb(22, 27, 34);
        Color hoverBg = Color.FromArgb(28, 33, 40);
        Color borderColor = Color.FromArgb(48, 54, 61);
        bool hovering = false;

        card.Paint += (_, e) =>
        {
            using var pen = new Pen(hovering ? accent : borderColor, 1);
            e.Graphics.DrawRectangle(pen, 0, 0, w - 1, h - 1);
        };

        void Vincular(Control c)
        {
            c.MouseEnter += (_, _) => { if (!hovering) { hovering = true; card.BackColor = hoverBg; card.Invalidate(); } };
            c.MouseLeave += (_, _) => { if (hovering) { hovering = false; card.BackColor = normalBg; card.Invalidate(); } };
            c.Cursor = Cursors.Hand;
            c.Click += onClick;
            foreach (Control child in c.Controls)
                Vincular(child);
        }
        Vincular(card);

        Controls.Add(card);
    }

    private void BtnCategories_Click(object? sender, EventArgs e)
    {
        using var form = Program.ServiceProvider.GetRequiredService<CategoryForm>();
        form.ShowDialog(this);
    }

    private void BtnProducts_Click(object? sender, EventArgs e)
    {
        using var form = Program.ServiceProvider.GetRequiredService<ProductForm>();
        form.ShowDialog(this);
    }

    private void BtnCustomers_Click(object? sender, EventArgs e)
    {
        using var form = Program.ServiceProvider.GetRequiredService<CustomerForm>();
        form.ShowDialog(this);
    }

    private void BtnUsers_Click(object? sender, EventArgs e)
    {
        using var form = Program.ServiceProvider.GetRequiredService<UserForm>();
        form.ShowDialog(this);
    }

    private void BtnOrders_Click(object? sender, EventArgs e)
    {
        using var form = Program.ServiceProvider.GetRequiredService<OrderForm>();
        form.ShowDialog(this);
    }

    private void BtnOrderDetails_Click(object? sender, EventArgs e)
    {
        using var form = Program.ServiceProvider.GetRequiredService<OrderDetailForm>();
        form.ShowDialog(this);
    }

    private void BtnPayments_Click(object? sender, EventArgs e)
    {
        using var form = Program.ServiceProvider.GetRequiredService<PaymentForm>();
        form.ShowDialog(this);
    }

    private void BtnProductSales_Click(object? sender, EventArgs e)
    {
        using var form = Program.ServiceProvider.GetRequiredService<VwProductSaleForm>();
        form.ShowDialog(this);
    }

    private void BtnSalesSummary_Click(object? sender, EventArgs e)
    {
        using var form = Program.ServiceProvider.GetRequiredService<VwSalesSummaryForm>();
        form.ShowDialog(this);
    }
}
