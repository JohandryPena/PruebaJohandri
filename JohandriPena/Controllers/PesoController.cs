using Application.Interfaces;
using Domain.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JohandriPena.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PesoController : ControllerBase
{
    private readonly IPesoService _pesoService;
    private readonly ILogger<PesoController> _logger;
    public PesoController(IPesoService service, ILogger<PesoController> logger)
    {
        _pesoService = service;
        _logger=logger;
    }

    [HttpGet("{Id}")]
    public async Task<List<PesoDeportista?>> Get(int Id)
    {
        _logger.LogInformation("Get Peso");
        return await _pesoService.GetPeso(Id);
    }


    [HttpPost]
    public Task<string> Post([FromBody] PesoDeportista peso)
    {
        _logger.LogInformation("Add Peso"); 
        return _pesoService.PostPeso(peso);
    }


    [HttpDelete("{id}")]
    public async Task<string> Delete(int id)
    {
        _logger.LogInformation("Delete Peso");  
        return "Eliminado"; // await _pesoService.deletePeso(id);
    }
}