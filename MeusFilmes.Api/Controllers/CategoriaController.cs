using AutoMapper;
using MeusFilmes.Api.Dtos;
using MeusFilmes.Api.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MeusFilmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _ctRepo;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var listaCategorias = _ctRepo.GetCategorias();

            var listaCategoriasDto = new List<CategoriaDto>();

            foreach (var list in listaCategorias)
            {
                listaCategoriasDto.Add(_mapper.Map<CategoriaDto>(list));
            }

            return Ok(listaCategorias);
        }
    }
}