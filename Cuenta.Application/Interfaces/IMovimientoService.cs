using Cuenta.Domain.Entitys;

namespace Cuenta.Application.Interfaces
{

    //This is a use case
    public interface IMovimientoService
    {
        Task<List< Movimientos>> GetMovimientosAsync();
        Task< Movimientos> GetMovimientoAsync(int id);
        Task<string> CreateMovimientoAsync( Movimientos movimiento);
        Task< Movimientos> UpdateMovimientoAsync(int id,  Movimientos movimiento);
        Task<List<Movimientos>> GetMovimientoCuentaAsync(int idCuenta);
        Task< Movimientos> DeleteMovimientoAsync(int id);


    }
}
