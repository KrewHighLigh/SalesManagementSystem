# Plan de correcciones: MainForm + UserForm + OrderDetailForm

## 1. OrderDetailForm.cs — Corregir 2 warnings CS8601

**Archivo**: `SalesMgrSystem.UI\OrderDetailForm.cs`  
**Líneas**: 213-214

**Cambio**: Agregar operador null-forgiving para `int?` asignado a `SelectedValue`:

```csharp
// ANTES:
cmbOrden.SelectedValue = det.OrderId;
cmbProducto.SelectedValue = det.ProductId;

// DESPUÉS:
cmbOrden.SelectedValue = det.OrderId ?? (object?)0;
cmbProducto.SelectedValue = det.ProductId ?? (object?)0;
```

---

## 2. UserForm.cs — Mover carga al evento Load + robustez

**Archivo**: `SalesMgrSystem.UI\UserForm.cs`

### 2a. Cambiar constructor
```csharp
// ANTES:
public UserForm()
{
    InitializeComponent();
    _ = CargarUsuarios();
}

// DESPUÉS:
public UserForm()
{
    InitializeComponent();
    Load += async (s, e) => await CargarUsuarios();
}
```

### 2b. Agregar using para eventos si no está:
No necesita cambios adicionales — `Load` es el evento por defecto de `Form`.

---

## 3. UserForm.Designer.cs — Sin cambios necesarios
El diseño del UserForm está bien. Los controles existen y están correctamente declarados.

---

## 4. MainForm.Designer.cs — Reescribir completo con diseño profesional

**Archivo**: `SalesMgrSystem.UI\MainForm.Designer.cs`

Reemplazar todo el contenido con:

```csharp
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
            btnCategories = new Button();
            btnProducts = new Button();
            btnCustomers = new Button();
            btnUsers = new Button();
            btnOrders = new Button();
            btnOrderDetails = new Button();
            btnPayments = new Button();
            btnProductSales = new Button();
            btnSalesSummary = new Button();
            pnlHeader.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();

            // HEADER
            pnlHeader.BackColor = Color.FromArgb(30, 30, 46);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 80;
            pnlHeader.Padding = new Padding(30, 0, 30, 0);

            lblTitle.AutoSize = false;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 44;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(137, 180, 250);
            lblTitle.Text = "Sales Management System";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.Padding = new Padding(0, 10, 0, 0);

            lblSubtitle.AutoSize = false;
            lblSubtitle.Dock = DockStyle.Top;
            lblSubtitle.Height = 24;
            lblSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblSubtitle.ForeColor = Color.FromArgb(166, 173, 200);
            lblSubtitle.Text = "Panel de control — Gestión de Ventas";
            lblSubtitle.TextAlign = ContentAlignment.MiddleLeft;

            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);

            // FOOTER
            pnlFooter.BackColor = Color.FromArgb(30, 30, 46);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 36;

            lblFooter.AutoSize = false;
            lblFooter.Dock = DockStyle.Fill;
            lblFooter.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblFooter.ForeColor = Color.FromArgb(127, 132, 156);
            lblFooter.Text = "v1.0  ·  SalesMgrSystem  ·  Seleccione un módulo para comenzar";
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;

            pnlFooter.Controls.Add(lblFooter);

            // FORM
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 37);
            ClientSize = new Size(960, 620);
            MinimumSize = new Size(800, 540);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales Management System";

            // BOTONES (grid 3x3)
            int xStart = 52, yStart = 110, btnW = 270, btnH = 130, gapX = 30, gapY = 30;

            btnCategories = CrearBoton("📂  Categorías", "Gestión de categorías de productos",
                Color.FromArgb(137, 180, 250), xStart, yStart, btnW, btnH);
            btnCategories.Click += BtnCategories_Click;

            btnProducts = CrearBoton("📦  Productos", "Catálogo de productos y precios",
                Color.FromArgb(166, 227, 161), xStart + btnW + gapX, yStart, btnW, btnH);
            btnProducts.Click += BtnProducts_Click;

            btnCustomers = CrearBoton("👥  Clientes", "Administración de clientes",
                Color.FromArgb(203, 166, 247), xStart + 2 * (btnW + gapX), yStart, btnW, btnH);
            btnCustomers.Click += BtnCustomers_Click;

            btnUsers = CrearBoton("👤  Usuarios", "Usuarios del sistema y roles",
                Color.FromArgb(148, 226, 213), xStart, yStart + btnH + gapY, btnW, btnH);
            btnUsers.Click += BtnUsers_Click;

            btnOrders = CrearBoton("📋  Órdenes", "Órdenes de venta y seguimiento",
                Color.FromArgb(249, 226, 175), xStart + btnW + gapX, yStart + btnH + gapY, btnW, btnH);
            btnOrders.Click += BtnOrders_Click;

            btnOrderDetails = CrearBoton("📝  Detalles", "Detalle de productos por orden",
                Color.FromArgb(243, 139, 168), xStart + 2 * (btnW + gapX), yStart + btnH + gapY, btnW, btnH);
            btnOrderDetails.Click += BtnOrderDetails_Click;

            btnPayments = CrearBoton("💰  Pagos", "Registro de pagos y métodos",
                Color.FromArgb(137, 180, 250), xStart, yStart + 2 * (btnH + gapY), btnW, btnH);
            btnPayments.Click += BtnPayments_Click;

            btnProductSales = CrearBoton("📊  Ventas x Producto", "Reporte de ventas por producto",
                Color.FromArgb(166, 227, 161), xStart + btnW + gapX, yStart + 2 * (btnH + gapY), btnW, btnH);
            btnProductSales.Click += BtnProductSales_Click;

            btnSalesSummary = CrearBoton("📈  Resumen Ventas", "Resumen global de ventas",
                Color.FromArgb(203, 166, 247), xStart + 2 * (btnW + gapX), yStart + 2 * (btnH + gapY), btnW, btnH);
            btnSalesSummary.Click += BtnSalesSummary_Click;

            // ENSAMBLAR
            Controls.AddRange(new Control[] {
                pnlHeader, pnlFooter,
                btnCategories, btnProducts, btnCustomers,
                btnUsers, btnOrders, btnOrderDetails,
                btnPayments, btnProductSales, btnSalesSummary
            });

            pnlHeader.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static Button CrearBoton(string titulo, string desc, Color color, int x, int y, int w, int h)
        {
            return new Button
            {
                Text = $"{titulo}\n{desc}",
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(
                    Math.Max(0, color.R - 25),
                    Math.Max(0, color.G - 25),
                    Math.Max(0, color.B - 25)) },
                BackColor = color,
                ForeColor = Color.FromArgb(24, 24, 37),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(x, y),
                Size = new Size(w, h),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter,
                UseVisualStyleBackColor = false,
            };
        }

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlFooter;
        private Label lblFooter;
        private Button btnCategories;
        private Button btnProducts;
        private Button btnCustomers;
        private Button btnUsers;
        private Button btnOrders;
        private Button btnOrderDetails;
        private Button btnPayments;
        private Button btnProductSales;
        private Button btnSalesSummary;
    }
}
```

## 5. MainForm.cs — Sin cambios

**Archivo**: `SalesMgrSystem.UI\MainForm.cs`

El código-behind actual es correcto. Los 9 event handlers `BtnCategories_Click`, `BtnProducts_Click`, etc. ya están definidos y funcionan con DI.

---

## Resumen de archivos a modificar

| Archivo | Acción |
|---------|--------|
| `SalesMgrSystem.UI\OrderDetailForm.cs` | Líneas 213-214: agregar `?? (object?)0` |
| `SalesMgrSystem.UI\UserForm.cs` | Constructor: mover `CargarUsuarios()` al evento `Load` |
| `SalesMgrSystem.UI\MainForm.Designer.cs` | Reescribir completo con nuevo diseño profesional |

## Verificación post-cambios

```powershell
dotnet build
dotnet test
```
