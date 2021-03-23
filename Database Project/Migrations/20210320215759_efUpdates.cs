using Microsoft.EntityFrameworkCore.Migrations;

namespace Database_Project.Migrations
{
    public partial class efUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "UserMusic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "UserGenre",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "UserArtist",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "UserMusic");

            migrationBuilder.DropColumn(
                name: "User",
                table: "UserGenre");

            migrationBuilder.DropColumn(
                name: "User",
                table: "UserArtist");
        }
    }
}
