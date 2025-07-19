using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    /// <inheritdoc />
    public partial class SessaoeCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Sessaos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessaos_CinemaId",
                table: "Sessaos",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessaos_Cinemas_CinemaId",
                table: "Sessaos",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessaos_Cinemas_CinemaId",
                table: "Sessaos");

            migrationBuilder.DropIndex(
                name: "IX_Sessaos_CinemaId",
                table: "Sessaos");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Sessaos");
        }
    }
}
