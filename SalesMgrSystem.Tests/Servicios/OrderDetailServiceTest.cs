using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Tests.Infrastructure;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.Tests.Services;

public class OrderDetailServiceTest
{
    [Fact]
    public async Task Buscar_CuandoExisteOrderDetail_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        var detail = new OrderDetail()
        {
            OrderDetailId = 1,
            Quantity = 2,
            UnitPrice = 100,
            Subtotal = 200
        };

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.OrderDetails.Add(detail);
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new OrderDetailService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result!.Quantity);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteOrderDetail_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new OrderDetailService(context);

        // Act
        var result = await service.Buscar(100);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Guardar_CuandoOrderDetailNoExiste_InsertaYRetornaTrue()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new OrderDetailService(context);

        var detail = new OrderDetail()
        {
            OrderDetailId = 2,
            Quantity = 3,
            UnitPrice = 150,
            Subtotal = 450
        };

        // Act
        var result = await service.Guardar(detail);

        // Assert
        Assert.True(result);

        var saved = await context.OrderDetails
            .FirstOrDefaultAsync(o => o.OrderDetailId == 2);

        Assert.NotNull(saved);
        Assert.Equal(450, saved!.Subtotal);
    }

    [Fact]
    public async Task Guardar_CuandoOrderDetailExiste_ModificaYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.OrderDetails.Add(new OrderDetail()
            {
                OrderDetailId = 3,
                Quantity = 1,
                UnitPrice = 100,
                Subtotal = 100
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new OrderDetailService(context);

        var actualizado = new OrderDetail()
        {
            OrderDetailId = 3,
            Quantity = 5,
            UnitPrice = 100,
            Subtotal = 500
        };

        // Act
        var result = await service.Guardar(actualizado);

        // Assert
        Assert.True(result);

        var saved = await context.OrderDetails
            .FirstOrDefaultAsync(o => o.OrderDetailId == 3);

        Assert.NotNull(saved);
        Assert.Equal(5, saved!.Quantity);
    }

    [Fact]
    public async Task Existe_CuandoOrderDetailExiste_RetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.OrderDetails.Add(new OrderDetail()
            {
                OrderDetailId = 4,
                Quantity = 2,
                UnitPrice = 50,
                Subtotal = 100
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new OrderDetailService(context);

        // Act
        var result = await service.Existe(4);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteOrderDetail_LoBorraYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.OrderDetails.Add(new OrderDetail()
            {
                OrderDetailId = 5,
                Quantity = 1,
                UnitPrice = 200,
                Subtotal = 200
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new OrderDetailService(context);

        // Act
        var result = await service.Eliminar(5);

        // Assert
        Assert.True(result);

        var deleted = await context.OrderDetails.FindAsync(5);

        Assert.Null(deleted);
    }

    [Fact]
    public async Task GetList_CuandoHayOrderDetails_RetornaLista()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.OrderDetails.AddRange(
                new OrderDetail()
                {
                    OrderDetailId = 6,
                    Quantity = 2,
                    UnitPrice = 100,
                    Subtotal = 200
                },
                new OrderDetail()
                {
                    OrderDetailId = 7,
                    Quantity = 2,
                    UnitPrice = 150,
                    Subtotal = 300
                });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new OrderDetailService(context);

        // Act
        var result = await service.GetList(o =>
            o.Quantity == 2);

        // Assert
        Assert.Equal(2, result.Count);
    }
}