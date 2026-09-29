using AutoMapper;
using MeusFilmes.Api.Dtos;
using MeusFilmes.Api.Models;

namespace MeusFilmes.Api.FilmesMapper
{
    public class FilmesMapper : Profile
    {
        public FilmesMapper()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Categoria, CriarCategoriaDto>().ReverseMap();
        }
    }
}