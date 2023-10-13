
using Cuenta.Domain;
using Cuenta.Domain.DTOs;

namespace Cuenta.Application.Repositorys
{
    public interface IReporteRepository
    {
        Task<List<ReporteDto>> GetReporteAsync(DateTime fecha);
    }
}
