using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using System.Linq.Expressions;

namespace SalesMgrSystem.Data.Services;

public class UserService(SalesMgrContext context)
    : IService<User, int>
{
    public async Task<User?> Buscar(int id)
    {
        return await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserId == id);
    }

    public async Task<List<User>> GetList(Expression<Func<User, bool>> criterio)
    {
        return await context.Users
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(User entidad)
    {
        if (!await Existe(entidad.UserId))
            return await Insertar(entidad);
        else
            return await Modificar(entidad);
    }

    public async Task<bool> Existe(int id)
    {
        return await context.Users
            .AnyAsync(u => u.UserId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
            return false;

        context.Users.Remove(user);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(User entidad)
    {
        context.Users.Update(entidad);
        return await context.SaveChangesAsync() > 0;
    }

    private async Task<bool> Insertar(User entidad)
    {
        context.Users.Add(entidad);
        return await context.SaveChangesAsync() > 0;
    }
}
