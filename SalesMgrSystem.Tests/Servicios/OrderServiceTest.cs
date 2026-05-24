using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Tests.Infrastructure;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.Tests.Services;

public class OrderServiceTest
{
    [Fact]
    public async Task Buscar_CuandoExisteOrder_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        var order = new Order()
        {
            OrderId = 1,
            TotalAmount = 1000,
            Status = "Pendiente"
        };

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Orders.Add(order);
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new OrderService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1000, result!.TotalAmount);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteOrder_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new OrderService(context);

        // Act
        var result = await service.Buscar(100);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Guardar_CuandoOrderNoExiste_InsertaYRetornaTrue()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new OrderService(context);

        var order = new Order()
        {
            OrderId = 2,
            TotalAmount = 2000,
            Status = "Completada"
        };

        // Act
        var result = await service.Guardar(order);

        // Assert
        Assert.True(result);

        var saved = await context.Orders
            .FirstOrDefaultAsync(o => o.OrderId == 2);

        Assert.NotNull(saved);
        Assert.Equal("Completada", saved!.Status);
    }

    [Fact]
    public async Task Guardar_CuandoOrderExiste_ModificaYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Orders.Add(new Order()
            {
                OrderId = 3,
                TotalAmount = 1500,
                Status = "Pendiente"
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new OrderService(context);

        var actualizado = new Order()
        {
            OrderId = 3,
            TotalAmount = 1500,
            Status = "Entregada"
        };

        // Act
        var result = await service.Guardar(actualizado);

        // Assert
        Assert.True(result);

        var saved = await context.Orders
            .FirstOrDefaultAsync(o => o.OrderId == 3);

        Assert.NotNull(saved);
        Assert.Equal("Entregada", saved!.Status);
    }

    [Fact]
    public async Task Existe_CuandoOrderExiste_RetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Orders.Add(new Order()
            {
                OrderId = 4,
                TotalAmount = 500
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new OrderService(context);

        // Act
        var result = await service.Existe(4);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteOrder_LaBorraYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Orders.Add(new Order()
            {
                OrderId = 5,
                TotalAmount = 700
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new OrderService(context);

        // Act
        var result = await service.Eliminar(5);

        // Assert
        Assert.True(result);

        var deleted = await context.Orders.FindAsync(5);

        Assert.Null(deleted);
    }

    [Fact]
    public async Task GetList_CuandoHayOrders_RetornaLista()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Orders.AddRange(
                new Order()
                {
                    OrderId = 6,
                    Status = "Pendiente"
                },
                new Order()
                {
                    OrderId = 7,
                    Status = "Pendiente"
                });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new OrderService(context);

        // Act
        var result = await service.GetList(o =>
            o.Status == "Pendiente");

        // Assert
        Assert.Equal(2, result.Count);
    }
}