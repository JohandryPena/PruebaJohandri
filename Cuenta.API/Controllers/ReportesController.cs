using Cuenta.Application.Interfaces;
using Cuenta.Domain.DTOs;
using Cuenta.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cuenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReporteService _reporteService;
        public ReportesController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        // GET: api/<ReportesController>
        [HttpGet]
        public async Task<ActionResult<List<ReporteDto>>> Get(DateTime Fecha)
        {
            return Ok(await _reporteService.GetReporteAsync(Fecha));
        }

    
    }
}
