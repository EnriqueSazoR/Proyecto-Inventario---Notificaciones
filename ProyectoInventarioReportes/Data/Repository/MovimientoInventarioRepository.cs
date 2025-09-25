using Microsoft.EntityFrameworkCore;
using ProyectoInventarioReportes.DTO;
using ProyectoInventarioReportes.Models;

namespace ProyectoInventarioReportes.Data.Repository.IRepository
{
    public class MovimientoInventarioRepository : IMovimientoInventarioRepository
    {
        private readonly ApplicationDBContext _db;

        public MovimientoInventarioRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<MovimientoInventario> IngresoStock(IngresoStockDTO entity)
        {
            // Validar que el producto ingresado si existe
            var productoExistente = await _db.Productos.FirstOrDefaultAsync(p => p.Nombre_Producto == entity.Producto);
            if(productoExistente == null)
            {
                throw new Exception("El producto no existe en la base de datos");
            }

            // Agrega el movimiento a la tabla MovimientoInventario
            var IngresoInventario = new MovimientoInventario
            {
                IdProducto = productoExistente.Id,
                Unidades = entity.Unidades,
                Movimiento = entity.Movimiento,
                Venta = entity.Venta,
                FechaMovimiento = entity.FechaMovimiento

            };
            await _db.MovimientoInventarios.AddAsync(IngresoInventario);

            // Actualizar stock en tabla productos
            productoExistente.Stock += entity.Unidades;

            // Guardar cambios
            await _db.SaveChangesAsync();
            
            return IngresoInventario;
        }

        public async Task<MovimientoInventario> SalidaStock(SalidaStockDTO entity)
        {
            // validar que el producto ingresado existe
            var productoExistente = await _db.Productos.FirstOrDefaultAsync(p => p.Nombre_Producto == entity.Producto);
            if(productoExistente == null)
            {
                throw new Exception("El producto no existe en la base de datos");
            }

            // Agrega el movimiento a la tabla MovimientoInventario
            var SalidaInventario = new MovimientoInventario
            {
                IdProducto = productoExistente.Id,
                Unidades = entity.Unidades,
                Movimiento = entity.Movimiento,
                Venta = entity.Venta,
                FechaMovimiento = entity.FechaMovimiento

            };
            await _db.MovimientoInventarios.AddAsync(SalidaInventario);

            // Actualizar stock en tabla productos
            productoExistente.Stock -= entity.Unidades;

            // Guardar cambios
            await _db.SaveChangesAsync();

            return SalidaInventario;
        }
    }
}
