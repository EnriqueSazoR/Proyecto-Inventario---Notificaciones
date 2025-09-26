using Microsoft.AspNetCore.Mvc;
using ProyectoInventarioReportes.Data.Repository.IRepository;
using ProyectoInventarioReportes.DTO;
using ProyectoInventarioReportes.Models;
using ProyectoInventarioReportes.Services.IServices;

namespace ProyectoInventarioReportes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovimientoInventarioController : ControllerBase
    {
        private readonly IMovimientoInventarioRepository _repository;
        private readonly IExistenciasService _existencias;

        public MovimientoInventarioController(IMovimientoInventarioRepository repository, IExistenciasService existencias)
        {
            _repository = repository;
            _existencias = existencias;
        }
        
        // Metodo para ingresar Stock
        [HttpPost("Entrada")]
        public async Task<ActionResult> IngresarStock([FromBody] IngresoStockDTO ingresoStockDTO)
        {
            try
            {
               await _repository.IngresoStock(ingresoStockDTO);

                return Ok(new
                {
                    mensaje = "Ingreso correctamente"
                });

            }catch(Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpPost("Salidas")]
        public async Task<ActionResult> SalidaStock([FromBody] SalidaStockDTO salidaStockDTO)
        {
            try
            {
                // Validar existencias
                await _existencias.ValidacionStock(salidaStockDTO.Producto, salidaStockDTO.Unidades);

                await _repository.SalidaStock(salidaStockDTO);

                return Ok(new { mensaje = "Salida exitosa" });

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }



        }
    }
}
