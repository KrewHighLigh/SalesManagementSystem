using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SalesMgrSystem.Data.Services;

public class PaymentService(SalesMgrContext context)
    : IService<Payment, int>
{
    public async Task<Payment?> Buscar(int id)
    {
        return await context.Payments
            .AsNoTracking()
            .Include(p => p.Order)
            .FirstOrDefaultAsync(p => p.PaymentId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var payment = await context.Payments.FindAsync(id);

        if (payment == null)
            return false;

        context.Payments.Remove(payment);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Payment>> GetList(
        Expression<Func<Payment, bool>> criterio)
    {
        return await context.Payments
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Payment entidad)
    {
        if (!await Existe(entidad.PaymentId))
            return await Insertar(entidad);
        else
            return await Modificar(entidad);
    }

    private async Task<bool> Insertar(Payment entidad)
    {
        context.Payments.Add(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.Payments
            .AnyAsync(p => p.PaymentId == id);
    }

    public async Task<bool> Modificar(Payment entidad)
    {
        context.Payments.Update(entidad);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Payment>> GetListConRelaciones(
        Expression<Func<Payment, bool>> criterio)
    {
        return await context.Payments
            .AsNoTracking()
            .Include(p => p.Order)
            .Where(criterio)
            .ToListAsync();
    }
}