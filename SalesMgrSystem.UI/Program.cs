using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Services;
using SalesMgrSystem.Ui.Forms;

namespace SalesMgrSystem.UI;

internal static class Program
{
    public static ServiceProvider ServiceProvider { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        Application.Run(ServiceProvider.GetRequiredService<MainForm>());
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        var connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["SalesMgrConnection"].ConnectionString;

        services.AddDbContext<SalesMgrContext>(options =>
            options.UseSqlServer(
                connectionString,
                sql => sql.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null)),
            ServiceLifetime.Transient);

        // Forms
        services.AddTransient<MainForm>();
        services.AddTransient<CategoryForm>();
        services.AddTransient<CustomerForm>();
        services.AddTransient<ProductForm>();
        services.AddTransient<OrderForm>();
        services.AddTransient<PaymentForm>();
        services.AddTransient<UserForm>();

        // Services
        services.AddTransient<CategoryService>();
        services.AddTransient<CustomerService>();
        services.AddTransient<OrderService>();
        services.AddTransient<OrderDetailService>();
        services.AddTransient<PaymentService>();
        services.AddTransient<ProductService>();
        services.AddTransient<UserService>();
    }
}