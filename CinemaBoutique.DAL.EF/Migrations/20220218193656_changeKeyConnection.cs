using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBoutique.DAL.EF.Data.Migrations
{
    public partial class changeKeyConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "FilmSession",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession",
                columns: new[] { "CinemaId", "FilmStripId", "ShowDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "FilmSession",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmSession",
                table: "FilmSession",
                columns: new[] { "CinemaId", "FilmStripId" });
        }
    }
}
