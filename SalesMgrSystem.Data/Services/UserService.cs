using Microsoft.EntityFrameworkCore;
using SalesMgrSystem.Data.Context;
using SalesMgrSystem.Data.Models;
using System.Linq.Expressions;

namespace SalesMgrSystem.Data.Services;

public class UserService(
    SalesMgrContext Context
    ) : Aplicada1.Core.IService<User, int>
{

    public async Task<bool> Guardar(User entidad)
    {
        if (!await Existe(entidad.UserId))
            return await Insertar(entidad);
        else
            return await Modificar(entidad);
    }
    public async Task<User?> Buscar(int id)
    {
       return await Context.Users.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var user = await Buscar(id);
        if (user == null)
            return false;

        Context.Users.Remove(user);
        return await Context.SaveChangesAsync() > 0;
    }    

    public async Task<List<User>> GetList(Expression<Func<User, bool>> criterio)
    {
        return await Context.Users
            .Where(criterio)
            .ToListAsync();
    }

    private async Task<bool> Existe(int id)
    {
        return await Context.Users.AnyAsync(u => u.UserId == id);
    }
    private async Task<bool> Insertar(User entidad)
    {
        Context.Users.Add(entidad);
        return await Context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(User entidad)
    {
        Context.Users.Update(entidad);
        return await Context.SaveChangesAsync() > 0;
    }

}
