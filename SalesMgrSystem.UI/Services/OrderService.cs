using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SalesMgrSystem.UI.Services;

public class OrderService(SalesMgrContext context)
    : IService<Order, int>
{
    public async Task<Order?> Buscar(int id)
    {
        return await context.Orders
            .AsNoTracking()
            .Include(o => o.Customer)
            .Include(o => o.User)
            .Include(o => o.OrderDetails)
            .Include(o => o.Payments)
            .FirstOrDefaultAsync(o => o.OrderId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var order = await context.Orders.FindAsync(id);

        if (order == null)
            return false;

        context.Orders.Remove(order);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Order>> GetList(
        Expression<Func<Order, bool>> criterio)
    {
        return await context.Orders
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Order entidad)
    {
        if (!await Existe(entidad.OrderId))
            return await Insertar(entidad);
        else
            return await Modificar(entidad);
    }

    private async Task<bool> Insertar(Order entidad)
    {
        context.Orders.Add(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.Orders
            .AnyAsync(o => o.OrderId == id);
    }

    public async Task<bool> Modificar(Order entidad)
    {
        context.Orders.Update(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Order>> GetListConRelaciones(
        Expression<Func<Order, bool>> criterio)
    {
        return await context.Orders
            .AsNoTracking()
            .Include(o => o.Customer)
            .Include(o => o.User)
            .Include(o => o.OrderDetails)
            .Include(o => o.Payments)
            .Where(criterio)
            .ToListAsync();
    }
}