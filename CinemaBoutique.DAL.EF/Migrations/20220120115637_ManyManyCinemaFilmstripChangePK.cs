using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBoutique.DAL.EF.Data.Migrations
{
    public partial class ManyManyCinemaFilmstripChangePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaFilmStrip",
                table: "CinemaFilmStrip");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CinemaFilmStrip");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaFilmStrip",
                table: "CinemaFilmStrip",
                columns: new[] { "CinemaId", "FilmStripId", "ShowDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaFilmStrip",
                table: "CinemaFilmStrip");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CinemaFilmStrip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaFilmStrip",
                table: "CinemaFilmStrip",
                columns: new[] { "CinemaId", "FilmStripId", "Id" });
        }
    }
}
