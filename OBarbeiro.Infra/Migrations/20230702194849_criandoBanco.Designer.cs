﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OBarbeiro.Infra.Contexts;

#nullable disable

namespace OBarbeiro.Infra.Migrations
{
    [DbContext(typeof(OBarbeiroDbContext))]
    [Migration("20230702194849_criandoBanco")]
    partial class criandoBanco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.AgendaProfissional", b =>
                {
                    b.Property<int>("AgendaProfissionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("agendaProfissionalId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgendaProfissionalId"));

                    b.Property<DateTime>("DiaSemana")
                        .HasColumnType("DATE")
                        .HasColumnName("diaSemana");

                    b.Property<DateTime>("HoraFimAlmoco")
                        .HasColumnType("datetime2")
                        .HasColumnName("horaFimAlmoco");

                    b.Property<DateTime>("HoraFimExpediente")
                        .HasColumnType("datetime2")
                        .HasColumnName("horaFimExpediente");

                    b.Property<DateTime>("HoraInicioAlmoco")
                        .HasColumnType("datetime2")
                        .HasColumnName("horaInicioAlmoco");

                    b.Property<DateTime>("HoraInicioExpediente")
                        .HasColumnType("datetime2")
                        .HasColumnName("horaInicioExpediente");

                    b.Property<string>("ProfissionalCpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("AgendaProfissionalId");

                    b.HasIndex("ProfissionalCpf");

                    b.ToTable("AgendaProfissional", "dbo");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Agendamento", b =>
                {
                    b.Property<int>("AgendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AgendamentoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgendamentoId"));

                    b.Property<int>("AgendamentoStatusId")
                        .HasColumnType("int");

                    b.Property<string>("ClienteEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("datetime2")
                        .HasColumnName("dataAgendamento");

                    b.Property<string>("ProfissionalCpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("AgendamentoId");

                    b.HasIndex("AgendamentoStatusId")
                        .IsUnique();

                    b.HasIndex("ClienteEmail");

                    b.HasIndex("ProfissionalCpf");

                    b.ToTable("Agendamentos", "dbo");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.AgendamentoStatus", b =>
                {
                    b.Property<int>("AgendamentoStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("agendamentoStatusId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgendamentoStatusId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("descricao");

                    b.HasKey("AgendamentoStatusId");

                    b.ToTable("AgendamentoStatus", "dbo");

                    b.HasData(
                        new
                        {
                            AgendamentoStatusId = 1,
                            Descricao = "Agendado"
                        },
                        new
                        {
                            AgendamentoStatusId = 2,
                            Descricao = "Cancelado"
                        },
                        new
                        {
                            AgendamentoStatusId = 3,
                            Descricao = "Concluído"
                        });
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Cliente", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("email");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("celular");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dataAlteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dataInclusao");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATE")
                        .HasColumnName("dataNascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.Property<string>("UsuarioEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Email");

                    b.HasIndex("UsuarioEmail")
                        .IsUnique();

                    b.ToTable("Clientes", "dbo");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Empresa", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("email");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("celular");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("cidade");

                    b.Property<string>("Complemento")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("complemento");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dataAlteracao");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dataInclusao");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("logradouro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("NomeBarbearia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nomeBarbearia");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("numero");

                    b.Property<string>("Telefone")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("telefone");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("uf");

                    b.Property<string>("UsuarioEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Email");

                    b.HasIndex("UsuarioEmail")
                        .IsUnique();

                    b.ToTable("Empresas", "dbo");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.PerfilUsuario", b =>
                {
                    b.Property<int>("PerfilUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("perfilUsuarioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PerfilUsuarioId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("descricao");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("perfil");

                    b.HasKey("PerfilUsuarioId");

                    b.ToTable("PerfilUsuario", "dbo");

                    b.HasData(
                        new
                        {
                            PerfilUsuarioId = 1,
                            Descricao = "Gerenciamento geral do sistema.",
                            Perfil = "Admin"
                        },
                        new
                        {
                            PerfilUsuarioId = 2,
                            Descricao = "Acesso cliente",
                            Perfil = "Cliente"
                        },
                        new
                        {
                            PerfilUsuarioId = 3,
                            Descricao = "Acesso empresa",
                            Perfil = "Empresa"
                        },
                        new
                        {
                            PerfilUsuarioId = 4,
                            Descricao = "Acesso colaborador",
                            Perfil = "Colaborador"
                        });
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Profissional", b =>
                {
                    b.Property<string>("Cpf")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("cpf");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("celular");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATE")
                        .HasColumnName("dataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("EmpresaEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Cpf");

                    b.HasIndex("EmpresaEmail");

                    b.ToTable("Profissional", "dbo");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Servico", b =>
                {
                    b.Property<int>("ServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("servicoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServicoId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("descricao");

                    b.Property<string>("EmpresaEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Preco")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("preco");

                    b.HasKey("ServicoId");

                    b.HasIndex("EmpresaEmail");

                    b.ToTable("Servicos", "dbo");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Usuario", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<int>("PerfilUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("senha");

                    b.HasKey("Email");

                    b.HasIndex("PerfilUsuarioId")
                        .IsUnique();

                    b.ToTable("Usuarios", "dbo");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.AgendaProfissional", b =>
                {
                    b.HasOne("OBarbeiro.Modelo.Modelos.Profissional", "Profissional")
                        .WithMany("AgendaProfissional")
                        .HasForeignKey("ProfissionalCpf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Agendamento", b =>
                {
                    b.HasOne("OBarbeiro.Modelo.Modelos.AgendamentoStatus", "AgendamentoStatus")
                        .WithOne("Agendamento")
                        .HasForeignKey("OBarbeiro.Modelo.Modelos.Agendamento", "AgendamentoStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBarbeiro.Modelo.Modelos.Cliente", "Cliente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ClienteEmail")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("OBarbeiro.Modelo.Modelos.Profissional", "Profissional")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ProfissionalCpf")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("AgendamentoStatus");

                    b.Navigation("Cliente");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Cliente", b =>
                {
                    b.HasOne("OBarbeiro.Modelo.Modelos.Usuario", "Usuario")
                        .WithOne("Cliente")
                        .HasForeignKey("OBarbeiro.Modelo.Modelos.Cliente", "UsuarioEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Empresa", b =>
                {
                    b.HasOne("OBarbeiro.Modelo.Modelos.Usuario", "Usuario")
                        .WithOne("Empresa")
                        .HasForeignKey("OBarbeiro.Modelo.Modelos.Empresa", "UsuarioEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Profissional", b =>
                {
                    b.HasOne("OBarbeiro.Modelo.Modelos.Empresa", "Empresa")
                        .WithMany("Profissionais")
                        .HasForeignKey("EmpresaEmail")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Servico", b =>
                {
                    b.HasOne("OBarbeiro.Modelo.Modelos.Empresa", "Empresa")
                        .WithMany("Servicos")
                        .HasForeignKey("EmpresaEmail")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Usuario", b =>
                {
                    b.HasOne("OBarbeiro.Modelo.Modelos.PerfilUsuario", "PerfilUsuario")
                        .WithOne("Usuario")
                        .HasForeignKey("OBarbeiro.Modelo.Modelos.Usuario", "PerfilUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerfilUsuario");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.AgendamentoStatus", b =>
                {
                    b.Navigation("Agendamento");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Cliente", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Empresa", b =>
                {
                    b.Navigation("Profissionais");

                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.PerfilUsuario", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Profissional", b =>
                {
                    b.Navigation("AgendaProfissional");

                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("OBarbeiro.Modelo.Modelos.Usuario", b =>
                {
                    b.Navigation("Cliente");

                    b.Navigation("Empresa");
                });
#pragma warning restore 612, 618
        }
    }
}