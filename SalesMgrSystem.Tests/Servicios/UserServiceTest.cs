using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Tests.Infrastructure;
using SalesMgrSystem.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace SalesMgrSystem.Tests.Servicios;

public class UserServiceTest
{
    [Fact]
    public async Task Buscar_CuandoExisteUsuario_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Users.Add(new User()
            {
                UserId = 1,
                Username = "user1",
                PasswordHash = "password1",
                FullName = "User One",
                Email = "user1@mail.com"
            });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new UserService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("user1", result!.Username);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteUsuario_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());
        var service = new UserService(context);

        // Act
        var result = await service.Buscar(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Guardar_CuandoUsuarioNoExiste_InsertaYRetornaTrue()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());
        var service = new UserService(context);

        var user = new User()
        {
            UserId = 2,
            Username = "user2",
            PasswordHash = "pass2",
            FullName = "User Two",
            Email = "user2@mail.com"
        };

        // Act
        var result = await service.Guardar(user);

        // Assert
        Assert.True(result);
        var saved = await context.Users.FirstOrDefaultAsync(u => u.UserId == 2);
        Assert.NotNull(saved);
        Assert.Equal("user2", saved!.Username);
    }

    [Fact]
    public async Task Guardar_CuandoUsuarioExiste_ModificaYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Users.Add(new User()
            {
                UserId = 3,
                Username = "user3",
                PasswordHash = "pass3",
                FullName = "User Three",
                Email = "user3@mail.com"
            });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new UserService(context);

        var actualizado = new User()
        {
            UserId = 3,
            Username = "user3_modificado",
            PasswordHash = "pass3",
            FullName = "User Three Modified",
            Email = "user3mod@mail.com"
        };

        // Act
        var result = await service.Guardar(actualizado);

        // Assert
        Assert.True(result);
        var saved = await context.Users.FirstOrDefaultAsync(u => u.UserId == 3);
        Assert.NotNull(saved);
        Assert.Equal("user3_modificado", saved!.Username);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteUsuario_LoBorraYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Users.Add(new User()
            {
                UserId = 4,
                Username = "user4",
                PasswordHash = "pass4",
                FullName = "User Four",
                Email = "user4@mail.com"
            });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new UserService(context);

        // Act
        var result = await service.Eliminar(4);

        // Assert
        Assert.True(result);
        var deleted = await context.Users.FindAsync(4);
        Assert.Null(deleted);
    }

    [Fact]
    public async Task Eliminar_CuandoNoExisteUsuario_RetornaFalse()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());
        var service = new UserService(context);

        // Act
        var result = await service.Eliminar(999);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task GetList_CuandoHayUsuarios_RetornaLista()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Users.AddRange(
                new User()
                {
                    UserId = 5,
                    Username = "admin1",
                    PasswordHash = "pass5",
                    FullName = "Admin One",
                    Email = "admin1@mail.com",
                    Role = "Admin"
                },
                new User()
                {
                    UserId = 6,
                    Username = "admin2",
                    PasswordHash = "pass6",
                    FullName = "Admin Two",
                    Email = "admin2@mail.com",
                    Role = "Admin"
                });
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new UserService(context);

        // Act
        var result = await service.GetList(u => u.Role == "Admin");

        // Assert
        Assert.Equal(2, result.Count);
    }
}
