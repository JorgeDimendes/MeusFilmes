using MeusFilmes.Api.Models;

namespace MeusFilmes.Api.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        ICollection<Categoria> GetCategorias();
        Categoria GetCategoria(int id);
        bool ExisteCategoria(int id);
        bool ExisteNomeCategoria(string nome);
        bool CriarCategoria(Categoria categoria);
        bool AtualizarCategoria(Categoria categoria);
        bool DeletarCategoria(Categoria categoria);
        bool Guardar();
    }
}