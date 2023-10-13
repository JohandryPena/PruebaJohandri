using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cuenta.Domain.Entitys
{
    public class Cuentas
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int CuentasId { get; set; }
        public int NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; } = string.Empty;
        public decimal SaldoInicial { get; set; }
        [JsonIgnore]
        public bool Estado { get; set; } = true;
        public int ClienteId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public ICollection<Movimientos>? Moviminetos { get; set; } = new List<Movimientos>();

    }
}
