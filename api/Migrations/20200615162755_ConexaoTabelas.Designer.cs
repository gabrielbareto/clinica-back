﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

namespace api.Migrations
{
    [DbContext(typeof(apiContext))]
    [Migration("20200615162755_ConexaoTabelas")]
    partial class ConexaoTabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api.Models.Cobertura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Cobertura");
                });

            modelBuilder.Entity("api.Models.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CoberturaId");

                    b.Property<DateTime>("Data");

                    b.Property<int>("MedicoId");

                    b.Property<int>("PacienteId");

                    b.Property<int>("ReceitaId");

                    b.Property<int>("RequisicaoId");

                    b.HasKey("Id");

                    b.HasIndex("CoberturaId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("ReceitaId");

                    b.HasIndex("RequisicaoId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("api.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<string>("Estado");

                    b.Property<string>("Numero");

                    b.Property<string>("Rua");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("api.Models.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Especialidade");
                });

            modelBuilder.Entity("api.Models.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<int>("EspecialidadeId");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadeId");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("api.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf");

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Nome");

                    b.Property<string>("Rg");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("api.Models.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<int>("PacienteId");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("api.Models.Requisicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<int>("PacienteId");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Requisicao");
                });

            modelBuilder.Entity("api.Models.Consulta", b =>
                {
                    b.HasOne("api.Models.Cobertura", "Cobertura")
                        .WithMany()
                        .HasForeignKey("CoberturaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api.Models.Receita", "Receita")
                        .WithMany()
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api.Models.Requisicao", "Requisicao")
                        .WithMany()
                        .HasForeignKey("RequisicaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api.Models.Medico", b =>
                {
                    b.HasOne("api.Models.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api.Models.Receita", b =>
                {
                    b.HasOne("api.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api.Models.Requisicao", b =>
                {
                    b.HasOne("api.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
