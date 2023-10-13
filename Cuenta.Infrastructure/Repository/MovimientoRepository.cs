using Cuenta.Application.Repositorys;
using Cuenta.Domain.Entitys;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace Cuenta.Infrastructure.Repository
{
    public class MovimientoRepository : IMovimientoRepository
    {
   
        private readonly CuentaDbContext _MovimientoDbContext;

        public MovimientoRepository(CuentaDbContext MovimientoDbContext)
        {
            _MovimientoDbContext = MovimientoDbContext;
        }

        public async Task<string> CreateMovimientoAsync(Movimientos movimiento)
        {
            var parametro = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 255); // Asegúrate de usar la longitud adecuada
            parametro.Direction = ParameterDirection.Output;

            var valor = await _MovimientoDbContext.Database.ExecuteSqlInterpolatedAsync($@"EXECUTE [dbo].[RealizarMovimiento] 
             @CuentaId={movimiento.CuentaId}, @Valor={movimiento.Valor}, @Mensaje={parametro} OUTPUT");
            var mensaje = parametro.Value.ToString();
            return mensaje;
        }

        public async Task<Movimientos> DeleteMovimientoAsync(int id)
        {
            var movimiento = await _MovimientoDbContext.Movimientos.FindAsync(id);
            if (movimiento != null)
            {
                movimiento.Estado = false;
                await _MovimientoDbContext.SaveChangesAsync();
            }
            return movimiento;
        }

        public async Task<Movimientos> GetMovimientoAsync(int id)
        {
            return await _MovimientoDbContext.Movimientos.FindAsync(id);
        }
        public async Task<List<Movimientos>> GetMovimientoCuentaAsync(int idCuenta)
        {
            return await _MovimientoDbContext.Movimientos
                .Where(m => m.CuentaId == idCuenta)
                 .ToListAsync();
        }

        public async Task<List<Movimientos>> GetMovimientosAsync()
        {
            return await _MovimientoDbContext.Movimientos.ToListAsync();
        }

        public async Task<Movimientos> UpdateMovimientoAsync(int id, Movimientos movimiento)
        {
            var existingMovimiento = await _MovimientoDbContext.Movimientos.FindAsync(id);
            if (existingMovimiento != null)
            {
                 await _MovimientoDbContext.SaveChangesAsync();
            }
            return existingMovimiento;
        }


    }
}
