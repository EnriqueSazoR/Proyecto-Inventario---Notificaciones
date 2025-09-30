using Microsoft.AspNetCore.Mvc;
using ProyectoInventarioReportes.Data.Repository.IRepository;
using ProyectoInventarioReportes.DTO;

namespace ProyectoInventarioReportes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteRepository _reporteRepository;

        public ReporteController(IReporteRepository reporteRepository)
        {
            _reporteRepository = reporteRepository;   
        }


        [HttpGet("/Stocks")]
        public async Task<ActionResult> StockProductos()
        {
            try
            {
                var listaStock = await _reporteRepository.GetProductoStockBajoAlto();

                return Ok(new { ReporteUno = listaStock });
            }catch(Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpPost("/MovimientosPorProducto")]
        public async Task<ActionResult> MovimientosProductos([FromBody] MovimientoFiltroDTO filtroDTO)
        {
            if(filtroDTO.Mes < 1 || filtroDTO.Mes > 12)
                return BadRequest("El mes debe estar entre 1 y 12");

            var movimientos = await _reporteRepository.GetMovimientosPorProducto(filtroDTO);

            if(movimientos == null || movimientos.Count == 0)
                return NotFound("El producto no tuvo movimientos en el mes y año ingresados");

            return Ok(new { ReporteDos = movimientos });
            

        }

        [HttpGet("/ProductosMasVendidos")]
        public async Task<ActionResult> ProductosMasVendidos()
        {
            var ranking = await _reporteRepository.GetProductoMasVendidos();

            if (ranking.Count == 0)
                return NotFound("No se encontraron ventas registradas");

            return Ok(new { ReporteTres = ranking });
        }
    }
}
