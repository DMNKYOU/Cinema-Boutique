using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBoutique.DAL.EF.Data.Migrations
{
    public partial class FilmSessionWithID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShowDate",
                table: "FilmSession",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 20, 19, 44, 10, 181, DateTimeKind.Local).AddTicks(6961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FilmSession",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FilmSession_CinemaId",
                table: "FilmSession",
                column: "CinemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession");

            migrationBuilder.DropIndex(
                name: "IX_FilmSession_CinemaId",
                table: "FilmSession");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FilmSession");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShowDate",
                table: "FilmSession",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 20, 19, 44, 10, 181, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession",
                columns: new[] { "CinemaId", "FilmStripId", "ShowDate" });
        }
    }
}
