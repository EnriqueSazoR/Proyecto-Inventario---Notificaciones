using ProyectoInventarioReportes.DTO;
using ProyectoInventarioReportes.Models;

namespace ProyectoInventarioReportes.Data.Repository.IRepository
{
    public interface IMovimientoInventarioRepository
    {
        // metodo para ingresar stcok en productos
        Task<MovimientoInventario> IngresoStock(IngresoStockDTO entity);
        Task<MovimientoInventario> SalidaStock(SalidaStockDTO entity);
    }
}
