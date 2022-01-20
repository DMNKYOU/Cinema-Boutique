using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBoutique.DAL.EF.Data.Migrations
{
    public partial class ManyManyCinemaFilmstripID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaFilmStrip_Cinemas_CinemasId",
                table: "CinemaFilmStrip");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaFilmStrip_FilmStrips_FilmStripsId",
                table: "CinemaFilmStrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaFilmStrip",
                table: "CinemaFilmStrip");

            migrationBuilder.DropIndex(
                name: "IX_CinemaFilmStrip_FilmStripsId",
                table: "CinemaFilmStrip");

            migrationBuilder.RenameColumn(
                name: "FilmStripsId",
                table: "CinemaFilmStrip",
                newName: "SessionPrice");

            migrationBuilder.RenameColumn(
                name: "CinemasId",
                table: "CinemaFilmStrip",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "CinemaFilmStrip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilmStripId",
                table: "CinemaFilmStrip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShowDate",
                table: "CinemaFilmStrip",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CinemaFilmStrip",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaFilmStrip",
                table: "CinemaFilmStrip",
                columns: new[] { "CinemaId", "FilmStripId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaFilmStrip_FilmStripId",
                table: "CinemaFilmStrip",
                column: "FilmStripId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_CinemaFilmStrip_FilmStripId",
                table: "CinemaFilmStrip");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "CinemaFilmStrip");

            migrationBuilder.DropColumn(
                name: "FilmStripId",
                table: "CinemaFilmStrip");

            migrationBuilder.DropColumn(
                name: "ShowDate",
                table: "CinemaFilmStrip");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CinemaFilmStrip");

            migrationBuilder.RenameColumn(
                name: "SessionPrice",
                table: "CinemaFilmStrip",
                newName: "FilmStripsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CinemaFilmStrip",
                newName: "CinemasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaFilmStrip",
                table: "CinemaFilmStrip",
                columns: new[] { "CinemasId", "FilmStripsId" });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaFilmStrip_FilmStripsId",
                table: "CinemaFilmStrip",
                column: "FilmStripsId");

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
    }
}
