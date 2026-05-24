using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Models;
using SalesMgrSystem.Tests.Infrastructure;
using SalesMgrSystem.Data.Services;

namespace SalesMgrSystem.Tests.Services;

public class CategoryServiceTest
{
    [Fact]
    public async Task Buscar_CuandoExisteCategory_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        var category = new Category()
        {
            CategoryId = 1,
            CategoryName = "Tecnologia",
            Description = "Categoria de tecnologia"
        };

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Categories.Add(category);
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new CategoryService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Tecnologia", result!.CategoryName);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteCategory_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new CategoryService(context);

        // Act
        var result = await service.Buscar(100);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Guardar_CuandoCategoryNoExiste_InsertaYRetornaTrue()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(
            TestDbContextFactory.NewDatabaseName());

        var service = new CategoryService(context);

        var category = new Category()
        {
            CategoryId = 2,
            CategoryName = "Ropa",
            Description = "Categoria de ropa"
        };

        // Act
        var result = await service.Guardar(category);

        // Assert
        Assert.True(result);

        var saved = await context.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == 2);

        Assert.NotNull(saved);
        Assert.Equal("Ropa", saved!.CategoryName);
    }

    [Fact]
    public async Task Guardar_CuandoCategoryExiste_ModificaYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Categories.Add(new Category()
            {
                CategoryId = 3,
                CategoryName = "Comida"
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new CategoryService(context);

        var actualizado = new Category()
        {
            CategoryId = 3,
            CategoryName = "Comida Modificada"
        };

        // Act
        var result = await service.Guardar(actualizado);

        // Assert
        Assert.True(result);

        var saved = await context.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == 3);

        Assert.NotNull(saved);
        Assert.Equal("Comida Modificada", saved!.CategoryName);
    }

    [Fact]
    public async Task Existe_CuandoCategoryExiste_RetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Categories.Add(new Category()
            {
                CategoryId = 4,
                CategoryName = "Electronicos"
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new CategoryService(context);

        // Act
        var result = await service.Existe(4);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteCategory_LaBorraYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Categories.Add(new Category()
            {
                CategoryId = 5,
                CategoryName = "Hogar"
            });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new CategoryService(context);

        // Act
        var result = await service.Eliminar(5);

        // Assert
        Assert.True(result);

        var deleted = await context.Categories.FindAsync(5);

        Assert.Null(deleted);
    }

    [Fact]
    public async Task GetList_CuandoHayCategorias_RetornaLista()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Categories.AddRange(
                new Category()
                {
                    CategoryId = 6,
                    CategoryName = "Tecnologia"
                },
                new Category()
                {
                    CategoryId = 7,
                    CategoryName = "Deportes"
                });

            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);

        var service = new CategoryService(context);

        // Act
        var result = await service.GetList(c =>
            c.CategoryName.Contains("e"));

        // Assert
        Assert.Equal(2, result.Count);
    }
}