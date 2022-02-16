using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal2.Migrations
{
    public partial class Floresca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CadastroVoluntario_Atuacao_Id_Atuacao",
                table: "CadastroVoluntario");

            migrationBuilder.DropTable(
                name: "Atuacao");

            migrationBuilder.DropIndex(
                name: "IX_CadastroVoluntario_Id_Atuacao",
                table: "CadastroVoluntario");

            migrationBuilder.DropColumn(
                name: "Id_Atuacao",
                table: "CadastroVoluntario");

            migrationBuilder.AddColumn<bool>(
                name: "Geral",
                table: "CadastroVoluntario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Juridico",
                table: "CadastroVoluntario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Psicologia",
                table: "CadastroVoluntario",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Geral",
                table: "CadastroVoluntario");

            migrationBuilder.DropColumn(
                name: "Juridico",
                table: "CadastroVoluntario");

            migrationBuilder.DropColumn(
                name: "Psicologia",
                table: "CadastroVoluntario");

            migrationBuilder.AddColumn<int>(
                name: "Id_Atuacao",
                table: "CadastroVoluntario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Atuacao",
                columns: table => new
                {
                    Id_Atuacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atuacao", x => x.Id_Atuacao);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CadastroVoluntario_Id_Atuacao",
                table: "CadastroVoluntario",
                column: "Id_Atuacao");

            migrationBuilder.AddForeignKey(
                name: "FK_CadastroVoluntario_Atuacao_Id_Atuacao",
                table: "CadastroVoluntario",
                column: "Id_Atuacao",
                principalTable: "Atuacao",
                principalColumn: "Id_Atuacao",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
