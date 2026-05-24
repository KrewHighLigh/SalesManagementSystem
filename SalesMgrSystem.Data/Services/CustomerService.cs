using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SalesMgrSystem.Data.Services;

public class CustomerService(SalesMgrContext context)
    : IService<Customer, int>
{
    public async Task<Customer?> Buscar(int id)
    {
        return await context.Customers
            .AsNoTracking()
            .Include(c => c.Orders)
            .FirstOrDefaultAsync(c => c.CustomerId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var customer = await context.Customers.FindAsync(id);

        if (customer == null)
            return false;

        context.Customers.Remove(customer);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Customer>> GetList(
        Expression<Func<Customer, bool>> criterio)
    {
        return await context.Customers
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Customer entidad)
    {
        if (!await Existe(entidad.CustomerId))
            return await Insertar(entidad);
        else
            return await Modificar(entidad);
    }

    private async Task<bool> Insertar(Customer entidad)
    {
        context.Customers.Add(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.Customers
            .AnyAsync(c => c.CustomerId == id);
    }

    public async Task<bool> Modificar(Customer entidad)
    {
        context.Customers.Update(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Customer>> GetListConRelaciones(
        Expression<Func<Customer, bool>> criterio)
    {
        return await context.Customers
            .AsNoTracking()
            .Include(c => c.Orders)
            .Where(criterio)
            .ToListAsync();
    }
}