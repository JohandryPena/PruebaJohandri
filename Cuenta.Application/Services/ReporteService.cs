using Cuenta.Application.Interfaces;
using Cuenta.Application.Repositorys;
using Cuenta.Domain;
using Cuenta.Domain.DTOs;

namespace Cuenta.Application.Services
{
    public class ReporteService : IReporteService
    {
        private readonly IReporteRepository _ReporteRepository;

        public ReporteService(IReporteRepository reporteRepository)
        {
            _ReporteRepository=reporteRepository;
        }

        public async Task<List<ReporteDto>> GetReporteAsync(DateTime fecha)
        {
            return await _ReporteRepository.GetReporteAsync(fecha);
        }


    }
}
