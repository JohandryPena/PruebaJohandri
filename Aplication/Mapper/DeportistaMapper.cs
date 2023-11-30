using AutoMapper;
using Domain.DTOs;
using Domain.Entitys;

namespace Application.Mapper;

public class DeportistaMapper
{
    private readonly IMapper _mapper;

    public DeportistaMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {

            cfg.CreateMap<Deportista, DeportistaDTO>()
                .ForMember(dest => dest.Arranque, opt =>
                opt.MapFrom(src => src.Pesos
                    .Where(p => p.Categoria == 1)
                    .Max(p => (int?)p.Valor)))
                .ForMember(dest => dest.Envion, opt =>
                    opt.MapFrom(src =>
                        src.Pesos.Where(p => p.Categoria == 2)
                            .Max(p => (int?)p.Valor)))

                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Pesos
                    .Where(p => p.Categoria == 1 || p.Categoria == 2)
                    .Sum(p => 
                    (int?)p.Valor)));



            
            cfg.CreateMap<DeportistaDTO, Deportista>();
        });

        _mapper = config.CreateMapper();
    }

    public DeportistaDTO MapperToDto(Deportista? deportista)
    {
        return _mapper.Map<DeportistaDTO>(deportista);
    }

    public Deportista MapperToEntity(DeportistaDTO deportistaDto)
    {
        return _mapper.Map<Deportista>(deportistaDto);
    }

    public async Task<List<DeportistaDTO>> MapperToDtoList(Task<List<Deportista?>> deportistasTask)
    {
        var deportistas = await deportistasTask;
        var deportistaDtos = _mapper.Map<List<DeportistaDTO>>(deportistas);
        return deportistaDtos;
    }
}