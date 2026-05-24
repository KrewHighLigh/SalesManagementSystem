using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SalesMgrSystem.Data.Services;

public class VwSalesSummaryService(SalesMgrContext context)
    : IService<VwSalesSummary, int>
{
    public async Task<VwSalesSummary?> Buscar(int id)
    {
        return await context.VwSalesSummaries
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.OrderId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        return false;
    }

    public async Task<List<VwSalesSummary>> GetList(
        Expression<Func<VwSalesSummary, bool>> criterio)
    {
        return await context.VwSalesSummaries
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(VwSalesSummary entidad)
    {
        return false;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.VwSalesSummaries
            .AnyAsync(v => v.OrderId == id);
    }

    public async Task<bool> Modificar(VwSalesSummary entidad)
    {
        return false;
    }
}