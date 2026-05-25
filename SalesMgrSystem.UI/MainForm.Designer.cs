namespace SalesMgrSystem.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlFooter = new Panel();
            lblFooter = new Label();
            headerAccent = new Panel();
            footerBorder = new Panel();
            pnlHeader.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(22, 27, 34);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 100;
            pnlHeader.Padding = new Padding(48, 0, 48, 0);

            lblTitle.AutoSize = false;
            lblTitle.Location = new Point(48, 22);
            lblTitle.Size = new Size(700, 46);
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(240, 246, 252);
            lblTitle.Text = "Sales Management System";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            lblSubtitle.AutoSize = false;
            lblSubtitle.Location = new Point(48, 68);
            lblSubtitle.Size = new Size(700, 24);
            lblSubtitle.Font = new Font("Segoe UI", 12F);
            lblSubtitle.ForeColor = Color.FromArgb(139, 148, 158);
            lblSubtitle.Text = "Panel de Control — Gestión de Ventas";
            lblSubtitle.TextAlign = ContentAlignment.MiddleLeft;

            headerAccent.BackColor = Color.FromArgb(88, 166, 255);
            headerAccent.Dock = DockStyle.Bottom;
            headerAccent.Height = 2;

            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(headerAccent);

            // pnlFooter
            pnlFooter.BackColor = Color.FromArgb(22, 27, 34);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 36;

            footerBorder.BackColor = Color.FromArgb(33, 38, 45);
            footerBorder.Dock = DockStyle.Top;
            footerBorder.Height = 1;

            lblFooter.AutoSize = false;
            lblFooter.Dock = DockStyle.Fill;
            lblFooter.Font = new Font("Segoe UI", 9F);
            lblFooter.ForeColor = Color.FromArgb(139, 148, 158);
            lblFooter.Text = "v1.0  ·  SalesMgrSystem  ·  Sales Management System";
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;

            pnlFooter.Controls.Add(lblFooter);
            pnlFooter.Controls.Add(footerBorder);

            // MainForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 17, 23);
            ClientSize = new Size(1100, 720);
            MinimumSize = new Size(900, 620);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales Management System";

            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);

            pnlHeader.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel headerAccent;
        private Panel pnlFooter;
        private Label lblFooter;
        private Panel footerBorder;
    }
}
