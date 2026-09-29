using AutoMapper;
using MeusFilmes.Api.Dtos;
using MeusFilmes.Api.Models;
using MeusFilmes.Api.Repository.IRepository;
using MeusFilmes.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeusFilmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetAll()
        {
            var categorias = await _categoriaService.GetCategoriasAsync();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetById(int id)
        {
            var categoria = await _categoriaService.GetByIdCategoriaAsync(id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> PutAsync(CriarCategoriaDto categoriaDto)
        {
            var categoria = await _categoriaService.CriarCategoriaAsync(categoriaDto);
            if (categoria == null) return NotFound("Erro ao criar nova categoria");
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaDto>> PutAsync(int id, CriarCategoriaDto categoriaDto)
        {
            var categoria = await _categoriaService.AtualizarCategoriaAsync(id, categoriaDto);
            if (categoria == null) return NotFound("Erro ao atualizar categoria");
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var categoria = await _categoriaService.DeletarCategoriaAsync(id);
            if (categoria == null) return BadRequest("Erro ao deletar categoria");
            return NoContent();
        }
    }
}