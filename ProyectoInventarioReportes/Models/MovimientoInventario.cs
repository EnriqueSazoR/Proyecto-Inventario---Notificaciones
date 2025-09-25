using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoInventarioReportes.Models
{
    public class MovimientoInventario
    {

        public enum TipoMovimiento
        {
            EntradaStock,
            Venta
        }

        public enum TipoVenta
        {
            Online,
            Sucursal
        }

        // Propiedades
        [Key]
        public int Id { get; set; }
        
        public int IdProducto { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; } = null!;

        public int Unidades { get; set; }
        
        public TipoMovimiento Movimiento { get; set; }

        public TipoVenta? Venta { get; set; }

        public DateTime FechaMovimiento { get; set; } = DateTime.Now;


    }
}
