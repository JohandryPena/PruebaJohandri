using Cuenta.Domain.Entitys;

namespace Cuenta.Domain.DTOs
{
    public class ReporteDto
    {
        public List<Cuentas> Cuentas { get; set; }
        public ClienteDto Cliente { get; set; }
        
    }
}
