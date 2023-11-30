using Domain.Entitys;

namespace Application.Interfaces;

public interface IPesoService
{
 Task<string> PostPeso(PesoDeportista peso);
 Task<List<PesoDeportista?>> GetPeso(int id);

}