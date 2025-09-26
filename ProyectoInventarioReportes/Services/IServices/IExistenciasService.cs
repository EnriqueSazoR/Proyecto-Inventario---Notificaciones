using ProyectoInventarioReportes.Models;

namespace ProyectoInventarioReportes.Services.IServices
{
    public interface IExistenciasService
    {
        Task<bool> ValidacionStock(string nombreProducto, int cantidad);
    }
}
