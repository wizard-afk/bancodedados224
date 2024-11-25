using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aeroporto.Models;

public partial class AeroportoContext : DbContext
{
    public AeroportoContext()
    {
    }

    public AeroportoContext(DbContextOptions<AeroportoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeronafe> Aeronaves { get; set; }

    public virtual DbSet<Aeroporto> Aeroportos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Escala> Escalas { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Piloto> Pilotos { get; set; }

    public virtual DbSet<Poltrona> Poltronas { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Voo> Voos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AEROPORTO;User ID=;Password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeronafe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Aeronave__3213E83F9C0B0923");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NumeroPoltronas).HasColumnName("numero_poltronas");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Aeroporto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Aeroport__3213E83F9FB6579C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Localizacao)
                .HasMaxLength(100)
                .HasColumnName("localizacao");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.PessoaId).HasName("PK__Clientes__434CC5DB4A3F9975");

            entity.Property(e => e.PessoaId)
                .ValueGeneratedNever()
                .HasColumnName("pessoa_id");
            entity.Property(e => e.Preferencial)
                .HasDefaultValue(false)
                .HasColumnName("preferencial");

            entity.HasOne(d => d.Pessoa).WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cliente_pessoa");
        });

        modelBuilder.Entity<Escala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Escalas__3213E83F9C52386A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AeroportoId).HasColumnName("aeroporto_id");
            entity.Property(e => e.HorarioChegada)
                .HasColumnType("datetime")
                .HasColumnName("horario_chegada");
            entity.Property(e => e.HorarioSaida)
                .HasColumnType("datetime")
                .HasColumnName("horario_saida");
            entity.Property(e => e.VooId).HasColumnName("voo_id");

            entity.HasOne(d => d.Aeroporto).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.AeroportoId)
                .HasConstraintName("fk_escala_aeroporto");

            entity.HasOne(d => d.Voo).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.VooId)
                .HasConstraintName("fk_escala_voo");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Horarios__3213E83F77F0E6CD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HorarioChegada)
                .HasColumnType("datetime")
                .HasColumnName("horario_chegada");
            entity.Property(e => e.HorarioSaida)
                .HasColumnType("datetime")
                .HasColumnName("horario_saida");
            entity.Property(e => e.VooId).HasColumnName("voo_id");

            entity.HasOne(d => d.Voo).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.VooId)
                .HasConstraintName("fk_horario_voo");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pessoas__3213E83FD4E46764");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.PessoaId).HasName("PK__Pilotos__434CC5DB86F468B9");

            entity.Property(e => e.PessoaId)
                .ValueGeneratedNever()
                .HasColumnName("pessoa_id");
            entity.Property(e => e.NumeroLicenca)
                .HasMaxLength(50)
                .HasColumnName("numero_licenca");

            entity.HasOne(d => d.Pessoa).WithOne(p => p.Piloto)
                .HasForeignKey<Piloto>(d => d.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_piloto_pessoa");
        });

        modelBuilder.Entity<Poltrona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Poltrona__3213E83F692FCA1F");

            entity.HasIndex(e => new { e.AeronaveId, e.Numero }, "UQ__Poltrona__A7FD65FF851A4953").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AeronaveId).HasColumnName("aeronave_id");
            entity.Property(e => e.Disponivel)
                .HasDefaultValue(true)
                .HasColumnName("disponivel");
            entity.Property(e => e.Localizacao)
                .HasMaxLength(20)
                .HasColumnName("localizacao");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");

            entity.HasOne(d => d.Aeronave).WithMany(p => p.Poltronas)
                .HasForeignKey(d => d.AeronaveId)
                .HasConstraintName("fk_poltrona_aeronave");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservas__3213E83F77AF698E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.DataReserva)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("data_reserva");
            entity.Property(e => e.PoltronaId).HasColumnName("poltrona_id");
            entity.Property(e => e.VooId).HasColumnName("voo_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("fk_reserva_cliente");

            entity.HasOne(d => d.Poltrona).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.PoltronaId)
                .HasConstraintName("fk_reserva_poltrona");

            entity.HasOne(d => d.Voo).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.VooId)
                .HasConstraintName("fk_reserva_voo");
        });

        modelBuilder.Entity<Voo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Voos__3213E83F5DAC9C31");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AeronaveId).HasColumnName("aeronave_id");
            entity.Property(e => e.AeroportoDestino).HasColumnName("aeroporto_destino");
            entity.Property(e => e.AeroportoOrigem).HasColumnName("aeroporto_origem");
            entity.Property(e => e.HorarioPrevistoChegada)
                .HasColumnType("datetime")
                .HasColumnName("horario_previsto_chegada");
            entity.Property(e => e.HorarioSaida)
                .HasColumnType("datetime")
                .HasColumnName("horario_saida");
            entity.Property(e => e.PilotoId).HasColumnName("piloto_id");

            entity.HasOne(d => d.Aeronave).WithMany(p => p.Voos)
                .HasForeignKey(d => d.AeronaveId)
                .HasConstraintName("fk_voo_aeronave");

            entity.HasOne(d => d.AeroportoDestinoNavigation).WithMany(p => p.VooAeroportoDestinoNavigations)
                .HasForeignKey(d => d.AeroportoDestino)
                .HasConstraintName("fk_voo_aeroporto_destino");

            entity.HasOne(d => d.AeroportoOrigemNavigation).WithMany(p => p.VooAeroportoOrigemNavigations)
                .HasForeignKey(d => d.AeroportoOrigem)
                .HasConstraintName("fk_voo_aeroporto_origem");

            entity.HasOne(d => d.Piloto).WithMany(p => p.Voos)
                .HasForeignKey(d => d.PilotoId)
                .HasConstraintName("fk_voo_piloto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
