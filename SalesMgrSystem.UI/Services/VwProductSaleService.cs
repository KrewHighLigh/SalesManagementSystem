using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SalesMgrSystem.UI.Services;

public class VwProductSaleService(SalesMgrContext context)
    : IService<VwProductSale, string>
{
    public async Task<VwProductSale?> Buscar(string id)
    {
        return await context.VwProductSales
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.ProductName == id);
    }

    public async Task<bool> Eliminar(string id)
    {
        return false;
    }

    public async Task<List<VwProductSale>> GetList(
        Expression<Func<VwProductSale, bool>> criterio)
    {
        return await context.VwProductSales
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(VwProductSale entidad)
    {
        return false;
    }

    public async Task<bool> Existe(string id)
    {
        return await context.VwProductSales
            .AnyAsync(v => v.ProductName == id);
    }

    public async Task<bool> Modificar(VwProductSale entidad)
    {
        return false;
    }
}