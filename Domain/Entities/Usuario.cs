
namespace CrudApiMySqlEf.Domain.Enties;
public class Usuario
{
    public int Id { get; set; }
    public string Clave { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    // Navegacion de Recopilacion
    public ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

}
