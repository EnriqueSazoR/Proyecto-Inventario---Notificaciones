namespace ProyectoInventarioReportes.DTO
{
    public class ProductoMasVendidoDTO
    {
        public string NombreProducto { get; set; }
        public int TotalUnidadesVendidas { get; set; }
        public int VentasOnline { get; set; }
        public int VentasSucursal { get; set; }
    }
}
