using MeusFilmes.Api.Models;
using System.Security.Cryptography;

namespace MeusFilmes.Api.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        Task<ICollection<Categoria>> GetCategorias();
        Task<Categoria> GetCategoria(int id);
        Task<bool> ExisteCategoria(int id);
        Task<bool> ExisteNomeCategoria(string nome);
        Task CriarCategoria(Categoria categoria);
        void AtualizarCategoria(Categoria categoria);
        void DeletarCategoria(Categoria categoria);
        Task<bool> SalvarAlteracoesAsync();
    }
}