using Microsoft.EntityFrameworkCore;

namespace ORM.Models
{
    public class BancoDadosContext : DbContext
    {
        public BancoDadosContext(DbContextOptions<BancoDadosContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Item> Itens { get; set; }
    }
}
