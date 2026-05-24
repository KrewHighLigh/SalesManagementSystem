using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Tests.Infrastructure;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.Tests.Services;

public class VwSalesSummaryServiceTest
{
    [Fact]
    public async Task Buscar_CuandoExisteVwSalesSummary_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.VwSalesSummaries.Add(new VwSalesSummary()
            {
                OrderId = 1,
                CustomerName = "Juan Perez",
                SalesRep = "Carlos Lopez",
                TotalAmount = 5000,
                Status = "Completada",
                ItemsCount = 3
            });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VwSalesSummaryService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result!.OrderId);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteVwSalesSummary_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());
        var service = new VwSalesSummaryService(context);

        // Act
        var result = await service.Buscar(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Existe_CuandoExisteVwSalesSummary_RetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.VwSalesSummaries.Add(new VwSalesSummary()
            {
                OrderId = 2,
                CustomerName = "Maria Lopez",
                SalesRep = "Pedro",
                TotalAmount = 1000,
                Status = "Pendiente",
                ItemsCount = 2
            });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VwSalesSummaryService(context);

        // Act
        var result = await service.Existe(2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Existe_CuandoNoExisteVwSalesSummary_RetornaFalse()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());
        var service = new VwSalesSummaryService(context);

        // Act
        var result = await service.Existe(999);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task GetList_CuandoHaySalesSummary_RetornaLista()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.VwSalesSummaries.AddRange(
                new VwSalesSummary()
                {
                    OrderId = 3,
                    CustomerName = "Ana Torres",
                    SalesRep = "Pedro",
                    TotalAmount = 2000,
                    Status = "Pendiente",
                    ItemsCount = 4
                },
                new VwSalesSummary()
                {
                    OrderId = 4,
                    CustomerName = "Jose Ramirez",
                    SalesRep = "Pedro",
                    TotalAmount = 3000,
                    Status = "Pendiente",
                    ItemsCount = 5
                });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VwSalesSummaryService(context);

        // Act
        var result = await service.GetList(v => v.Status == "Pendiente");

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task Guardar_SiempreRetornaFalse()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());
        var service = new VwSalesSummaryService(context);

        // Act
        var result = await service.Guardar(new VwSalesSummary()
        {
            OrderId = 1,
            CustomerName = "Test",
            SalesRep = "Test"
        });

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task Eliminar_SiempreRetornaFalse()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());
        var service = new VwSalesSummaryService(context);

        // Act
        var result = await service.Eliminar(1);

        // Assert
        Assert.False(result);
    }
}
