using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasPorMenos.WebApi.DbContexts
{
    public class AppDbContext:DbContext
    {

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Conductor> Conductor { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> op  ):base(op) { 
        
        }
        
    }
}
