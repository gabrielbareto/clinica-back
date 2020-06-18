using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class ConexaoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Requisicao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Receita",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadeId",
                table: "Medico",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoberturaId",
                table: "Consulta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Consulta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Consulta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceitaId",
                table: "Consulta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequisicaoId",
                table: "Consulta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requisicao_PacienteId",
                table: "Requisicao",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_PacienteId",
                table: "Receita",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_EspecialidadeId",
                table: "Medico",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_CoberturaId",
                table: "Consulta",
                column: "CoberturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MedicoId",
                table: "Consulta",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_ReceitaId",
                table: "Consulta",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_RequisicaoId",
                table: "Consulta",
                column: "RequisicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Cobertura_CoberturaId",
                table: "Consulta",
                column: "CoberturaId",
                principalTable: "Cobertura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Medico_MedicoId",
                table: "Consulta",
                column: "MedicoId",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Paciente_PacienteId",
                table: "Consulta",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Receita_ReceitaId",
                table: "Consulta",
                column: "ReceitaId",
                principalTable: "Receita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Requisicao_RequisicaoId",
                table: "Consulta",
                column: "RequisicaoId",
                principalTable: "Requisicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Especialidade_EspecialidadeId",
                table: "Medico",
                column: "EspecialidadeId",
                principalTable: "Especialidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receita_Paciente_PacienteId",
                table: "Receita",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisicao_Paciente_PacienteId",
                table: "Requisicao",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Cobertura_CoberturaId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Medico_MedicoId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Paciente_PacienteId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Receita_ReceitaId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Requisicao_RequisicaoId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Especialidade_EspecialidadeId",
                table: "Medico");

            migrationBuilder.DropForeignKey(
                name: "FK_Receita_Paciente_PacienteId",
                table: "Receita");

            migrationBuilder.DropForeignKey(
                name: "FK_Requisicao_Paciente_PacienteId",
                table: "Requisicao");

            migrationBuilder.DropIndex(
                name: "IX_Requisicao_PacienteId",
                table: "Requisicao");

            migrationBuilder.DropIndex(
                name: "IX_Receita_PacienteId",
                table: "Receita");

            migrationBuilder.DropIndex(
                name: "IX_Medico_EspecialidadeId",
                table: "Medico");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_CoberturaId",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_MedicoId",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_ReceitaId",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_RequisicaoId",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Requisicao");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "EspecialidadeId",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "CoberturaId",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "ReceitaId",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "RequisicaoId",
                table: "Consulta");
        }
    }
}
