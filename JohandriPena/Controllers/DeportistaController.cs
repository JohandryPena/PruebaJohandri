using Application.Interfaces;
using Domain.DTOs;
using Domain.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace Cuenta.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeportistaController : ControllerBase
{
    private readonly IDeportistaService _deportistaService;

    public DeportistaController(IDeportistaService service)
    {
        _deportistaService = service;
    }

    [HttpGet]
    public async Task<List<DeportistaDTO?>> Get()
    {
        return await _deportistaService.GetDeportisTask();
    }


    [HttpGet("{id}")]
    public async Task<DeportistaDTO> GetById(int id)
    {
        return await _deportistaService.GetDeportista(id);
    }


    [HttpPost]
    public Task<string> Post([FromBody] Deportista deportista)
    {
        return _deportistaService.AddDeportista(deportista);
    }


    [HttpPut("{id}")]
    public async Task<string> Put(int id, [FromBody] Deportista deportista)
    {
        return await _deportistaService.UpdateDeportista(deportista, id);
    }

    [HttpDelete("{id}")]
    public async Task<string> Delete(int id)
    {
        return await _deportistaService.DeleteDeportista(id);
    }
}