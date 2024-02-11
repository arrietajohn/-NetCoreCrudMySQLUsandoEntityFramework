
using CrudApiMySqlEf.Domain.Enties;
using CrudApiMySqlEfNet6.Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;

namespace CrudApiMySqlEfNet6.Infrastructure.Repository;


public class UsuarioRepository : IUsuarioRepository
{
    
    private DbContextEfMySql _dbContext;
    public UsuarioRepository(DbContextEfMySql dbContext ){
        _dbContext = dbContext;
    }

    public void Actualizar(Usuario usuario)
    {
        try
        {
            _dbContext.Usuarios.Update(usuario);
            _dbContext.SaveChanges();
        }
        catch (System.Exception)
        {
            throw new Exception($"Usuario con Id: {usuario.Id} no existe");
        }
    }

    public Task ActualizarAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }


    public Usuario BuscarPorId(int id)
    {
        try
        {
             return _dbContext.Usuarios.Single(u => u.Id == id);
        }
        catch (System.Exception)
        {
            throw new Exception($"Usuario con ID: {id} no existe");
        }
    }

    public Task<Usuario> BuscarPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Int64 Contar()
    {
        return _dbContext.Usuarios.Count();
    }

    public Task<long> ContarAsync()
    {
        throw new NotImplementedException();
    }

    public void Eliminar(Usuario usuario)
    {
        try
        {
            _dbContext.Usuarios.Remove(usuario);
            _dbContext.SaveChanges();
        }
        catch (DbUpdateException)
        {
            throw new Exception($"Usuario con ID: {usuario.Id} No existe");
        }
    }

    public Task EliminarAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public void EliminarPorId(int id)
    {
        Eliminar(new Usuario{Id = id});
    }

    public Task EliminarPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Insertar(Usuario usuario)
    {
        try
        {
             _dbContext.Usuarios.Add(usuario);
        _dbContext.SaveChanges();
        }
        catch (DbUpdateException)
        {
            throw new Exception($"Usuario con ID: {usuario.Id} Ya existe");
        }
    }

    public Task InsertarAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public List<Usuario> ListarTodo()
    {
       return  _dbContext.Usuarios.ToList();
    }

    public Task<List<Usuario>> ListarTodoAsync()
    {
        throw new NotImplementedException();
    }

    public long EliminarTodo(){
        try
        {   long total = _dbContext.Usuarios.LongCount();
            _dbContext.Usuarios.RemoveRange(_dbContext.Usuarios);
            _dbContext.SaveChanges();
            return total;
        }
        catch (DbUpdateException error)
        {
            throw new Exception($"Error al aliminar todos los Usuario\nMensaje:"+error.Message);
        }
    }
}