namespace SalesMgrSystem.UI
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            pnlHeader=new Panel(); lblHeader=new Label();
            pnlLeft=new Panel(); lblTituloForm=new Label();
            lblUsername=new Label(); txtUsername=new TextBox();
            lblFullName=new Label(); txtFullName=new TextBox();
            lblEmail=new Label(); txtEmail=new TextBox();
            lblPassword=new Label(); txtPassword=new TextBox();
            lblRole=new Label(); cmbRole=new ComboBox();
            chkActivo=new CheckBox();
            btnNuevo=new Button(); btnGuardar=new Button(); btnEliminar=new Button();
            lblEstado=new Label(); progressBar=new ProgressBar();
            pnlRight=new Panel(); pnlBuscar=new Panel();
            txtBuscar=new TextBox(); btnBuscar=new Button();
            dgv=new DataGridView();

            pnlHeader.SuspendLayout(); pnlLeft.SuspendLayout(); pnlRight.SuspendLayout(); pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();

            Name="UserForm"; Text="Gestión de Usuarios"; ClientSize=new Size(1050,640); StartPosition=FormStartPosition.CenterScreen;
            Font=new Font("Segoe UI",9.5f); BackColor=Color.FromArgb(24,24,37); ForeColor=Color.FromArgb(205,214,244);

            pnlHeader.Dock=DockStyle.Top; pnlHeader.Height=58; pnlHeader.BackColor=Color.FromArgb(30,30,46); pnlHeader.Padding=new Padding(20,0,0,0);
            lblHeader.AutoSize=false; lblHeader.Dock=DockStyle.Fill; lblHeader.TextAlign=ContentAlignment.MiddleLeft;
            lblHeader.Text="🔑  Gestión de Usuarios  —  SalesMgrSystem"; lblHeader.Font=new Font("Segoe UI",13f,FontStyle.Bold); lblHeader.ForeColor=Color.FromArgb(137,180,250);
            pnlHeader.Controls.Add(lblHeader);

            pnlLeft.Dock=DockStyle.Left; pnlLeft.Width=340; pnlLeft.BackColor=Color.FromArgb(30,30,46);

            void Lbl(Label l,string t,int y){l.Location=new Point(24,y);l.Size=new Size(292,18);l.Text=t;l.Font=new Font("Segoe UI",9f,FontStyle.Bold);l.ForeColor=Color.FromArgb(166,173,200);}
            void Txt(TextBox t,int y){t.Location=new Point(24,y);t.Size=new Size(292,28);t.BackColor=Color.FromArgb(49,50,68);t.ForeColor=Color.FromArgb(205,214,244);t.BorderStyle=BorderStyle.FixedSingle;t.Font=new Font("Segoe UI",10f);}

            lblTituloForm.Location=new Point(24,18); lblTituloForm.Size=new Size(292,26); lblTituloForm.Text="＋  Nuevo Usuario"; lblTituloForm.Font=new Font("Segoe UI",11f,FontStyle.Bold); lblTituloForm.ForeColor=Color.FromArgb(137,180,250);
            Lbl(lblUsername,"Username *",54); Txt(txtUsername,74);
            Lbl(lblFullName,"Nombre Completo *",114); Txt(txtFullName,134);
            Lbl(lblEmail,"Email",174); Txt(txtEmail,194);
            Lbl(lblPassword,"Contraseña *",234); Txt(txtPassword,254); txtPassword.PasswordChar='●';
            Lbl(lblRole,"Rol",294);
            cmbRole.Location=new Point(24,314); cmbRole.Size=new Size(292,28); cmbRole.BackColor=Color.FromArgb(49,50,68); cmbRole.ForeColor=Color.FromArgb(205,214,244); cmbRole.FlatStyle=FlatStyle.Flat; cmbRole.Font=new Font("Segoe UI",10f); cmbRole.DropDownStyle=ComboBoxStyle.DropDown;
            cmbRole.Items.AddRange(new object[]{"Admin","Manager","SalesRep","Viewer"}); cmbRole.SelectedIndex=2;
            chkActivo.Location=new Point(24,356); chkActivo.Size=new Size(120,24); chkActivo.Text="Activo"; chkActivo.Checked=true; chkActivo.ForeColor=Color.FromArgb(205,214,244); chkActivo.Font=new Font("Segoe UI",9.5f);

            void Btn(Button b,string t,int x,Color bg,Color fg){b.Location=new Point(x,392);b.Size=new Size(82,36);b.Text=t;b.Font=new Font("Segoe UI",9f,FontStyle.Bold);b.BackColor=bg;b.ForeColor=fg;b.FlatStyle=FlatStyle.Flat;b.FlatAppearance.BorderSize=0;b.Cursor=Cursors.Hand;}
            Btn(btnNuevo,"🗋  Nuevo",24,Color.FromArgb(49,50,68),Color.FromArgb(205,214,244)); btnNuevo.FlatAppearance.BorderColor=Color.FromArgb(88,91,112); btnNuevo.FlatAppearance.BorderSize=1;
            Btn(btnGuardar,"💾  Guardar",116,Color.FromArgb(137,180,250),Color.FromArgb(30,30,46));
            Btn(btnEliminar,"🗑  Borrar",208,Color.FromArgb(243,139,168),Color.FromArgb(30,30,46)); btnEliminar.Enabled=false;

            lblEstado.Location=new Point(24,440); lblEstado.Size=new Size(292,50); lblEstado.Text="Listo."; lblEstado.Font=new Font("Segoe UI",8.5f); lblEstado.ForeColor=Color.FromArgb(127,132,156);
            progressBar.Location=new Point(24,496); progressBar.Size=new Size(292,6); progressBar.Style=ProgressBarStyle.Marquee; progressBar.MarqueeAnimationSpeed=30; progressBar.Visible=false;

            btnNuevo.Click+=btnNuevo_Click; btnGuardar.Click+=btnGuardar_Click; btnEliminar.Click+=btnEliminar_Click;
            pnlLeft.Controls.AddRange(new Control[]{lblTituloForm,lblUsername,txtUsername,lblFullName,txtFullName,lblEmail,txtEmail,lblPassword,txtPassword,lblRole,cmbRole,chkActivo,btnNuevo,btnGuardar,btnEliminar,lblEstado,progressBar});

            pnlRight.Dock=DockStyle.Fill; pnlRight.BackColor=Color.FromArgb(24,24,37);
            pnlBuscar.Location=new Point(16,16); pnlBuscar.Size=new Size(668,38); pnlBuscar.BackColor=Color.FromArgb(49,50,68); pnlBuscar.Anchor=AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right;
            txtBuscar.Location=new Point(12,7); txtBuscar.Size=new Size(536,24); txtBuscar.BackColor=Color.FromArgb(49,50,68); txtBuscar.ForeColor=Color.FromArgb(205,214,244); txtBuscar.BorderStyle=BorderStyle.None; txtBuscar.Font=new Font("Segoe UI",10f); txtBuscar.PlaceholderText="🔍  Buscar por username, nombre o email..."; txtBuscar.KeyDown+=txtBuscar_KeyDown;
            btnBuscar.Location=new Point(564,4); btnBuscar.Size=new Size(94,30); btnBuscar.Text="Buscar"; btnBuscar.Font=new Font("Segoe UI",9f,FontStyle.Bold); btnBuscar.BackColor=Color.FromArgb(137,180,250); btnBuscar.ForeColor=Color.FromArgb(30,30,46); btnBuscar.FlatStyle=FlatStyle.Flat; btnBuscar.FlatAppearance.BorderSize=0; btnBuscar.Cursor=Cursors.Hand; btnBuscar.Click+=btnBuscar_Click;
            pnlBuscar.Controls.Add(txtBuscar); pnlBuscar.Controls.Add(btnBuscar);

            dgv.Location=new Point(16,66); dgv.Size=new Size(668,540); dgv.Anchor=AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Bottom;
            dgv.AutoGenerateColumns=true; dgv.SelectionMode=DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect=false; dgv.ReadOnly=true; dgv.AllowUserToAddRows=false; dgv.RowHeadersVisible=false;
            dgv.BackgroundColor=Color.FromArgb(30,30,46); dgv.GridColor=Color.FromArgb(60,60,85); dgv.BorderStyle=BorderStyle.None; dgv.ColumnHeadersHeight=38; dgv.RowTemplate.Height=32;
            dgv.ColumnHeadersDefaultCellStyle.BackColor=Color.FromArgb(49,50,68); dgv.ColumnHeadersDefaultCellStyle.ForeColor=Color.FromArgb(137,180,250); dgv.ColumnHeadersDefaultCellStyle.Font=new Font("Segoe UI",9.5f,FontStyle.Bold);
            dgv.DefaultCellStyle.BackColor=Color.FromArgb(30,30,46); dgv.DefaultCellStyle.ForeColor=Color.FromArgb(205,214,244); dgv.DefaultCellStyle.SelectionBackColor=Color.FromArgb(137,180,250); dgv.DefaultCellStyle.SelectionForeColor=Color.FromArgb(30,30,46); dgv.DefaultCellStyle.Font=new Font("Segoe UI",9f);
            dgv.AlternatingRowsDefaultCellStyle.BackColor=Color.FromArgb(36,36,54); dgv.SelectionChanged+=dgv_SelectionChanged;
            pnlRight.Controls.Add(pnlBuscar); pnlRight.Controls.Add(dgv);

            Controls.Add(pnlRight); Controls.Add(pnlLeft); Controls.Add(pnlHeader);
            pnlHeader.ResumeLayout(false); pnlLeft.ResumeLayout(false); pnlRight.ResumeLayout(false); pnlBuscar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlHeader; private Label lblHeader;
        private Panel pnlLeft; private Label lblTituloForm;
        private Label lblUsername; private TextBox txtUsername;
        private Label lblFullName; private TextBox txtFullName;
        private Label lblEmail; private TextBox txtEmail;
        private Label lblPassword; private TextBox txtPassword;
        private Label lblRole; private ComboBox cmbRole;
        private CheckBox chkActivo;
        private Button btnNuevo, btnGuardar, btnEliminar;
        private Label lblEstado; private ProgressBar progressBar;
        private Panel pnlRight, pnlBuscar;
        private TextBox txtBuscar; private Button btnBuscar;
        private DataGridView dgv;
    }
}
