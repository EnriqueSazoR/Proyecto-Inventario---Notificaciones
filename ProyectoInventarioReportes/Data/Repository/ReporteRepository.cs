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
                .Where(p => p.Stock < 40 || p.Stock > 60)
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
            return await _db.MovimientoInventarios
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
        }

        public async Task<List<ProductoMasVendidoDTO>> GetProductoMasVendidos()
        {
            return await _db.MovimientoInventarios
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
        }
    }
}