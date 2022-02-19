using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBoutique.DAL.EF.Data.Migrations
{
    public partial class FilmSessionIDFilmSessionChangeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_FilmSession_FilmSessionId1",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FilmSessionId1",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FilmSessionId1",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "FilmSessionId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShowDate",
                table: "FilmSession",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 21, 12, 43, 17, 923, DateTimeKind.Local).AddTicks(4643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 21, 3, 55, 45, 559, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FilmSessionId",
                table: "Tickets",
                column: "FilmSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_FilmSession_FilmSessionId",
                table: "Tickets",
                column: "FilmSessionId",
                principalTable: "FilmSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_FilmSession_FilmSessionId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FilmSessionId",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "FilmSessionId",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FilmSessionId1",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShowDate",
                table: "FilmSession",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 21, 3, 55, 45, 559, DateTimeKind.Local).AddTicks(286),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 21, 12, 43, 17, 923, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FilmSessionId1",
                table: "Tickets",
                column: "FilmSessionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_FilmSession_FilmSessionId1",
                table: "Tickets",
                column: "FilmSessionId1",
                principalTable: "FilmSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
