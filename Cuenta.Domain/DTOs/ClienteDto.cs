using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuenta.Domain.DTOs
{
    public class ClienteDto
    {
        public int clienteId { get; set; }
        public Persona persona { get; set; }

    }
    public class Persona
    {
        public string nombre { get; set; }
        public string genero { get; set; }
        public int edad { get; set; }
        public int identificacion { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }
}
