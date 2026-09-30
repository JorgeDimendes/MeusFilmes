using System.ComponentModel.DataAnnotations;

namespace MeusFilmes.Api.Dtos.Categoria
{
    public class CriarCategoriaDto
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatorio")]
        [MaxLength(100, ErrorMessage = "Digite de 1 a 100 Caracteres!")]
        public string Nome { get; set; }
    }
}