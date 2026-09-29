using MeusFilmes.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MeusFilmes.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
    }
}