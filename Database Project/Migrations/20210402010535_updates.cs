using Microsoft.EntityFrameworkCore.Migrations;

namespace Database_Project.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_Artist_ArtistID",
                table: "Music");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                table: "Music",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Artist_ArtistID",
                table: "Music",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ArtistID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_Artist_ArtistID",
                table: "Music");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                table: "Music",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Artist_ArtistID",
                table: "Music",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ArtistID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
