using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OBarbeiro.Infra.Migrations
{
    /// <inheritdoc />
    public partial class criandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AgendamentoStatus",
                schema: "dbo",
                columns: table => new
                {
                    agendamentoStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoStatus", x => x.agendamentoStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUsuario",
                schema: "dbo",
                columns: table => new
                {
                    perfilUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    perfil = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuario", x => x.perfilUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "dbo",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PerfilUsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.email);
                    table.ForeignKey(
                        name: "FK_Usuarios_PerfilUsuario_PerfilUsuarioId",
                        column: x => x.PerfilUsuarioId,
                        principalSchema: "dbo",
                        principalTable: "PerfilUsuario",
                        principalColumn: "perfilUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "dbo",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    dataNascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    dataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.email);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_UsuarioEmail",
                        column: x => x.UsuarioEmail,
                        principalSchema: "dbo",
                        principalTable: "Usuarios",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                schema: "dbo",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nomeBarbearia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    dataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    logradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.email);
                    table.ForeignKey(
                        name: "FK_Empresas_Usuarios_UsuarioEmail",
                        column: x => x.UsuarioEmail,
                        principalSchema: "dbo",
                        principalTable: "Usuarios",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profissional",
                schema: "dbo",
                columns: table => new
                {
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dataNascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    EmpresaEmail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissional", x => x.cpf);
                    table.ForeignKey(
                        name: "FK_Profissional_Empresas_EmpresaEmail",
                        column: x => x.EmpresaEmail,
                        principalSchema: "dbo",
                        principalTable: "Empresas",
                        principalColumn: "email");
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                schema: "dbo",
                columns: table => new
                {
                    servicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    EmpresaEmail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.servicoId);
                    table.ForeignKey(
                        name: "FK_Servicos_Empresas_EmpresaEmail",
                        column: x => x.EmpresaEmail,
                        principalSchema: "dbo",
                        principalTable: "Empresas",
                        principalColumn: "email");
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                schema: "dbo",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfissionalCpf = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    AgendamentoStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamentos_AgendamentoStatus_AgendamentoStatusId",
                        column: x => x.AgendamentoStatusId,
                        principalSchema: "dbo",
                        principalTable: "AgendamentoStatus",
                        principalColumn: "agendamentoStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Clientes_ClienteEmail",
                        column: x => x.ClienteEmail,
                        principalSchema: "dbo",
                        principalTable: "Clientes",
                        principalColumn: "email");
                    table.ForeignKey(
                        name: "FK_Agendamentos_Profissional_ProfissionalCpf",
                        column: x => x.ProfissionalCpf,
                        principalSchema: "dbo",
                        principalTable: "Profissional",
                        principalColumn: "cpf");
                });

            migrationBuilder.CreateTable(
                name: "AgendaProfissional",
                schema: "dbo",
                columns: table => new
                {
                    agendaProfissionalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diaSemana = table.Column<DateTime>(type: "DATE", nullable: false),
                    horaInicioExpediente = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaInicioAlmoco = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaFimAlmoco = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaFimExpediente = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfissionalCpf = table.Column<string>(type: "nvarchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaProfissional", x => x.agendaProfissionalId);
                    table.ForeignKey(
                        name: "FK_AgendaProfissional_Profissional_ProfissionalCpf",
                        column: x => x.ProfissionalCpf,
                        principalSchema: "dbo",
                        principalTable: "Profissional",
                        principalColumn: "cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AgendamentoStatus",
                columns: new[] { "agendamentoStatusId", "descricao" },
                values: new object[,]
                {
                    { 1, "Agendado" },
                    { 2, "Cancelado" },
                    { 3, "Concluído" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PerfilUsuario",
                columns: new[] { "perfilUsuarioId", "descricao", "perfil" },
                values: new object[,]
                {
                    { 1, "Gerenciamento geral do sistema.", "Admin" },
                    { 2, "Acesso cliente", "Cliente" },
                    { 3, "Acesso empresa", "Empresa" },
                    { 4, "Acesso colaborador", "Colaborador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_AgendamentoStatusId",
                schema: "dbo",
                table: "Agendamentos",
                column: "AgendamentoStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ClienteEmail",
                schema: "dbo",
                table: "Agendamentos",
                column: "ClienteEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ProfissionalCpf",
                schema: "dbo",
                table: "Agendamentos",
                column: "ProfissionalCpf");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaProfissional_ProfissionalCpf",
                schema: "dbo",
                table: "AgendaProfissional",
                column: "ProfissionalCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioEmail",
                schema: "dbo",
                table: "Clientes",
                column: "UsuarioEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_UsuarioEmail",
                schema: "dbo",
                table: "Empresas",
                column: "UsuarioEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profissional_EmpresaEmail",
                schema: "dbo",
                table: "Profissional",
                column: "EmpresaEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_EmpresaEmail",
                schema: "dbo",
                table: "Servicos",
                column: "EmpresaEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilUsuarioId",
                schema: "dbo",
                table: "Usuarios",
                column: "PerfilUsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AgendaProfissional",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Servicos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AgendamentoStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Profissional",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Empresas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PerfilUsuario",
                schema: "dbo");
        }
    }
}
