using CrudApiMySqlEf.Domain.Enties;

namespace CrudApiMySqlEfNet6.Infrastructure.Repository;

public interface IUsuarioRepository
{
    void Insertar(Usuario usuario);
    Task InsertarAsync(Usuario usuario);
    Usuario BuscarPorId(int id);
    Task<Usuario> BuscarPorIdAsync(int id);
    List<Usuario> ListarTodo();
    Task<List<Usuario>> ListarTodoAsync();
    void Actualizar(Usuario usuario);
    Task  ActualizarAsync(Usuario usuario);
    void EliminarPorId(int id);
    Task  EliminarPorIdAsync(int id);
    void Eliminar(Usuario usuario);
    long EliminarTodo();
    Task  EliminarAsync(Usuario usuario);
    Int64 Contar();
    Task<long> ContarAsync();

}