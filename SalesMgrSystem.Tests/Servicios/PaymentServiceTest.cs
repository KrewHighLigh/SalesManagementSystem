using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Tests.Infrastructure;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.Tests.Services;

public class PaymentServiceTest
{
    [Fact]
    public async Task Buscar_CuandoExistePayment_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        var payment = new Payment()
        {
            PaymentId = 1,
            Amount = 1000,
            PaymentMethod = "Efectivo"
        };

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Payments.Add(payment);
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new PaymentService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1000, result!.Amount);
    }

    [Fact]
    public async Task Buscar_CuandoNoExistePayment_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new PaymentService(context);

        // Act
        var result = await service.Buscar(100);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Guardar_CuandoPaymentNoExiste_InsertaYRetornaTrue()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new PaymentService(context);

        var payment = new Payment()
        {
            PaymentId = 2,
            Amount = 2000,
            PaymentMethod = "Tarjeta"
        };

        // Act
        var result = await service.Guardar(payment);

        // Assert
        Assert.True(result);

        var saved = await context.Payments
            .FirstOrDefaultAsync(p => p.PaymentId == 2);

        Assert.NotNull(saved);
        Assert.Equal("Tarjeta", saved!.PaymentMethod);
    }

    [Fact]
    public async Task Guardar_CuandoPaymentExiste_ModificaYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Payments.Add(new Payment()
            {
                PaymentId = 3,
                Amount = 500,
                PaymentMethod = "Efectivo"
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new PaymentService(context);

        var actualizado = new Payment()
        {
            PaymentId = 3,
            Amount = 500,
            PaymentMethod = "Transferencia"
        };

        // Act
        var result = await service.Guardar(actualizado);

        // Assert
        Assert.True(result);

        var saved = await context.Payments
            .FirstOrDefaultAsync(p => p.PaymentId == 3);

        Assert.NotNull(saved);
        Assert.Equal("Transferencia", saved!.PaymentMethod);
    }

    [Fact]
    public async Task Existe_CuandoPaymentExiste_RetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Payments.Add(new Payment()
            {
                PaymentId = 4,
                Amount = 300
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new PaymentService(context);

        // Act
        var result = await service.Existe(4);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Eliminar_CuandoExistePayment_LoBorraYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Payments.Add(new Payment()
            {
                PaymentId = 5,
                Amount = 700
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new PaymentService(context);

        // Act
        var result = await service.Eliminar(5);

        // Assert
        Assert.True(result);

        var deleted = await context.Payments.FindAsync(5);

        Assert.Null(deleted);
    }

    [Fact]
    public async Task GetList_CuandoHayPayments_RetornaLista()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Payments.AddRange(
                new Payment()
                {
                    PaymentId = 6,
                    Amount = 100
                },
                new Payment()
                {
                    PaymentId = 7,
                    Amount = 100
                });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new PaymentService(context);

        // Act
        var result = await service.GetList(p =>
            p.Amount == 100);

        // Assert
        Assert.Equal(2, result.Count);
    }
}