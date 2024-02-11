namespace CrudApiMySqlEf.Domain.Enties;

public class Gasto
{
    public int Id { get; set; }
    public String Nombre { get; set; }
    public DateTime Fecha { get; set; }
    public float Valor { get; set; }
    public String Detalles { get; set; }
    public int UsuarioId { get; set; }
    // Navegacion de referencia (es la FKs)
    public Usuario Usuario { get; set; }
}