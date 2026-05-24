using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Tests.Infrastructure;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.Tests.Services;

public class CustomerServiceTest
{
    [Fact]
    public async Task Buscar_CuandoExisteCustomer_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        var customer = new Customer()
        {
            CustomerId = 1,
            FirstName = "Juan",
            LastName = "Perez",
            Email = "juan@gmail.com"
        };

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Customers.Add(customer);
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new CustomerService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Juan", result!.FirstName);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteCustomer_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new CustomerService(context);

        // Act
        var result = await service.Buscar(100);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Guardar_CuandoCustomerNoExiste_InsertaYRetornaTrue()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new CustomerService(context);

        var customer = new Customer()
        {
            CustomerId = 2,
            FirstName = "Maria",
            LastName = "Lopez",
            Email = "maria@gmail.com"
        };

        // Act
        var result = await service.Guardar(customer);

        // Assert
        Assert.True(result);

        var saved = await context.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == 2);

        Assert.NotNull(saved);
        Assert.Equal("Maria", saved!.FirstName);
    }

    [Fact]
    public async Task Guardar_CuandoCustomerExiste_ModificaYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Customers.Add(new Customer()
            {
                CustomerId = 3,
                FirstName = "Pedro",
                LastName = "Martinez"
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new CustomerService(context);

        var actualizado = new Customer()
        {
            CustomerId = 3,
            FirstName = "Pedro Modificado",
            LastName = "Martinez"
        };

        // Act
        var result = await service.Guardar(actualizado);

        // Assert
        Assert.True(result);

        var saved = await context.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == 3);

        Assert.NotNull(saved);
        Assert.Equal("Pedro Modificado", saved!.FirstName);
    }

    [Fact]
    public async Task Existe_CuandoCustomerExiste_RetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Customers.Add(new Customer()
            {
                CustomerId = 4,
                FirstName = "Carlos",
                LastName = "Gomez"
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new CustomerService(context);

        // Act
        var result = await service.Existe(4);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteCustomer_LoBorraYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Customers.Add(new Customer()
            {
                CustomerId = 5,
                FirstName = "Luis",
                LastName = "Fernandez"
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new CustomerService(context);

        // Act
        var result = await service.Eliminar(5);

        // Assert
        Assert.True(result);

        var deleted = await context.Customers.FindAsync(5);

        Assert.Null(deleted);
    }

    [Fact]
    public async Task GetList_CuandoHayCustomers_RetornaLista()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Customers.AddRange(
                new Customer()
                {
                    CustomerId = 6,
                    FirstName = "Ana",
                    LastName = "Lopez"
                },
                new Customer()
                {
                    CustomerId = 7,
                    FirstName = "Elena",
                    LastName = "Perez"
                });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new CustomerService(context);

        // Act
        var result = await service.GetList(c =>
            c.FirstName.Contains("a"));

        // Assert
        Assert.Equal(2, result.Count);
    }
}