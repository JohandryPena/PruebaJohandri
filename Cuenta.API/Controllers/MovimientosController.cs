using Cuenta.Application.Interfaces;
using Cuenta.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cuenta.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class MovimientosController : ControllerBase
	{
		private readonly IMovimientoService _service;

        public MovimientosController(IMovimientoService service)
        {
            _service=service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movimientos>>> Get()
        {
            var movimientos = await _service.GetMovimientosAsync();
            return Ok(movimientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Movimientos>>> GetId(int id)
        {
            var movimientos = await _service.GetMovimientoAsync(id);
            return Ok(movimientos);
        }
        [HttpGet("cuenta/{idCuenta}")]
        public async Task<ActionResult<List<Movimientos>>> GetMovimientosCuenta(int idCuenta)
        {
            var movimientos = await _service.GetMovimientoCuentaAsync(idCuenta);
            return Ok(movimientos);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(Movimientos movimiento)
        {
            string nuevoMovimiento = await _service.CreateMovimientoAsync(movimiento);
            return Ok(nuevoMovimiento);
        }

        [HttpPut]
        public async Task<ActionResult<List<Movimientos>>> Put(int Id, Movimientos movimiento)
        {
            var movimientos = await _service.UpdateMovimientoAsync(Id, movimiento);
            return Ok(movimientos);
        }

        [HttpDelete]
        public async Task<ActionResult<Movimientos>> Delete(int Id)
        {
            var movimientoEliminado = await _service.DeleteMovimientoAsync(Id);
            return Ok(movimientoEliminado);
        }
	}
}
