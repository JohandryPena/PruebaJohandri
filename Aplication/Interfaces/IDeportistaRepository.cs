using Domain.Entitys;

namespace Aplication.Interfaces;

public interface IDeportistaRepository
{
    Task<List<Deportista?>> GetDeportisTask();
    Task<Deportista?> GetDeportista(int id);
    Task<string> AddDeportista(Deportista deportista);
    Task<string> UpdateDeportista(Deportista deportista, int id);
    Task<string> DeleteDeportista(int id);

}