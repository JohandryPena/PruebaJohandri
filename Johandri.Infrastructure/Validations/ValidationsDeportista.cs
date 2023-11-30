using Domain.Entitys;
using FluentValidation;
using FluentValidation.Results;

namespace Infrastructure.Validations;

public class ValidationsDeportista: AbstractValidator<Deportista>
{
    
    public ValidationsDeportista()
    {
        var cascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Nombre).NotNull().NotEmpty().WithMessage("El nombre es requerido").Matches("^[a-zA-Z]+ [a-zA-Z]+$").WithMessage("El campo Nombre debe contener el Nombre y el Apellido separado por un espacio");
        RuleFor(x => x.Pais).NotNull().NotEmpty().WithMessage("El apellido es requerido").Length(3).WithMessage("El Valor del del Nombre del Pais debe tener una longitud de 3 caracteres"); 
   
    }

    public ValidationResult Validar(Deportista deportista)
    {
        return Validate(deportista);
    }
}