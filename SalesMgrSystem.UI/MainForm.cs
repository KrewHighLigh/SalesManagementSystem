using Microsoft.Extensions.DependencyInjection;
using SalesMgrSystem.Data.Services;
using SalesMgrSystem.Ui.Forms;
using SalesMgrSystem.UI.Forms;

namespace SalesMgrSystem.UI
{
    public partial class MainForm : Form
    {
        private readonly CategoryService _categoryService;
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;
        private readonly OrderDetailService _orderDetailService;
        private readonly PaymentService _paymentService;
        private readonly UserService _userService;

        public MainForm(
            CategoryService categoryService,
            CustomerService customerService,
            OrderService orderService,
            OrderDetailService orderDetailService,
            PaymentService paymentService,
            ProductService productService,
            UserService userService)
        {
            _categoryService = categoryService;
            _customerService = customerService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _paymentService = paymentService;
            _productService = productService;
            _userService = userService;

            InitializeComponent();
            SetupUI();
            AttachEvents();
        }

        private void SetupUI()
        {
            var cardBg = Color.FromArgb(30, 39, 46);
            var textMuted = Color.FromArgb(149, 165, 166);
            var sidebarBg = Color.FromArgb(25, 28, 36);
            var textLight = Color.FromArgb(236, 240, 241);

            // Cards
            var cards = new (Button btn, string icon, string title, string sub)[]
            {
                (btnCategories, "🗂", "Categories", "Manage product categories"),
                (btnCustomers,  "👥", "Customers",  "Client database & contacts"),
                (btnProducts,   "📦", "Products",   "Inventory & pricing"),
                (btnOrders,     "🧾", "Orders",     "Sales orders & tracking"),
                (btnPayments,   "💳", "Payments",   "Transactions & receipts"),
                (btnUsers,      "🔐", "Users",      "Accounts & permissions"),
            };

            int col = 0, row = 0, cw = 240, ch = 120, gx = 20, gy = 65;
            foreach (var (btn, icon, title, sub) in cards)
            {
                btn.Size = new Size(cw, ch);
                btn.Location = new Point(30 + col * (cw + gx), 60 + row * (ch + gy));
                btn.BackColor = cardBg;
                btn.ForeColor = Color.FromArgb(189, 195, 199);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.FromArgb(44, 62, 80);
                btn.FlatAppearance.BorderSize = 1;
                btn.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                btn.Text = $"{icon}\n{title}";
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Cursor = Cursors.Hand;
                btn.MouseEnter += Card_MouseEnter;
                btn.MouseLeave += Card_MouseLeave;

                pnlContent.Controls.Add(new Label
                {
                    Text = sub,
                    Font = new Font("Segoe UI", 7.5f),
                    ForeColor = textMuted,
                    BackColor = Color.Transparent,
                    Size = new Size(cw - 20, 20),
                    Location = new Point(btn.Left + 10, btn.Bottom - 22),
                    TextAlign = ContentAlignment.MiddleCenter
                });

                if (++col == 3) { col = 0; row++; }
            }

            // Sidebar buttons
            var sideItems = new (Button btn, string icon, string label)[]
            {
                (btnCategories, "🗂", " Categories"),
                (btnCustomers,  "👥", " Customers"),
                (btnProducts,   "📦", " Products"),
                (btnOrders,     "🧾", " Orders"),
                (btnPayments,   "💳", " Payments"),
                (btnUsers,      "🔐", " Users"),
            };

            int sy = 55;
            foreach (var (btn, icon, label) in sideItems)
            {
                btn.Size = new Size(210, 48);
                btn.Text = $"  {icon}  {label}";
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = sidebarBg;
                btn.ForeColor = textMuted;
                btn.Font = new Font("Segoe UI", 10f);
                btn.Cursor = Cursors.Hand;
                btn.Location = new Point(0, sy);
                btn.MouseEnter += (s, e) => { if (s is Button b) { b.BackColor = Color.FromArgb(35, 40, 52); b.ForeColor = textLight; } };
                btn.MouseLeave += (s, e) => { if (s is Button b) { b.BackColor = sidebarBg; b.ForeColor = textMuted; } };
                pnlSidebar.Controls.Add(btn);
                sy += 52;
            }
        }

        private void AttachEvents()
        {
            btnCategories.Click += (s, e) => OpenForm<CategoryForm>();
            btnCustomers.Click += (s, e) => OpenForm<CustomerForm>();
            btnProducts.Click += (s, e) => OpenForm<ProductForm>();
            btnOrders.Click += (s, e) => OpenForm<OrderForm>();
            btnPayments.Click += (s, e) => OpenForm<PaymentForm>();
            btnUsers.Click += (s, e) => OpenForm<UserForm>();
        }

        private static void OpenForm<T>() where T : Form
        {
            Program.ServiceProvider.GetRequiredService<T>().Show();
        }

        private void Card_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(52, 152, 219);
                btn.ForeColor = Color.White;
            }
        }

        private void Card_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(30, 39, 46);
                btn.ForeColor = Color.FromArgb(189, 195, 199);
            }
        }
    }
}