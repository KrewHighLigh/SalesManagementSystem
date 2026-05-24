using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Tests.Infrastructure;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.Tests.Services;

public class VwProductSaleServiceTest
{
    [Fact]
    public async Task Buscar_CuandoExisteVwProductSale_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.VwProductSales.Add(new VwProductSale()
            {
                ProductName = "Laptop",
                CategoryName = "Tecnologia",
                TotalSold = 5,
                TotalRevenue = 250000,
                StockQuantity = 10
            });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VwProductSaleService(context);

        // Act
        var result = await service.Buscar("Laptop");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Laptop", result!.ProductName);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteVwProductSale_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());
        var service = new VwProductSaleService(context);

        // Act
        var result = await service.Buscar("NoExiste");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Existe_CuandoExisteVwProductSale_RetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.VwProductSales.Add(new VwProductSale()
            {
                ProductName = "Monitor",
                CategoryName = "Tecnologia",
                TotalSold = 3,
                TotalRevenue = 90000,
                StockQuantity = 5
            });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VwProductSaleService(context);

        // Act
        var result = await service.Existe("Monitor");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Existe_CuandoNoExisteVwProductSale_RetornaFalse()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());
        var service = new VwProductSaleService(context);

        // Act
        var result = await service.Existe("NoExiste");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task GetList_CuandoHayVentas_RetornaLista()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.VwProductSales.AddRange(
                new VwProductSale()
                {
                    ProductName = "Mouse",
                    CategoryName = "Accesorios",
                    TotalSold = 10,
                    TotalRevenue = 10000,
                    StockQuantity = 15
                },
                new VwProductSale()
                {
                    ProductName = "Teclado",
                    CategoryName = "Accesorios",
                    TotalSold = 8,
                    TotalRevenue = 16000,
                    StockQuantity = 20
                });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new VwProductSaleService(context);

        // Act
        var result = await service.GetList(v => v.CategoryName == "Accesorios");

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task Guardar_SiempreRetornaFalse()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());
        var service = new VwProductSaleService(context);

        // Act
        var result = await service.Guardar(new VwProductSale()
        {
            ProductName = "Test",
            CategoryName = "Test",
            StockQuantity = 1
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
        var service = new VwProductSaleService(context);

        // Act
        var result = await service.Eliminar("cualquierValor");

        // Assert
        Assert.False(result);
    }
}
