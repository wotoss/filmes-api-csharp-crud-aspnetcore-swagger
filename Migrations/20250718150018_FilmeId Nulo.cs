using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    /// <inheritdoc />
    public partial class FilmeIdNulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessaos_Filmes_FilmeId",
                table: "Sessaos");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessaos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessaos_Filmes_FilmeId",
                table: "Sessaos",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessaos_Filmes_FilmeId",
                table: "Sessaos");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessaos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessaos_Filmes_FilmeId",
                table: "Sessaos",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
