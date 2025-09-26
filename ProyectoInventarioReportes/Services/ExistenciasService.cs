using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProyectoInventarioReportes.Data;
using ProyectoInventarioReportes.Data.Repository.IRepository;
using ProyectoInventarioReportes.Models;
using ProyectoInventarioReportes.Services.IServices;

namespace ProyectoInventarioReportes.Services
{
    public class ExistenciasService : IExistenciasService
    {
        private readonly ApplicationDBContext _db;

        public ExistenciasService(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<bool> ValidacionStock(string nombreProducto, int cantidad)
        {
            var producto = await _db.Productos.FirstOrDefaultAsync(p => p.Nombre_Producto == nombreProducto);
            if(producto == null)
            {
                throw new Exception("Stock Insuficiente");
            }   
            if(producto.Stock < cantidad)
            {
                throw new Exception("Stock Insuficiente");
            }
            return true;

        }
    }
}
