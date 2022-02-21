using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBoutique.DAL.EF.Data.Migrations
{
    public partial class ManyManyCinemaFilmstrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilmStrip_FilmStrip_FilmStripsId",
                table: "ActorFilmStrip");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmSession_Cinemas_CinemasId",
                table: "FilmSession");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmSession_FilmStrip_FilmStripsId",
                table: "FilmSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmStrip",
                table: "FilmStrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession");

            migrationBuilder.RenameTable(
                name: "FilmStrip",
                newName: "FilmStrips");

            migrationBuilder.RenameTable(
                name: "FilmSession",
                newName: "CinemaFilmStrip");

            migrationBuilder.RenameIndex(
                name: "IX_FilmSession_FilmStripsId",
                table: "CinemaFilmStrip",
                newName: "IX_CinemaFilmStrip_FilmStripsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmStrips",
                table: "FilmStrips",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaFilmStrip",
                table: "CinemaFilmStrip",
                columns: new[] { "CinemasId", "FilmStripsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilmStrip_FilmStrips_FilmStripsId",
                table: "ActorFilmStrip",
                column: "FilmStripsId",
                principalTable: "FilmStrips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaFilmStrip_Cinemas_CinemasId",
                table: "CinemaFilmStrip",
                column: "CinemasId",
                principalTable: "Cinemas",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorFilmStrip_FilmStrips_FilmStripsId",
                table: "ActorFilmStrip");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaFilmStrip_Cinemas_CinemasId",
                table: "CinemaFilmStrip");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaFilmStrip_FilmStrips_FilmStripsId",
                table: "CinemaFilmStrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmStrips",
                table: "FilmStrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaFilmStrip",
                table: "CinemaFilmStrip");

            migrationBuilder.RenameTable(
                name: "FilmStrips",
                newName: "FilmStrip");

            migrationBuilder.RenameTable(
                name: "CinemaFilmStrip",
                newName: "FilmSession");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaFilmStrip_FilmStripsId",
                table: "FilmSession",
                newName: "IX_FilmSession_FilmStripsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmStrip",
                table: "FilmStrip",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession",
                columns: new[] { "CinemasId", "FilmStripsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorFilmStrip_FilmStrip_FilmStripsId",
                table: "ActorFilmStrip",
                column: "FilmStripsId",
                principalTable: "FilmStrip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmSession_Cinemas_CinemasId",
                table: "FilmSession",
                column: "CinemasId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmSession_FilmStrip_FilmStripsId",
                table: "FilmSession",
                column: "FilmStripsId",
                principalTable: "FilmStrip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
