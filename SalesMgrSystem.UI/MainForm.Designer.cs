namespace SalesMgrSystem.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            pnlSidebar = new Panel();
            pnlContent = new Panel();
            pnlFooter = new Panel();
            lblAppTitle = new Label();
            lblAppSubtitle = new Label();
            lblWelcome = new Label();
            lblDate = new Label();
            lblFooter = new Label();
            lblDashboard = new Label();
            btnCategories = new Button();
            btnCustomers = new Button();
            btnProducts = new Button();
            btnOrders = new Button();
            btnPayments = new Button();
            btnUsers = new Button();

            SuspendLayout();

            // Form
            Text = "Sales Management System";
            Size = new Size(1100, 680);
            MinimumSize = new Size(1000, 620);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(18, 18, 24);
            ForeColor = Color.FromArgb(236, 240, 241);
            Font = new Font("Segoe UI", 9.5f);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // Header
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 75;
            pnlHeader.BackColor = Color.FromArgb(15, 20, 30);

            lblAppTitle.Text = "⬡  Sales Management System";
            lblAppTitle.Font = new Font("Segoe UI", 18f, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblAppTitle.AutoSize = true;
            lblAppTitle.Location = new Point(25, 15);

            lblAppSubtitle.Text = "Business Intelligence & Operations Platform";
            lblAppSubtitle.Font = new Font("Segoe UI", 9f);
            lblAppSubtitle.ForeColor = Color.FromArgb(149, 165, 166);
            lblAppSubtitle.AutoSize = true;
            lblAppSubtitle.Location = new Point(28, 48);

            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy");
            lblDate.Font = new Font("Segoe UI", 9f);
            lblDate.ForeColor = Color.FromArgb(149, 165, 166);
            lblDate.AutoSize = true;
            lblDate.Location = new Point(860, 28);

            pnlHeader.Controls.AddRange(new Control[] { lblAppTitle, lblAppSubtitle, lblDate });

            // Sidebar
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 210;
            pnlSidebar.BackColor = Color.FromArgb(25, 28, 36);

            lblDashboard.Text = "  MAIN MENU";
            lblDashboard.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            lblDashboard.ForeColor = Color.FromArgb(149, 165, 166);
            lblDashboard.Size = new Size(210, 30);
            lblDashboard.Location = new Point(0, 15);
            lblDashboard.Padding = new Padding(18, 0, 0, 0);
            lblDashboard.TextAlign = ContentAlignment.MiddleLeft;

            pnlSidebar.Controls.Add(lblDashboard);

            // Content
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Color.FromArgb(18, 18, 24);

            lblWelcome.Text = "Welcome back — select a module to get started";
            lblWelcome.Font = new Font("Segoe UI", 11f);
            lblWelcome.ForeColor = Color.FromArgb(149, 165, 166);
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(30, 20);

            pnlContent.Controls.Add(lblWelcome);
            pnlContent.Controls.AddRange(new Control[]
                { btnCategories, btnCustomers, btnProducts, btnOrders, btnPayments, btnUsers });

            // Footer
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 30;
            pnlFooter.BackColor = Color.FromArgb(15, 20, 30);
            lblFooter.Text = $"  Sales Management System  ·  v1.0.0  ·  © {DateTime.Now.Year}";
            lblFooter.Font = new Font("Segoe UI", 8f);
            lblFooter.ForeColor = Color.FromArgb(149, 165, 166);
            lblFooter.AutoSize = true;
            lblFooter.Location = new Point(10, 7);

            pnlFooter.Controls.Add(lblFooter);

            Controls.AddRange(new Control[] { pnlContent, pnlSidebar, pnlHeader, pnlFooter });
            ResumeLayout(false);
        }

        private Panel pnlHeader, pnlSidebar, pnlContent, pnlFooter;
        private Label lblAppTitle, lblAppSubtitle, lblWelcome, lblDate, lblFooter, lblDashboard;
        private Button btnCategories, btnCustomers, btnProducts, btnOrders, btnPayments, btnUsers;
    }
}