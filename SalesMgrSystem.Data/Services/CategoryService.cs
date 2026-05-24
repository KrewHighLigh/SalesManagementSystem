using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using System.Linq.Expressions;

namespace SalesMgrSystem.Data.Services;

public class CategoryService(SalesMgrContext context)
    : IService<Category, int>
{
    public async Task<Category?> Buscar(int id)
    {
        return await context.Categories
            .AsNoTracking()
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.CategoryId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var category = await context.Categories.FindAsync(id);

        if (category == null)
            return false;

        context.Categories.Remove(category);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Category>> GetList(
        Expression<Func<Category, bool>> criterio)
    {
        return await context.Categories
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Category entidad)
    {
        if (!await Existe(entidad.CategoryId))
            return await Insertar(entidad);
        else
            return await Modificar(entidad);
    }

    private async Task<bool> Insertar(Category entidad)
    {
        context.Categories.Add(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.Categories
            .AnyAsync(c => c.CategoryId == id);
    }

    public async Task<bool> Modificar(Category entidad)
    {
        context.Categories.Update(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Category>> GetListConRelaciones(
        Expression<Func<Category, bool>> criterio)
    {
        return await context.Categories
            .AsNoTracking()
            .Include(c => c.Products)
            .Where(criterio)
            .ToListAsync();
    }
}