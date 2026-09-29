using System.ComponentModel.DataAnnotations;

namespace MeusFilmes.Api.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public DateTime FechaCriacao { get; set; }
    }
}