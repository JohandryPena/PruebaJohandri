using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Domain.Entitys;

public class PesoDeportista
{
    public int Id { get; set; }
    public int Valor { get; set; }
    public int Categoria { get; set; }
    public short Intentos { get; set; }
    public int DeportistaId { get; set; }
    [IgnoreDataMember] public Deportista? Deportista { get; set; }
}

