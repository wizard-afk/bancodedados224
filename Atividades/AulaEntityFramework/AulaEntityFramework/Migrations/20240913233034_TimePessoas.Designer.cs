﻿// <auto-generated />
using System;
using AulaEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AulaEntityFramework.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240913233034_TimePessoas")]
    partial class TimePessoas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AulaEntityFramework.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PessoaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UF")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("AulaEntityFramework.Models.Pessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("AulaEntityFramework.Models.Time", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Time");
                });

            modelBuilder.Entity("AulaEntityFramework.Models.TimePessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("datetime2");

                    b.Property<long>("PessoaId")
                        .HasColumnType("bigint");

                    b.Property<long>("TimeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.HasIndex("TimeId");

                    b.ToTable("TimePessoa");
                });

            modelBuilder.Entity("AulaEntityFramework.Models.Endereco", b =>
                {
                    b.HasOne("AulaEntityFramework.Models.Pessoa", "Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("AulaEntityFramework.Models.TimePessoa", b =>
                {
                    b.HasOne("AulaEntityFramework.Models.Pessoa", "Pessoa")
                        .WithMany("TimesPessoas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AulaEntityFramework.Models.Time", "Time")
                        .WithMany("TimesPessoas")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("AulaEntityFramework.Models.Pessoa", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("TimesPessoas");
                });

            modelBuilder.Entity("AulaEntityFramework.Models.Time", b =>
                {
                    b.Navigation("TimesPessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
