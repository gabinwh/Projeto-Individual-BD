using AutoMapper;
using TrabPraticoBDIndividual.Entities;

namespace TrabPraticoBDIndividual.DTO;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioStoreRequest, Usuario>().ReverseMap();
        CreateMap<UsuarioResponse, Usuario>().ReverseMap();
    }
}
