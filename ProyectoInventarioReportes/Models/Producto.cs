using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoInventarioReportes.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre_Producto { get; set; }
        public string? Descripcion { get; set; }
        public int Stock { get; set; }

        // llave foranea
        public int IdMarca { get; set; }
        [ForeignKey("IdMarca")]
        public Marca Marca { get; set; } = null!;
    }
}
