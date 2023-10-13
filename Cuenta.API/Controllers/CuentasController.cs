using Cuenta.Application.Interfaces;
using Cuenta.Application.Services;
using Cuenta.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cuenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaService _service;
        
        public CuentasController(ICuentaService service, IHttpClientFactory httpClientFactory)
        {
            _service = service;
      

        }

        [HttpGet]
        public async Task<ActionResult<List<Cuentas>>>Get()
        {
            List<Cuentas> cuentas = await _service.GetCuentasAsync();
            return Ok(cuentas);
        }

        [HttpPost]
        public async Task<ActionResult<Cuentas>> Post(Cuentas cuentas)
        {
         
            var nuevaCuenta = await _service.CreateCuentaAsync(cuentas);
            return Ok(nuevaCuenta);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Cuentas>> Put(int Id, Cuentas cuenta)
        {
            var cuentas = await _service.UpdateCuentaAsync(Id, cuenta);
            return Ok(cuentas);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Cuentas>> GetById(int Id)
        {
            var cuentas = await _service.GetCuentaAsync(Id);
            return Ok(cuentas);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Cuentas>> Delete(int Id)
        {
            var cuentaEliminada = await _service.DeleteCuentaAsync(Id);
            return Ok(cuentaEliminada);
        }
    }
}
