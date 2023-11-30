using Domain.Entitys;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Validations;

public class ValidationsPeso: AbstractValidator<PesoDeportista>
{
    private readonly DeportistaDbContext _pesoDbContext;
    public ValidationsPeso(DeportistaDbContext pesoDbContext)
    {
        _pesoDbContext = pesoDbContext;
        var cascadeMode = CascadeMode.Stop;
    
            RuleFor(x => x.Valor).NotNull().NotEmpty().WithMessage("El peso es requerido").GreaterThan(0).WithMessage("El peso debe ser mayor a 0");



        RuleFor(peso => peso.DeportistaId)
            .MustAsync(DeportistaExists)
            .WithMessage("El deportista no existe.");

            RuleFor(peso => peso)
                .MustAsync(HaveValidIntentos)
                .WithMessage("El deportista tiene un último intento mayor a 3 en la categoría.");

            RuleFor(x => x.Categoria)
                .NotNull().WithMessage("La categoría es requerida").InclusiveBetween(1, 2).WithMessage("La categoría debe ser 1 (Arranque) o 2 (Envion)");  
             ;



    }

    public async Task<ValidationResult> Validar(PesoDeportista peso)
    {
        return await ValidateAsync(peso);
    }

    private async Task<bool> DeportistaExists(int deportistaId, CancellationToken cancellationToken)
        => await _pesoDbContext.Deportistas.AnyAsync(d => d.Id == deportistaId, cancellationToken);

    private async Task<bool> HaveValidIntentos(PesoDeportista pesos,CancellationToken cancellationToken)
    {
        var ultimoIntento = await _pesoDbContext.PesoDeportistas
            .Where(p => p.DeportistaId == pesos.DeportistaId && p.Categoria == pesos.Categoria)
            .OrderByDescending(p => p.Intentos)
            .FirstOrDefaultAsync();

        return !(ultimoIntento?.Intentos >= 3);
    }
}