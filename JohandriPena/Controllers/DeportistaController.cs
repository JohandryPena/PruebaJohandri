using Application.Interfaces;
using Domain.DTOs;
using Domain.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JohandriPena.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DeportistaController : ControllerBase
{
    private readonly IDeportistaService _deportistaService;
    private readonly ILogger<DeportistaController> _logger;

    public DeportistaController(IDeportistaService service, ILogger<DeportistaController> logger)
    {
        _deportistaService = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<List<DeportistaDTO?>> Get()
    {
        _logger.LogInformation("Get all Deportista");
        return await _deportistaService.GetDeportisTask();
    }


    [HttpGet("{id}")]
    public async Task<DeportistaDTO> GetById(int id)
    {
        _logger.LogInformation("Get Deportista by Id");
        return await _deportistaService.GetDeportista(id);
    }


    [HttpPost]
    public Task<string> Post([FromBody] Deportista deportista)
    {
        _logger.LogInformation("Add Deportista");
        return _deportistaService.AddDeportista(deportista);
    }


    [HttpPut("{id}")]
    public async Task<string> Put(int id, [FromBody] Deportista deportista)
    {
        _logger.LogInformation("Update Deportista");
        return await _deportistaService.UpdateDeportista(deportista, id);
    }

    [HttpDelete("{id}")]
    public async Task<string> Delete(int id)
    {_logger.LogInformation("Delete Deportista");
        return await _deportistaService.DeleteDeportista(id);
    }
}