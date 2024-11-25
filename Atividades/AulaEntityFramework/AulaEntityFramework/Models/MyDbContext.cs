using Microsoft.EntityFrameworkCore;
using AulaEntityFramework.Models;

namespace AulaEntityFramework.Models
{
    // A classe de contexto de banco de dados
    // ou DbContext é responsável por
    // mapear as classes que serão atreladas 
    // às tabelas do banco de dados.
    public class MyDbContext : DbContext
    {
        public MyDbContext(
            DbContextOptions options
        ) : base(options)
        {
        }

        // Nesta sessão especificamos as
        // classes do Model que serão espelhadas
        // em tabelas do BD

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    // A classe de contexto de banco de dados
public DbSet<AulaEntityFramework.Models.Time> Time { get; set; } = default!;
    // A classe de contexto de banco de dados
public DbSet<AulaEntityFramework.Models.TimePessoa> TimePessoa { get; set; } = default!;
    }
}
