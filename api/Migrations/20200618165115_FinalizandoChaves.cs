using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class FinalizandoChaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Medico",
                newName: "Nome");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Paciente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Crm",
                table: "Medico",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Crm",
                table: "Medico");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Medico",
                newName: "Descricao");
        }
    }
}
