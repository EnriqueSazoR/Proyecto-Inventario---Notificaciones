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
        private readonly IEmailService _emailService;

        public MovimientoInventarioController(IMovimientoInventarioRepository repository, IExistenciasService existencias, IEmailService emailService)
        {
            _repository = repository;
            _existencias = existencias;
            _emailService = emailService;
        }
        
        // Metodo para ingresar Stock
        [HttpPost("Entrada")]
        public async Task<ActionResult> IngresarStock([FromBody] IngresoStockDTO ingresoStockDTO)
        {
            try
            {
                await _repository.IngresoStock(ingresoStockDTO);

                await _emailService.EnviarCorreoIngresoStock(ingresoStockDTO.Producto, ingresoStockDTO.Unidades);

                return Ok(new
                {
                    mensaje = "Stock ingresado correctamente y envío de correo exitoso"
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

                await _emailService.EnviarCorreoSalidaStock(salidaStockDTO.Producto, salidaStockDTO.Unidades);

                return Ok(new { mensaje = "Stock retirado correctamente y envío de correo exitoso" });

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }



        }
    }
}
