
using Microsoft.EntityFrameworkCore;

namespace AulaEntityFramework.Models
{
    // A classe de contexto de banco de dados
    // ou bd context é responsavel por mapear as classes
    // que serão atreladas as tabelas do banco de dados.
    public class MyDbContext : DbContext
    {
        //crtl . chama o construtor automatico
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        //nesta sessão especificamos as classes do Model que serão
        //espelhadas em tabelas do Bd

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
