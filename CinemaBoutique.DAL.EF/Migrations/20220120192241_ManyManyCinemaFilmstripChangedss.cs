using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBoutique.DAL.EF.Data.Migrations
{
    public partial class ManyManyCinemaFilmstripChangedss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaFilmStrip_Cinemas_CinemaId",
                table: "CinemaFilmStrip");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaFilmStrip_FilmStrips_FilmStripId",
                table: "CinemaFilmStrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaFilmStrip",
                table: "CinemaFilmStrip");

            migrationBuilder.RenameTable(
                name: "CinemaFilmStrip",
                newName: "FilmSession");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaFilmStrip_FilmStripId",
                table: "FilmSession",
                newName: "IX_FilmSession_FilmStripId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession",
                columns: new[] { "CinemaId", "FilmStripId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_FilmSession_Cinemas_CinemaId",
                table: "FilmSession",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmSession_FilmStrips_FilmStripId",
                table: "FilmSession",
                column: "FilmStripId",
                principalTable: "FilmStrips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmSession_Cinemas_CinemaId",
                table: "FilmSession");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmSession_FilmStrips_FilmStripId",
                table: "FilmSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession");

            migrationBuilder.RenameTable(
                name: "FilmSession",
                newName: "CinemaFilmStrip");

            migrationBuilder.RenameIndex(
                name: "IX_FilmSession_FilmStripId",
                table: "CinemaFilmStrip",
                newName: "IX_CinemaFilmStrip_FilmStripId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaFilmStrip",
                table: "CinemaFilmStrip",
                columns: new[] { "CinemaId", "FilmStripId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaFilmStrip_Cinemas_CinemaId",
                table: "CinemaFilmStrip",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaFilmStrip_FilmStrips_FilmStripId",
                table: "CinemaFilmStrip",
                column: "FilmStripId",
                principalTable: "FilmStrips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
