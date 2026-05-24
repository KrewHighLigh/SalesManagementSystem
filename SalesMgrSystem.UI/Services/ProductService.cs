using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SalesMgrSystem.UI.Services;

public class ProductService(SalesMgrContext context)
    : IService<Product, int>
{
    public async Task<Product?> Buscar(int id)
    {
        return await context.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .Include(p => p.OrderDetails)
            .FirstOrDefaultAsync(p => p.ProductId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var product = await context.Products.FindAsync(id);

        if (product == null)
            return false;

        context.Products.Remove(product);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Product>> GetList(
        Expression<Func<Product, bool>> criterio)
    {
        return await context.Products
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Product entidad)
    {
        if (!await Existe(entidad.ProductId))
            return await Insertar(entidad);
        else
            return await Modificar(entidad);
    }

    private async Task<bool> Insertar(Product entidad)
    {
        context.Products.Add(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.Products
            .AnyAsync(p => p.ProductId == id);
    }

    public async Task<bool> Modificar(Product entidad)
    {
        context.Products.Update(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Product>> GetListConRelaciones(
        Expression<Func<Product, bool>> criterio)
    {
        return await context.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .Include(p => p.OrderDetails)
            .Where(criterio)
            .ToListAsync();
    }
}