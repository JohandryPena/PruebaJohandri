using Cuenta.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuenta.Application.Repositorys
{
    public interface ICuentaRepository
    {
        Task<List<Cuentas>> GetCuentasAsync();
        Task<Cuentas> GetCuentaAsync(int id);
        Task<Cuentas> CreateCuentaAsync(Cuentas cuentas);
        Task<Cuentas> UpdateCuentaAsync(int id, Cuentas cuentas);
        Task<Cuentas> DeleteCuentaAsync(int id);

    }
}
