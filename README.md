# SalesManagementSystemSGV

Sistema de gestión de ventas empresarial desarrollado en **.NET 10 WinForms** con **Entity Framework Core** y **SQL Server**. Arquitectura en 3 proyectos con inyección de dependencias y pruebas unitarias.

---

## 🏗️ Arquitectura

```
SalesManagementSystemSGV/
├── SalesMgrSystem.Data/          # Capa de datos (classlib)
│   ├── Context/
│   │   └── SalesMgrContext.cs     # DbContext de EF Core
│   ├── Models/                    # Entidades del modelo
│   ├── Services/                  # Servicios CRUD (IService<T, int>)
│   └── ...
├── SalesMgrSystem.UI/            # Interfaz de usuario (WinForms)
│   ├── Program.cs                 # Entrypoint con DI
│   ├── MainForm.cs                # Dashboard principal (9 módulos)
│   ├── App.config                 # Cadena de conexión
│   └── Forms/                     # 9 formularios CRUD/vistas
├── SalesMgrSystem.Tests/         # Pruebas unitarias (xUnit)
│   ├── TestDbContextFactory.cs    # Factory para DB InMemory
│   └── ...
└── AGENTS.md                     # Convenciones para agentes de IA
```

| Proyecto | Framework | Propósito |
|----------|-----------|-----------|
| `SalesMgrSystem.Data` | `net10.0` | Modelos, DbContext, servicios CRUD |
| `SalesMgrSystem.UI` | `net10.0-windows` | WinForms, DI, entrypoint |
| `SalesMgrSystem.Tests` | `net10.0-windows` | Tests unitarios xUnit |

---

## ⚙️ Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (prerelease)
- SQL Server Express (LocalDB o instancia completa)
- Visual Studio 2022 o superior (recomendado)

---

## 🚀 Inicio rápido

### 1. Clonar y compilar

```powershell
git clone <repo-url>
cd SalesManagementSystemSGV
dotnet build
```

### 2. Configurar la base de datos

La cadena de conexión está en `SalesMgrSystem.UI/App.config`:

```xml
<connectionStrings>
  <add name="SalesMgrConnection"
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=SalesManagementDB;...;TrustServerCertificate=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Ajusta `Data Source` según tu instancia de SQL Server.

### 3. Crear la base de datos

Ejecuta el script SQL (si existe) o usa migrations de EF Core:

```powershell
dotnet ef database update --project SalesMgrSystem.Data
```

O directamente desde el Package Manager Console:

```powershell
Update-Database
```

### 4. Ejecutar

```powershell
dotnet run --project SalesMgrSystem.UI
```

---

## 🧪 Pruebas

```powershell
dotnet test                    # 63 tests (InMemory EF Core)
dotnet test -c Release --no-build --verbosity normal --logger "trx"
```

Cada test crea su propia base de datos InMemory aislada (GUID único) para evitar efectos colaterales. Usa `TestDbContextFactory.NewDatabaseName()` + `CreateContext(name)`.

---

## 📦 Módulos del sistema

| # | Módulo | Formulario | Tipo |
|---|--------|-----------|------|
| 1 | 📂 Categorías | `CategoryForm` | CRUD completo |
| 2 | 📦 Productos | `ProductForm` | CRUD completo |
| 3 | 👥 Clientes | `CustomerForm` | CRUD completo |
| 4 | 👤 Usuarios | `UserForm` | CRUD completo |
| 5 | 📋 Órdenes | `OrderForm` | CRUD completo |
| 6 | 📝 Detalles | `OrderDetailForm` | CRUD completo |
| 7 | 💰 Pagos | `PaymentForm` | CRUD completo |
| 8 | 📊 Ventas x Producto | `VwProductSaleForm` | Vista (read-only) |
| 9 | 📈 Resumen Ventas | `VwSalesSummaryForm` | Vista (read-only) |

---

## 🖥️ Diseño del MainForm

Dashboard oscuro premium con 9 cards en cuadrícula 3×3:

```
┌─────────────────────────────────────────────────────────────┐
│  Sales Management System                                    │
│  Panel de Control — Gestión de Ventas                      │
│  ═══════════════════ (línea acento azul) ═════════════════  │
│                                                              │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐                  │
│  │ ██ azul  │  │ ██ verde │  │ ██ purp.│                  │
│  │ 📂 Cat.. │  │ 📦 Prod..│  │ 👥 Cli.. │                  │
│  └──────────┘  └──────────┘  └──────────┘                  │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐                  │
│  │ ██ l.azu │  │ ██ gold  │  │ ██ pink  │                  │
│  │ 👤 Usu.. │  │ 📋 Ord.. │  │ 📝 Det.. │                  │
│  └──────────┘  └──────────┘  └──────────┘                  │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐                  │
│  │ ██ cyan  │  │ ██ orng  │  │ ██ red   │                  │
│  │ 💰 Pagos │  │ 📊 Vtas x│  │ 📈 Res.. │                  │
│  └──────────┘  └──────────┘  └──────────┘                  │
│                                                              │
│  v1.0 · SalesMgrSystem · Sales Management System           │
└─────────────────────────────────────────────────────────────┘
```

**Características visuales:**
- Fondo oscuro `#0D1117` (tipo GitHub dark)
- Cards con borde `#30363D` que brilla con color acento al hover (GLOW)
- Stripe superior de 3px con color distintivo por módulo
- Header con línea de acento azul `#58A6FF`

---

## 🧱 Convenciones de código

### Servicios
- Constructor primario: `class FooService(SalesMgrContext ctx) : IService<Foo, int>`
- Métodos en español: `Buscar()`, `Guardar()`, `Eliminar()`, `Existe()`, `Modificar()`
- Todos con `AsNoTracking()` en consultas de lectura

### Formularios
- Acceso a servicios via **static helper**: `static FooService Servicio() => Program.ServiceProvider.GetRequiredService<FooService>()`
- `async void` para eventos, `async Task` para métodos internos
- **NUNCA** `_ = CargarXxx()` en el constructor — usar evento `Load`
- **NUNCA** campos `readonly` para servicios — usar método `static`

### Inyección de dependencias
Los servicios viven solo en `Data/Services/`. `Program.cs` registra todo:

```csharp
services.AddTransient<SalesMgrContext>(...)
services.AddTransient<MainForm>();
services.AddTransient<CategoryService>();
// ... todos los forms y servicios
```

---

## 🔁 CI/CD

### CI (push/PR a `main`)
`.github/workflows/ci.yml`
- `windows-latest` + .NET 10.x prerelease
- `dotnet restore` → `dotnet build -c Release` → `dotnet test` con TRX → reporte

### CD (tag `v*`)
`.github/workflows/release.yml`
- Publica `SalesMgrSystem.UI/SalesMgrSystem.UI.csproj`
- Target: `win-x64` → single-file → release ZIP

---

## 🛠️ Scaffolding (base de datos existente)

```powershell
Scaffold-DbContext "Data Source=.\SQLEXPRESS;Initial Catalog=SalesManagementDB;Integrated Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -Context SalesMgrContext -ContextDir Context -OutputDir Models -DataAnnotations -Force
```

---

## 📄 Licencia

Distribuido bajo licencia MIT. Ver `LICENSE.txt`.
