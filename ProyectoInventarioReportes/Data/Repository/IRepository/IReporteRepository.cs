using ProyectoInventarioReportes.DTO;
using ProyectoInventarioReportes.Models;

namespace ProyectoInventarioReportes.Data.Repository.IRepository
{
    public interface IReporteRepository
    {
        Task<List<ProductoStockDTO>> GetProductoStockBajoAlto();
        Task<List<MovimientoDTO>> GetMovimientosPorProducto(MovimientoFiltroDTO filtroDTO);
        Task<List<ProductoMasVendidoDTO>> GetProductoMasVendidos();
    }
}
