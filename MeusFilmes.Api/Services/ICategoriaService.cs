using MeusFilmes.Api.Dtos;

namespace MeusFilmes.Api.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDto>> GetCategoriasAsync();
        Task<CategoriaDto> GetByIdCategoriaAsync(int id);
        Task<CategoriaDto> CriarCategoriaAsync(CriarCategoriaDto criarCategoriaDto);
        Task<CategoriaDto> AtualizarCategoriaAsync(int id, CriarCategoriaDto atualizarCategoriaDto);
        Task<bool> DeletarCategoriaAsync(int id);
    }
}