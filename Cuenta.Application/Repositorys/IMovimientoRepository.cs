using Cuenta.Domain.Entitys;

namespace Cuenta.Application.Repositorys
{
    public interface IMovimientoRepository
    {
        Task<List<Movimientos>> GetMovimientosAsync();
        Task<Movimientos> GetMovimientoAsync(int id);
        Task<List<Movimientos>> GetMovimientoCuentaAsync(int idCuenta);
        Task<string> CreateMovimientoAsync(Movimientos movimiento);
        Task<Movimientos> UpdateMovimientoAsync(int id, Movimientos movimiento);
        Task<Movimientos> DeleteMovimientoAsync(int id);
    }
}
