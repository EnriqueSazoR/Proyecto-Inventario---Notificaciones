using Microsoft.EntityFrameworkCore;
using ProyectoInventarioReportes.Models;

namespace ProyectoInventarioReportes.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        // Modelos se definen acá
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<MovimientoInventario> MovimientoInventarios { get; set; }
    }


}
