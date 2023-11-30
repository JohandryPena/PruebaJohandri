
namespace Domain.DTOs
{
    public class DeportistaDTO
    {
        public int Id { get; set; }
        public string Pais { get; set; }= null!;
        public string Nombre { get; set; } = null!;
        public int Arranque { get; set; }
        public int Envion { get; set; }
        public int Total { get; set; }
    }
}
