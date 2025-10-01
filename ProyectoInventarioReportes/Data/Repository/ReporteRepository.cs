using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProyectoInventarioReportes.Data.Repository.IRepository;
using ProyectoInventarioReportes.DTO;
using ProyectoInventarioReportes.Models;

namespace ProyectoInventarioReportes.Data.Repository
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly ApplicationDBContext _db;

        public ReporteRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<ProductoStockDTO>> GetProductoStockBajoAlto()
        {
            var productos = await _db.Productos
                .Where(p => p.Stock  > 0)
                .Select(p => new ProductoStockDTO
                {
                    NombreProducto = p.Nombre_Producto,
                    Stock = p.Stock
                })
                .ToListAsync();

            return !productos.Any() ? throw new Exception("No se encontraron productos") : productos;
        }

        public async Task<List<MovimientoDTO>> GetMovimientosPorProducto(MovimientoFiltroDTO filtroDTO)
        {
            var movimientos =  await _db.MovimientoInventarios
                .Where(m => m.Producto.Nombre_Producto.ToLower() == filtroDTO.NombreProducto.ToLower() &&
                            m.FechaMovimiento.Month == filtroDTO.Mes &&
                            m.FechaMovimiento.Year == filtroDTO.Anio)
                .Select(m => new MovimientoDTO
                {
                    TipoMovimiento = m.Movimiento.ToString(),
                    TipoVenta = m.Venta.HasValue ? m.Venta.ToString() : "No Aplica",
                    Unidades = m.Unidades

                })
                .ToListAsync();

            if (movimientos.Count == 0)
                throw new Exception("No hay registros para este reporte");

            return movimientos;
        }

        public async Task<List<ProductoMasVendidoDTO>> GetProductoMasVendidos()
        {
            var productos =  await _db.MovimientoInventarios
                .Where(m => m.Movimiento == MovimientoInventario.TipoMovimiento.Venta)
                .GroupBy(m => m.Producto.Nombre_Producto)
                .Select(g => new ProductoMasVendidoDTO
                {
                    NombreProducto = g.Key,
                    TotalUnidadesVendidas = g.Sum(x => x.Unidades),
                    VentasOnline = g.Count(x => x.Venta == MovimientoInventario.TipoVenta.Online),
                    VentasSucursal = g.Count(x => x.Venta == MovimientoInventario.TipoVenta.Sucursal)
                })
                .OrderByDescending(p => p.TotalUnidadesVendidas)
                .ToListAsync();

            if (productos.Count == 0)
                throw new Exception("No hay resultados para este reporte");

            return productos;
        }

        public async Task<List<TipoVentaDTO>> GetVentasPorTipo()
        {
            var productos = await _db.MovimientoInventarios
                .Where(m => m.Movimiento == MovimientoInventario.TipoMovimiento.Venta)
                .GroupBy(m => m.Producto.Nombre_Producto)
                .Select(p => new TipoVentaDTO
                {
                    NombreProducto = p.Key,
                    VentasEnSucursal = p.Count(m => m.Venta == MovimientoInventario.TipoVenta.Sucursal).ToString(),
                    VentasOnline = p.Count(m => m.Venta == MovimientoInventario.TipoVenta.Online).ToString(),
                    UnidadesVendidas = p.Sum(m => m.Unidades)

                })
                .ToListAsync();

            if(productos.Count == 0)
                throw new Exception("No hay resultados para este reporte");

            return productos;
            
        }
    }
}