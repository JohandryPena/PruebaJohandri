using Application.Interfaces;
using Application.Mapper;
using Domain.DTOs;
using Domain.Entitys;

namespace Application.Services;

public class DeportistaSerivces : IDeportistaService
{
    private readonly IDeportistaRepository _deportistaRepository;
    private readonly DeportistaMapper _mapper;
    public DeportistaSerivces(IDeportistaRepository deportistaRepository, DeportistaMapper mapper)
    {
        _deportistaRepository = deportistaRepository;
        _mapper = mapper;
    }


    public  async Task<List<DeportistaDTO?>> GetDeportisTask()
    {
        var deportistasTask = _deportistaRepository.GetDeportisTask();
        var deportistaDtos = await _mapper.MapperToDtoList(deportistasTask);

        return (await Task.FromResult(deportistaDtos))!;
    }

    public async Task<DeportistaDTO> GetDeportista(int id)
    {
        Deportista? deportista = await _deportistaRepository.GetDeportista(id);
        
       return _mapper.MapperToDto(deportista);
    }

    public Task<string> AddDeportista(Deportista deportista)
    {
       return   _deportistaRepository.AddDeportista(deportista);
    }

    public Task<string> UpdateDeportista(Deportista deportista, int id)
    {
      return  _deportistaRepository.UpdateDeportista(deportista, id);
    }

    public Task<string> DeleteDeportista(int id)
    {
       return _deportistaRepository.DeleteDeportista(id);
    }
}