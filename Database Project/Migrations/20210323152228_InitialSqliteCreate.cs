using Microsoft.EntityFrameworkCore.Migrations;

namespace Database_Project.Migrations
{
    public partial class InitialSqliteCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Bio = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    GenreID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistID);
                    table.ForeignKey(
                        name: "FK_Artist_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGenre",
                columns: table => new
                {
                    UserGenreID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserUID = table.Column<int>(type: "INTEGER", nullable: false),
                    GenreID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGenre", x => x.UserGenreID);
                    table.ForeignKey(
                        name: "FK_UserGenre_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGenre_User_UserUID",
                        column: x => x.UserUID,
                        principalTable: "User",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    MusicId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    YearReleased = table.Column<string>(type: "TEXT", nullable: true),
                    Length = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtistID = table.Column<int>(type: "INTEGER", nullable: true),
                    GenreID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.MusicId);
                    table.ForeignKey(
                        name: "FK_Music_Artist_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artist",
                        principalColumn: "ArtistID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Music_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserArtist",
                columns: table => new
                {
                    UserArtistID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserUID = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtistID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserArtist", x => x.UserArtistID);
                    table.ForeignKey(
                        name: "FK_UserArtist_Artist_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artist",
                        principalColumn: "ArtistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserArtist_User_UserUID",
                        column: x => x.UserUID,
                        principalTable: "User",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMusic",
                columns: table => new
                {
                    UserMusicID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserUID = table.Column<int>(type: "INTEGER", nullable: false),
                    MusicId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMusic", x => x.UserMusicID);
                    table.ForeignKey(
                        name: "FK_UserMusic_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "MusicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMusic_User_UserUID",
                        column: x => x.UserUID,
                        principalTable: "User",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_GenreID",
                table: "Artist",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Music_ArtistID",
                table: "Music",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_Music_GenreID",
                table: "Music",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_UserArtist_ArtistID",
                table: "UserArtist",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_UserArtist_UserUID",
                table: "UserArtist",
                column: "UserUID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGenre_GenreID",
                table: "UserGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGenre_UserUID",
                table: "UserGenre",
                column: "UserUID");

            migrationBuilder.CreateIndex(
                name: "IX_UserMusic_MusicId",
                table: "UserMusic",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMusic_UserUID",
                table: "UserMusic",
                column: "UserUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserArtist");

            migrationBuilder.DropTable(
                name: "UserGenre");

            migrationBuilder.DropTable(
                name: "UserMusic");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
