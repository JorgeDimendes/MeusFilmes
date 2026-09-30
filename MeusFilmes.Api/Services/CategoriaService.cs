using AutoMapper;
using MeusFilmes.Api.Dtos.Categoria;
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

        public async Task<ResponseModel<CategoriaDto>> CriarCategoriaAsync(CriarCategoriaDto criarCategoriaDto)
        {
            ResponseModel<CategoriaDto> response = new ResponseModel<CategoriaDto>();

            try
            {
                if (criarCategoriaDto is null)
                {
                    response.Mensagem = "Dados da categoria não informados.";
                    response.Status = false;
                    return response;
                }

                // Validação de negócio
                if (await _repository.ExisteNomeCategoria(criarCategoriaDto.Nome))
                {
                    response.Mensagem = $"A categoria '{criarCategoriaDto.Nome}' já existe.";
                    response.Status = false;
                    return response;
                }

                var categoria = _mapper.Map<Categoria>(criarCategoriaDto);

                await _repository.CriarCategoria(categoria);
                await _repository.SalvarAlteracoesAsync();

                response.Dados = _mapper.Map<CategoriaDto>(categoria);
                response.Mensagem = "Categoria criada com sucesso.";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Ocorreu um erro ao criar a categoria: {ex.Message}";
                response.Status = false;
                return response;
            }
            
            #region FormaSimples
            /*
            if (await _repository.ExisteNomeCategoria(criarCategoriaDto.Nome))
            {
                throw new ConflictException($"A categoria '{criarCategoriaDto.Nome}' já existe.");
            }

            var categoria = _mapper.Map<Categoria>(criarCategoriaDto);

            await _repository.CriarCategoria(categoria);
            await _repository.SalvarAlteracoesAsync();

            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return _mapper.Map<CategoriaDto>(categoria);
            */
            #endregion
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

        public class ConflictException : Exception
        {
            public ConflictException(string message) : base(message)
            {
            }
        }
    }
}