using Microsoft.EntityFrameworkCore.Migrations;

namespace Database_Project.Migrations
{
    public partial class RemoveUid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UID",
                table: "UserMusic");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "UserGenre");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "UserArtist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UID",
                table: "UserMusic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UID",
                table: "UserGenre",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UID",
                table: "UserArtist",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
