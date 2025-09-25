using System.ComponentModel.DataAnnotations;

namespace ProyectoInventarioReportes.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre_Marca { get; set; }

        // Propiedad de navegación
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
