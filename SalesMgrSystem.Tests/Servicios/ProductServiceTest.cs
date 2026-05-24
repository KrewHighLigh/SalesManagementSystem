using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Tests.Infrastructure;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.Tests.Services;

public class ProductServiceTest
{
    [Fact]
    public async Task Buscar_CuandoExisteProduct_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        var product = new Product()
        {
            ProductId = 1,
            ProductName = "Laptop",
            UnitPrice = 50000,
            StockQuantity = 10
        };

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Products.Add(product);
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new ProductService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Laptop", result!.ProductName);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteProduct_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new ProductService(context);

        // Act
        var result = await service.Buscar(100);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Guardar_CuandoProductNoExiste_InsertaYRetornaTrue()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new ProductService(context);

        var product = new Product()
        {
            ProductId = 2,
            ProductName = "Mouse",
            UnitPrice = 1000,
            StockQuantity = 20
        };

        // Act
        var result = await service.Guardar(product);

        // Assert
        Assert.True(result);

        var saved = await context.Products
            .FirstOrDefaultAsync(p => p.ProductId == 2);

        Assert.NotNull(saved);
        Assert.Equal("Mouse", saved!.ProductName);
    }

    [Fact]
    public async Task Guardar_CuandoProductExiste_ModificaYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Products.Add(new Product()
            {
                ProductId = 3,
                ProductName = "Teclado",
                UnitPrice = 1500,
                StockQuantity = 5
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new ProductService(context);

        var actualizado = new Product()
        {
            ProductId = 3,
            ProductName = "Teclado Gamer",
            UnitPrice = 2000,
            StockQuantity = 8
        };

        // Act
        var result = await service.Guardar(actualizado);

        // Assert
        Assert.True(result);

        var saved = await context.Products
            .FirstOrDefaultAsync(p => p.ProductId == 3);

        Assert.NotNull(saved);
        Assert.Equal("Teclado Gamer", saved!.ProductName);
    }

    [Fact]
    public async Task Existe_CuandoProductExiste_RetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Products.Add(new Product()
            {
                ProductId = 4,
                ProductName = "Monitor",
                UnitPrice = 12000,
                StockQuantity = 3
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new ProductService(context);

        // Act
        var result = await service.Existe(4);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteProduct_LoBorraYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Products.Add(new Product()
            {
                ProductId = 5,
                ProductName = "Tablet",
                UnitPrice = 25000,
                StockQuantity = 2
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new ProductService(context);

        // Act
        var result = await service.Eliminar(5);

        // Assert
        Assert.True(result);

        var deleted = await context.Products.FindAsync(5);

        Assert.Null(deleted);
    }

    [Fact]
    public async Task GetList_CuandoHayProducts_RetornaLista()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Products.AddRange(
                new Product()
                {
                    ProductId = 6,
                    ProductName = "Laptop HP",
                    UnitPrice = 50000,
                    StockQuantity = 5
                },
                new Product()
                {
                    ProductId = 7,
                    ProductName = "Laptop Dell",
                    UnitPrice = 60000,
                    StockQuantity = 4
                });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new ProductService(context);

        // Act
        var result = await service.GetList(p =>
            p.ProductName.Contains("Laptop"));

        // Assert
        Assert.Equal(2, result.Count);
    }
}