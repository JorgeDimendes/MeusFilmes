using AutoMapper;
using MeusFilmes.Api.Dtos;
using MeusFilmes.Api.Models;
using MeusFilmes.Api.Repository.IRepository;

namespace MeusFilmes.Api.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDto>> GetCategoriasAsync()
        {
            var categorias = await _repository.GetCategorias();
            return _mapper.Map<IEnumerable<CategoriaDto>>(categorias);
        }

        public async Task<CategoriaDto> GetByIdCategoriaAsync(int id)
        {
            var categoria = await _repository.GetCategoria(id);
            if (categoria == null) return null;

            return _mapper.Map<CategoriaDto>(categoria);
        }

        public async Task<CategoriaDto> CriarCategoriaAsync(CriarCategoriaDto criarCategoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(criarCategoriaDto);

            await _repository.CriarCategoria(categoria);
            await _repository.SalvarAlteracoesAsync();

            return _mapper.Map<CategoriaDto>(categoria);
        }

        public async Task<CategoriaDto> AtualizarCategoriaAsync(int id, CriarCategoriaDto atualizarCategoriaDto)
        {
            var categoriaExiste = await _repository.GetCategoria(id);
            if (categoriaExiste == null) return null;

            // Atualiza as propriedades da entidade com base no DTO
            _mapper.Map(atualizarCategoriaDto, categoriaExiste);

            _repository.AtualizarCategoria(categoriaExiste);
            await _repository.SalvarAlteracoesAsync();

            // 3. Mapeia a entidade atualizada para DTO antes de retornar
            return _mapper.Map<CategoriaDto>(categoriaExiste);
        }

        public async Task<bool> DeletarCategoriaAsync(int id)
        {
            var categoria = await _repository.GetCategoria(id);
            if(categoria ==  null) return false;

            _repository.DeletarCategoria(categoria);

            return await _repository.SalvarAlteracoesAsync();
        }
    }
}