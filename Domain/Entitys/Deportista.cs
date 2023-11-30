namespace Domain.Entitys;

public class Deportista
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Pais { get; set; }
    public List<PesoDeportista>? Pesos { get; set; }
}