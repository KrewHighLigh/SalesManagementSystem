# SalesManagementSystemSGV

.NET 10 WinForms + EF Core + SQL Server. Solución de 3 proyectos: `Data` (classlib), `UI` (WinForms), `Tests` (xUnit).

## Comandos

```powershell
dotnet build               # compilar todo
dotnet test                # ejecutar 63 tests xUnit (InMemory EF Core)
dotnet build -c Release    # CI-style
dotnet test -c Release --no-build --verbosity normal --logger "trx"
```

## Arquitectura

- **Data** (`SalesMgrSystem.Data`): Models, EF Core `SalesMgrContext`, Servicios (`IService<T,int>` de `Aplicada1.Core`)
- **UI** (`SalesMgrSystem.UI`): WinForms, entrypoint `Program.cs` con DI (Microsoft.Extensions.DependencyInjection)
- **Tests** (`SalesMgrSystem.Tests`): xUnit + `TestDbContextFactory` (InMemory, GUID por test)

## Reglas importantes

- **NO duplicar servicios en UI**: los servicios viven solo en `Data/Services`. Las Forms usan DI via `Program.ServiceProvider.GetRequiredService<T>()`.
- **`SalesMgrSystem.UI/Services/` fue eliminado** — contenía copias exactas de Data.Services.
- **Conexión**: via `App.config` (`SalesMgrConnection`). `SalesMgrContext.OnConfiguring()` tiene fallback solo si no está configurado vía DI.
- **Views**: `VwProductSale` y `VwSalesSummary` son SQL views (`vw_ProductSales`, `vw_SalesSummary`). Tests las convierten en tablas con `HasKey()`.

## Tests

- Cada test crea DB aislada: `TestDbContextFactory.NewDatabaseName()` + `CreateContext(name)`
- Seed en un bloque `await using`, assert en otro
- 63 tests, todos con InMemory provider

## CI/CD

- **CI** (push/PR a main): `windows-latest`, .NET 10.x prerelease → restore → build Release → test con TRX → reporte
- **CD** (tag `v*`): publica `SalesMgrSystem.UI/SalesMgrSystem.UI.csproj` → win-x64 → single-file → release ZIP

## Errores conocidos (ya corregidos)

| Problema | Fix |
|----------|-----|
| Servicios duplicados en `UI/Services` (9 archivos) + stub `SalesMgrSystemContext.cs` | Eliminados |
| `CategoryForm.cs` creaba servicios con `new` ignorando DI | Cambiado a `Program.ServiceProvider.GetRequiredService()` |
| `release.yml` apuntaba a `AdventureAdmin.Ui` inexistente | Corregido a `SalesMgrSystem.UI/SalesMgrSystem.UI.csproj` |
| Clase `ProductosForm` no coincidía con nombre de archivo `ProductForm.cs` | Renombrada a `ProductForm` |
| Connection string hardcodeada en `OnConfiguring()` sin check | Agregado `if (!optionsBuilder.IsConfigured)` |
| Faltaba `App.config` con `SalesMgrConnection` | Creado |
| `UserService.cs`: `Existe()` private, sin `AsNoTracking()` | Estandarizado como los demás servicios |
| 7 forms vacíos (Customer, Order, OrderDetail, Payment, User, VwProductSale, VwSalesSummary) | Implementados CRUD completo |
| `MainForm.cs` sin navegación (6 botones genéricos) | Rediseñado con dashboard a 9 módulos |
| Faltaban registros DI para varios forms/services | Completados en `Program.cs` |
| Directorio `Forms/` vacío | Eliminado |
| `MainForm.cs` eventos `Load` con `_ =` en 4 forms (Customer, Order, OrderDetail, Payment) | Movido a evento `Load` + suscripción en Designer |
| `VwSalesSummaryForm.cs` usaba field `_service` inconsistente | Cambiado a `static Servicio()` helper |
| `MainForm.cs` botones planos → diseño oscuro premium | Rediseñado con cards Panel, stripe superior, hover efecto |

## Scaffolding (referencia)

```powershell
Scaffold-DbContext "Data Source=.\SQLEXPRESS;Initial Catalog=SalesManagementDB;Integrated Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -Context SalesMgrContext -ContextDir Context -OutputDir Models -DataAnnotations -Force
```

## Convenciones

- Servicios: constructor primario `class FooService(SalesMgrContext ctx) : IService<Foo, int>`
- Métodos en español: `Buscar`, `Guardar`, `Eliminar`, `Existe`, `Modificar`
- Forms: `async void` para eventos, `async Task` para métodos internos
- Todas las Forms acceden servicios via `static FooService Servicio() => Program.ServiceProvider.GetRequiredService<FooService>()`
- **NUNCA** `_ = CargarXxx()` en el constructor — usar evento `Load` para carga asíncrona
- **NUNCA** campos `readonly` para servicios — usar método `static` helper
