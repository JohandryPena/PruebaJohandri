using System.Text.Json.Serialization;

namespace Cuenta.Domain.Entitys
{
    public class Movimientos
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int MovimientosId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Fecha { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TipoMovimineto { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal Saldo { get; set; }
        [JsonIgnore]
        public bool Estado { get; set; } = true;
        public int CuentaId { get; set; }
        [JsonIgnore]
        public Cuentas? Cuenta { get; set; }

    }
}