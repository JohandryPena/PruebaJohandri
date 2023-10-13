using Cuenta.Application.Repositorys;
using Cuenta.Domain.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cuenta.Infrastructure.Repository
{
    public class ReporteRepository: IReporteRepository
    {
        private readonly CuentaDbContext _cuentaDbContext;
        private readonly HttpClient _httpClient; 
        private readonly IConfiguration _configuration;
        public ReporteRepository(CuentaDbContext cuentaDbContext , HttpClient httpClient, IConfiguration configuration)
        {
            _cuentaDbContext = cuentaDbContext;
            _httpClient=httpClient; 
            _configuration = configuration;
        }

        public async Task<List<ReporteDto>> GetReporteAsync(DateTime fecha)
        {
            List<ReporteDto> reportes = new List<ReporteDto>();
            try
            {
                var response = await _httpClient.GetAsync(_configuration["servicioCliente"]); 
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<ClienteDto> clientes = JsonConvert.DeserializeObject<List<ClienteDto>>(content);

                    if (clientes.Count()>0)
                    {
                        foreach (var cliente in clientes)
                        {
                            ReporteDto reporteDto1 = new ReporteDto();
                            reporteDto1.Cliente=cliente;

                            reporteDto1.Cuentas =_cuentaDbContext.Cuentas
                                .Where(c => c.Estado==true
                                && c.ClienteId ==cliente.clienteId).ToList();

                            foreach (var item in reporteDto1.Cuentas)
                            {
                                item.Moviminetos=_cuentaDbContext.Movimientos
                                    .Where(m => m.Estado==true && m.Fecha>=fecha && m.CuentaId==item.CuentasId).ToList();
                            }
                            reportes.Add(reporteDto1);
                        }
                  
                    }
                    
                }
                else
                {
                  throw new Exception("No Existen Clientes Activos");
                }
            }
            catch (Exception)
            {
                throw;
            }

           return reportes;
        }
       

    }
}
