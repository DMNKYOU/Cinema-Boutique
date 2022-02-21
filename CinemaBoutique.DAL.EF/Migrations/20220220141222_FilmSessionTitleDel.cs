using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBoutique.DAL.EF.Data.Migrations
{
    public partial class FilmSessionTitleDel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "FilmSession");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "FilmSession",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Title session");
        }
    }
}
