using MeusFilmes.Api.Data;
using MeusFilmes.Api.Models;
using MeusFilmes.Api.Repository.IRepository;

namespace MeusFilmes.Api.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _context.Categorias.OrderBy(c => c.Nome).ToList();
        }

        public Categoria GetCategoria(int id)
        {
            return _context.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public bool ExisteCategoria(int id)
        {
            return _context.Categorias.Any(c => c.Id == id);
        }

        public bool ExisteNomeCategoria(string nome)
        {
            // ToLower() = Transforma todas as letras da string em minúsculas.
            // Trim() = Remove espaços em branco do começo e do final da string.
            bool valor = _context.Categorias.Any(c => c.Nome.ToLower().Trim() == nome.ToLower().Trim());
            return valor;
        }

        public bool CriarCategoria(Categoria categoria)
        {
            categoria.FechaCriacao = DateTime.Now;
            _context.Categorias.Add(categoria);
            return Guardar();
        }

        public bool AtualizarCategoria(Categoria categoria)
        {
            categoria.FechaCriacao = DateTime.Now;
            _context.Categorias.Update(categoria);
            return Guardar();
        }

        public bool DeletarCategoria(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            return Guardar();
        }

        public bool Guardar()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}