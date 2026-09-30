using AutoMapper;
using MeusFilmes.Api.Dtos.Categoria;
using MeusFilmes.Api.Models;

namespace MeusFilmes.Api.ProfileMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Categoria, CriarCategoriaDto>().ReverseMap();
        }
    }
}
