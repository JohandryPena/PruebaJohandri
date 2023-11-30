using Aplication.Interfaces;
using Application.Interfaces;
using Domain.Entitys;


namespace Application.Services;

public class PesoSerivces : IPesoService
{
    private readonly IPesoRepository _pesoRepository;

    public PesoSerivces(IPesoRepository pesoRepository)
    {
        _pesoRepository = pesoRepository;
    }

    public Task<string> PostPeso(PesoDeportista peso)
    {
        return _pesoRepository.PostPeso(peso);
    }

    public Task<List<PesoDeportista?>> GetPeso(int id)
    {
        return _pesoRepository.GetPeso(id);
    }
}