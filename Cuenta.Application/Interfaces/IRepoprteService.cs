using Cuenta.Domain;
using Cuenta.Domain.DTOs;

namespace Cuenta.Application.Interfaces
{

    //This is a use case
    public interface IReporteService
    {
        Task<List<ReporteDto>> GetReporteAsync(DateTime fecha);
 


    }
}
