using CrudApiMySqlEf.Domain.Enties;
using Microsoft.EntityFrameworkCore;

namespace CrudApiMySqlEfNet6.Infrastructure.Databases;
public class DbContextEfMySql : DbContext
{
    private const string connectionMySql = "server=localhost;Uid=root;password=root;database=bd_net7";

    public DbSet<Usuario> Usuarios {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder opciones)
    {
        opciones.UseMySql(connectionMySql, ServerVersion.AutoDetect(connectionMySql));
    }

}