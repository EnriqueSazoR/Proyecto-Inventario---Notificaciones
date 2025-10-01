using Microsoft.AspNetCore.Mvc;
using ProyectoInventarioReportes.Data.Repository.IRepository;
using ProyectoInventarioReportes.DTO;
using ProyectoInventarioReportes.Services.IServices;

namespace ProyectoInventarioReportes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteRepository _reporteRepository;
        private readonly IPdfService _pdf;

        public ReporteController(IReporteRepository reporteRepository, IPdfService pdf)
        {
            _reporteRepository = reporteRepository;
            _pdf = pdf;
        }


        [HttpGet("/Stocks")]
        public async Task<ActionResult> StockProductos()
        {
            try
            {
                var listaStock = await _reporteRepository.GetProductoStockBajoAlto();

                var pdf = _pdf.GenerarStocksPDF(listaStock);

                return File(pdf, "application/pdf", "Stocks.pdf");
            }catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpPost("/MovimientosPorProducto")]
        public async Task<ActionResult> MovimientosProductos([FromBody] MovimientoFiltroDTO filtroDTO)
        {
            try
            {
                if (filtroDTO.Mes < 1 || filtroDTO.Mes > 12)
                    return BadRequest("El mes debe estar entre 1 y 12");

                var movimientos = await _reporteRepository.GetMovimientosPorProducto(filtroDTO);

                var pdf = _pdf.GenerarMovimientosProductosPDF(movimientos);

                return File(pdf, "application/pdf", "MovimientosProductos.pdf");

            }
            catch(Exception e)
            {
                return BadRequest(new { error = e.Message });
            }                  

        }

        [HttpGet("/ProductosMasVendidos")]
        public async Task<ActionResult> ProductosMasVendidos()
        {
            try
            {
                var ranking = await _reporteRepository.GetProductoMasVendidos();

                var pdf = _pdf.GenerarProductosMasVendidosPDF(ranking);

                return File(pdf, "application/pdf", "ProductosMasVendidos.pdf");
            }catch(Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }


        [HttpGet("/VentasPorCanal")]
        public async Task<ActionResult> VentasPorCanal()
        {
            try
            {
                var lista = await _reporteRepository.GetVentasPorTipo();

                var pdf = _pdf.GenerarVentasPorCanalPDF(lista);

                return File(pdf, "application/pdf", "VentasPorCanal.pdf");

            }catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        
    }
}
