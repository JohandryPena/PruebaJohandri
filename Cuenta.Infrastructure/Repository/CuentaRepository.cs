using Cuenta.Application.Repositorys;
using Cuenta.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuenta.Infrastructure.Repository
{
    public class CuentaRepository : ICuentaRepository
    {
       
        private readonly CuentaDbContext _cuentaDbContext;
        private readonly HttpClient _httpClient; 
        private readonly IConfiguration _configuration;
        public CuentaRepository(CuentaDbContext cuentaDbContext, HttpClient httpClient, IConfiguration configuration)
        {
            _cuentaDbContext = cuentaDbContext;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Cuentas> CreateCuentaAsync(Cuentas cuentas)
        {
           
            var cliente = await _httpClient.GetStringAsync($"{_configuration["servicioCliente"]}/{cuentas.ClienteId}");


            if (cliente == "")
            {
               
                throw new Exception("Cliente no encontrado");

            }
            _cuentaDbContext.Cuentas.Add(cuentas);
            await _cuentaDbContext.SaveChangesAsync();
            return cuentas;
        }

        public async Task<Cuentas> DeleteCuentaAsync(int id)
        {
            var cuenta = await _cuentaDbContext.Cuentas.FindAsync(id);
            if (cuenta != null)
            {
                cuenta.Estado = false;
                await _cuentaDbContext.SaveChangesAsync();
            }
            return cuenta;
        }

        public async Task<Cuentas> GetCuentaAsync(int id)
        {
            return await _cuentaDbContext.Cuentas.FindAsync(id);
        }

        public async Task<List<Cuentas>> GetCuentasAsync()
        {
            return await _cuentaDbContext.Cuentas.Where(c=>c.Estado==true).ToListAsync();
        }

        public async Task<Cuentas> UpdateCuentaAsync(int id, Cuentas cuentas)
        {
            var existingCuenta = await _cuentaDbContext.Cuentas.FindAsync(id);
            if (existingCuenta != null)
            {
               _cuentaDbContext.Entry(existingCuenta).CurrentValues.SetValues(cuentas);
                await _cuentaDbContext.SaveChangesAsync();
            }
            return existingCuenta;
        }

    }
}
