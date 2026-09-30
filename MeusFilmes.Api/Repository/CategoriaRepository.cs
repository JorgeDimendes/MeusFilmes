using MeusFilmes.Api.Data;
using MeusFilmes.Api.Models;
using MeusFilmes.Api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MeusFilmes.Api.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Categoria>> GetCategorias()
        {
            return await _context.Categorias.OrderBy(c => c.Nome).ToListAsync();
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExisteCategoria(int id)
        {
            return _context.Categorias.Any(c => c.Id == id);
        }

        public async Task<bool> ExisteNomeCategoria(string nome)
        {
            // ToLower() = Transforma todas as letras da string em minúsculas.
            // Trim() = Remove espaços em branco do começo e do final da string.
            bool valor = await _context.Categorias.AnyAsync(c => c.Nome.ToLower().Trim() == nome.ToLower().Trim());
            return valor;
        }

        public async Task CriarCategoria(Categoria categoria)
        {
            categoria.DataCriacao = DateTime.Now;
            await _context.Categorias.AddAsync(categoria);
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            categoria.DataAlteracao = DateTime.Now;
            _context.Categorias.Update(categoria);
        }

        public void DeletarCategoria(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
        }

        public async Task<bool> SalvarAlteracoesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}