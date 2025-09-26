
using ProyectoInventarioReportes.Models;
using System.ComponentModel.DataAnnotations;


namespace ProyectoInventarioReportes.DTO
{
    public class IngresoStockDTO
    {

        [Required(ErrorMessage = "El producto es obligatorio")]
        public string Producto { get; set; }

        [Required( ErrorMessage = "Las unidades son obligatorias")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar al menos una unidad")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Debe ingresar únicamente enteros positivos en las unidades")]
        public int Unidades { get; set; }

        [Required(ErrorMessage = "El tipo movimiento es obligatorio - [EntradaSctok o Venta]")]
        public MovimientoInventario.TipoMovimiento Movimiento { get; set; }

        public MovimientoInventario.TipoVenta? Venta { get; set; }

        public DateTime FechaMovimiento { get; set; } = DateTime.Now;
    }
}
