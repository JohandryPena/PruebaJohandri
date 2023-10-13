using Cuenta.Application.Interfaces;
using Cuenta.Application.Repositorys;
using Cuenta.Domain.Entitys;

namespace Cuenta.Application.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _MovimientoRepository;

        public MovimientoService(IMovimientoRepository MovimientoRepository)
        {
            _MovimientoRepository = MovimientoRepository;
        }

        public async Task<string> CreateMovimientoAsync(Movimientos movimiento)
        {
            return await _MovimientoRepository.CreateMovimientoAsync(movimiento);
        }
        public async Task<Movimientos> DeleteMovimientoAsync(int id)
        {
            return await _MovimientoRepository.DeleteMovimientoAsync(id);
        }
        public async Task<Movimientos> GetMovimientoAsync(int id)
        {
            return await _MovimientoRepository.GetMovimientoAsync(id);
        }

        public async Task<List<Movimientos>> GetMovimientoCuentaAsync(int idCuenta)
        {
            return await _MovimientoRepository.GetMovimientoCuentaAsync(idCuenta);
        }

        public async Task<List<Movimientos>> GetMovimientosAsync()
        {
            return await _MovimientoRepository.GetMovimientosAsync();
        }
        public async Task<Movimientos> UpdateMovimientoAsync(int id, Movimientos movimiento)
        {
            return await _MovimientoRepository.UpdateMovimientoAsync(id, movimiento);
        }

    }
}
