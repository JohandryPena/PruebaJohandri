using Cuenta.Application.Interfaces;
using Cuenta.Application.Repositorys;
using Cuenta.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuenta.Application.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _CuentaRepository;

        public CuentaService(ICuentaRepository cuentaRepository)
        {
            _CuentaRepository=cuentaRepository;
        }

        public async Task<Cuentas> CreateCuentaAsync(Cuentas cuentas)
        {

            return await _CuentaRepository.CreateCuentaAsync(cuentas);
        }

        public async Task<Cuentas> DeleteCuentaAsync(int id)
        {
           
            return await _CuentaRepository.DeleteCuentaAsync(id);
        }

        public async Task<Cuentas> GetCuentaAsync(int id)
        {
            return await _CuentaRepository.GetCuentaAsync(id);
        }

        public async Task<List<Cuentas>> GetCuentasAsync()
        {
            return await _CuentaRepository.GetCuentasAsync();
        }

        public async Task<Cuentas> UpdateCuentaAsync(int id, Cuentas cuentas)
        {
            return await _CuentaRepository.UpdateCuentaAsync(id, cuentas);
        }

    }
}
