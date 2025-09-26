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

        // Convertir valores enum a string en la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovimientoInventario>()
                .Property(m => m.Movimiento)
                .HasConversion<string>();

            modelBuilder.Entity<MovimientoInventario>()
                .Property(v => v.Venta)
                .HasConversion<string>();
        }

        // Modelos se definen acá
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<MovimientoInventario> MovimientoInventarios { get; set; }
    }


}
