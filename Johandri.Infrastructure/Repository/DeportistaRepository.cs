using Application.Interfaces;
using Domain.Entitys;
using Infrastructure.Validations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class DeportistaRepository : IDeportistaRepository
{
    private readonly DeportistaDbContext _deportistaDbContext;
    private readonly ValidationsDeportista _validationsDeportista;
    public DeportistaRepository(DeportistaDbContext deportistaDb, ValidationsDeportista validationsDeportista)
    {
        _deportistaDbContext = deportistaDb;
        _validationsDeportista = validationsDeportista;
    }

    public async Task<List<Deportista?>> GetDeportisTask()
    {
        return await _deportistaDbContext.Deportistas.Include(d => d.Pesos)
            .ToListAsync();
    }

    public async Task<Deportista?> GetDeportista(int id)
    {
        return await _deportistaDbContext.Deportistas
            .Include(d => d!.Pesos)
            .FirstOrDefaultAsync(x => x!.Id == id);
    }

    public async Task<string> AddDeportista(Deportista deportista)
    {
        try
        {
           var validaciones = _validationsDeportista.Validar(deportista);

            if (!validaciones.IsValid)
            {
                var errores = validaciones.Errors.Select(error => $" - {error.ErrorMessage}");
                return string.Join(Environment.NewLine, errores);
            }
            _deportistaDbContext.Deportistas.Add(deportista);
            await _deportistaDbContext.SaveChangesAsync();
            return "agregado";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<string> UpdateDeportista(Deportista deportista, int Id)
    {
        try
        {
            var existingDeportista = await _deportistaDbContext.Deportistas
                .Include(d => d.Pesos)
                .FirstOrDefaultAsync(d => d.Id == Id);

            if (existingDeportista == null) return "Deportista No Existe";

            var validaciones = _validationsDeportista.Validar(deportista);

            if (!validaciones.IsValid)
            {
                var errores = validaciones.Errors.Select(error => $" - {error.ErrorMessage}");
                return string.Join(Environment.NewLine, errores);
            }

            existingDeportista.Nombre = deportista.Nombre;
            existingDeportista.Pais = deportista.Pais;

            _deportistaDbContext.Update(existingDeportista);
            await _deportistaDbContext.SaveChangesAsync();

            return await Task.FromResult("Actualizado");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<string> DeleteDeportista(int id)
    {
        try
        {
            await Task.FromResult(_deportistaDbContext.Deportistas.Remove(new Deportista { Id = id }).Entity);
            await _deportistaDbContext.SaveChangesAsync();
            return "Eliminado";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}