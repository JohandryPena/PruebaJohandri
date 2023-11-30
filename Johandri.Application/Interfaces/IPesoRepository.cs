using Domain.Entitys;

namespace Application.Interfaces;

public interface IPesoRepository
{
    Task<string> PostPeso(PesoDeportista peso);
    Task<List<PesoDeportista?>> GetPeso(int id);

}