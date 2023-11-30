using Application.Interfaces;
using Domain.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace Cuenta.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PesoController : ControllerBase
{
    private readonly IPesoService _pesoService;

    public PesoController(IPesoService service)
    {
        _pesoService = service;
    }

    [HttpGet("{Id}")]
    public async Task<List<PesoDeportista?>> Get(int Id)
    {
        return await _pesoService.GetPeso(Id);
    }


    [HttpPost]
    public Task<string> Post([FromBody] PesoDeportista peso)
    {
        return _pesoService.PostPeso(peso);
    }


    [HttpDelete("{id}")]
    public async Task<string> Delete(int id)
    {
        return "Eliminado"; // await _pesoService.deletePeso(id);
    }
}