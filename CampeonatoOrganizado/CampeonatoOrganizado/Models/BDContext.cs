using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CampeonatoOrganizado.Models
{
    public class BancoDadosContext(DbContextOptions<BancoDadosContext> options) : DbContext(options)
    {
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<PartidaIndividualView> PartidaIndividualView { get; set; }
        public DbSet<PartidaIndividual> PartidaIndividual { get; set; }
        public DbSet<PontuacaoIndividual> PontuacaoIndividual { get; set; }
        public DbSet<PartidaEquipe> PartidaEquipes { get; set; }
        public DbSet<FaseEquipe> FaseEquipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PartidaEquipe>()
              .ToTable("partida_equipe")
              .HasKey(pe => pe.IdPartidaEquipe);

            modelBuilder.Entity<FaseEquipe>()
            .ToTable("fase_equipe")
            .HasKey(f => f.IdFaseEquipe);

            modelBuilder.Entity<PartidaIndividualView>(entity =>
            {
                entity.ToTable("vw_partida_individual");
                entity.HasNoKey();
            });

            modelBuilder.Entity<PartidaIndividual>(entity =>
            {
                entity.ToTable("partida_individual"); // Nome da tabela
                entity.HasKey(p => p.id_partida_individual); // Chave primária

                entity.Property(p => p.id_atleta1).HasColumnName("id_atleta1");
                entity.Property(p => p.id_atleta2).HasColumnName("id_atleta2");

                // Relacionamento com Atleta1
                entity.HasOne(p => p.atleta1)
                      .WithMany()
                      .HasForeignKey(p => p.id_atleta1)
                      .HasConstraintName("FK_partida_individual_atleta1")
                      .OnDelete(DeleteBehavior.Restrict);

                // Relacionamento com Atleta2
                entity.HasOne(p => p.atleta2)
                      .WithMany()
                      .HasForeignKey(p => p.id_atleta2)
                      .HasConstraintName("FK_partida_individual_atleta2")
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração de PontuacaoIndividual
            modelBuilder.Entity<PontuacaoIndividual>(entity =>
            {
                entity.ToTable("pontuacao_individual"); // Nome da tabela
                entity.HasKey(p => p.id_pontuacao); // Chave primária

                // Relacionamento com Atleta
                entity.HasOne(p => p.Atleta)
                      .WithMany(a => a.Pontuacoes)
                      .HasForeignKey(p => p.id_atleta)
                      .HasConstraintName("FK_pontuacao_individual_atleta");
            });

        }

    }
}

