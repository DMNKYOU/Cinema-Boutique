using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBoutique.DAL.EF.Data.Migrations
{
    public partial class CinemaFilmStri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilmStrip_FilmStrips_FilmStripsId",
                table: "ActorFilmStrip");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaFilmStrip_FilmStrips_FilmStripsId",
                table: "CinemaFilmStrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmStrips",
                table: "FilmStrips");

            migrationBuilder.RenameTable(
                name: "FilmStrips",
                newName: "FilmStrip");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmStrip",
                table: "FilmStrip",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilmStrip_FilmStrip_FilmStripsId",
                table: "ActorFilmStrip",
                column: "FilmStripsId",
                principalTable: "FilmStrip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaFilmStrip_FilmStrip_FilmStripsId",
                table: "CinemaFilmStrip",
                column: "FilmStripsId",
                principalTable: "FilmStrip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilmStrip_FilmStrip_FilmStripsId",
                table: "ActorFilmStrip");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaFilmStrip_FilmStrip_FilmStripsId",
                table: "CinemaFilmStrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmStrip",
                table: "FilmStrip");

            migrationBuilder.RenameTable(
                name: "FilmStrip",
                newName: "FilmStrips");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmStrips",
                table: "FilmStrips",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilmStrip_FilmStrips_FilmStripsId",
                table: "ActorFilmStrip",
                column: "FilmStripsId",
                principalTable: "FilmStrips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaFilmStrip_FilmStrips_FilmStripsId",
                table: "CinemaFilmStrip",
                column: "FilmStripsId",
                principalTable: "FilmStrips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
