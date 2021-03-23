using Microsoft.EntityFrameworkCore.Migrations;

namespace Database_Project.Migrations
{
    public partial class ChangeUIDForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserArtist_User_UserUID",
                table: "UserArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGenre_User_UserUID",
                table: "UserGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMusic_User_UserUID",
                table: "UserMusic");

            migrationBuilder.DropColumn(
                name: "User",
                table: "UserMusic");

            migrationBuilder.DropColumn(
                name: "User",
                table: "UserGenre");

            migrationBuilder.DropColumn(
                name: "User",
                table: "UserArtist");

            migrationBuilder.AlterColumn<int>(
                name: "UserUID",
                table: "UserMusic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserUID",
                table: "UserGenre",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserUID",
                table: "UserArtist",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserArtist_User_UserUID",
                table: "UserArtist",
                column: "UserUID",
                principalTable: "User",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGenre_User_UserUID",
                table: "UserGenre",
                column: "UserUID",
                principalTable: "User",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMusic_User_UserUID",
                table: "UserMusic",
                column: "UserUID",
                principalTable: "User",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserArtist_User_UserUID",
                table: "UserArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGenre_User_UserUID",
                table: "UserGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMusic_User_UserUID",
                table: "UserMusic");

            migrationBuilder.AlterColumn<int>(
                name: "UserUID",
                table: "UserMusic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "UserMusic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserUID",
                table: "UserGenre",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "UserGenre",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserUID",
                table: "UserArtist",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "UserArtist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserArtist_User_UserUID",
                table: "UserArtist",
                column: "UserUID",
                principalTable: "User",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGenre_User_UserUID",
                table: "UserGenre",
                column: "UserUID",
                principalTable: "User",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMusic_User_UserUID",
                table: "UserMusic",
                column: "UserUID",
                principalTable: "User",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
