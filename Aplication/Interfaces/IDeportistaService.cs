using Domain.DTOs;
using Domain.Entitys;

namespace Application.Interfaces;

public interface IDeportistaService
{
    Task<List<DeportistaDTO?>> GetDeportisTask();
    Task<DeportistaDTO> GetDeportista(int id);
    Task<string> AddDeportista(Deportista deportista);
    Task<string> UpdateDeportista(Deportista deportista , int id);
    Task<string> DeleteDeportista(int id);

}