using ProyectoInventarioReportes.DTO;

namespace ProyectoInventarioReportes.Services.IServices
{
    public interface IPdfService
    {
        byte[] GenerarProductosMasVendidosPDF(List<ProductoMasVendidoDTO> renking);
        byte[] GenerarVentasPorCanalPDF(List<TipoVentaDTO> tipos);
        byte[] GenerarStocksPDF(List<ProductoStockDTO> productos);
        byte[] GenerarMovimientosProductosPDF(List<MovimientoDTO> movimientos);
    }
}
