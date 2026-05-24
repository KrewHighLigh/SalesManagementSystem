using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SalesMgrSystem.UI.Services;

public class OrderDetailService(SalesMgrContext context)
    : IService<OrderDetailForm, int>
{
    public async Task<OrderDetailForm?> Buscar(int id)
    {
        return await context.OrderDetails
            .AsNoTracking()
            .Include(o => o.Order)
            .Include(o => o.Product)
            .FirstOrDefaultAsync(o => o.OrderDetailId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var orderDetail = await context.OrderDetails.FindAsync(id);

        if (orderDetail == null)
            return false;

        context.OrderDetails.Remove(orderDetail);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<OrderDetailForm>> GetList(
        Expression<Func<OrderDetailForm, bool>> criterio)
    {
        return await context.OrderDetails
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(OrderDetailForm entidad)
    {
        if (!await Existe(entidad.OrderDetailId))
            return await Insertar(entidad);
        else
            return await Modificar(entidad);
    }

    private async Task<bool> Insertar(OrderDetailForm entidad)
    {
        context.OrderDetails.Add(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.OrderDetails
            .AnyAsync(o => o.OrderDetailId == id);
    }

    public async Task<bool> Modificar(OrderDetailForm entidad)
    {
        context.OrderDetails.Update(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<OrderDetailForm>> GetListConRelaciones(
        Expression<Func<OrderDetailForm, bool>> criterio)
    {
        return await context.OrderDetails
            .AsNoTracking()
            .Include(o => o.Order)
            .Include(o => o.Product)
            .Where(criterio)
            .ToListAsync();
    }
}