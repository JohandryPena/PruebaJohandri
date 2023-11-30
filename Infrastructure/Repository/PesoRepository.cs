using Aplication.Interfaces;
using Application.Interfaces;
using Domain.Entitys;
using FluentValidation;
using Infrastructure.Validations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PesoRepository :  IPesoRepository
{
    private readonly DeportistaDbContext _pesoDbContext;
   private readonly ValidationsPeso _validationsPeso;

    public PesoRepository(DeportistaDbContext deportistaDb, ValidationsPeso validationsPeso)
    {
        _pesoDbContext = deportistaDb;
        _validationsPeso = validationsPeso;
    }


    public async Task<string> PostPeso(PesoDeportista peso)
    {
        var valido = await _validationsPeso.Validar(peso);
        if (!valido.IsValid)
        {
            throw new ValidationException(valido.Errors);
        }

        var ultimoIntento = await _pesoDbContext.PesoDeportistas
            .Where(p => p.DeportistaId == peso.DeportistaId && p.Categoria == peso.Categoria)
            .OrderByDescending(p => p.Intentos)
            .FirstOrDefaultAsync();

        peso.Intentos = (short)(ultimoIntento?.Intentos + 1 ?? 1);

        _pesoDbContext.PesoDeportistas.Add(peso);
        await _pesoDbContext.SaveChangesAsync();
        return "agregado";
    }

    public Task<List<PesoDeportista?>> GetPeso(int id)
    {
        return _pesoDbContext.PesoDeportistas
            .Where(p => p.DeportistaId == id)
            .ToListAsync();
    }
}