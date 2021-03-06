// <auto-generated />
using Database_Project.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database_Project.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210402011016_MusicUpdate")]
    partial class MusicUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.Artist", b =>
                {
                    b.Property<int>("ArtistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ArtistID");

                    b.HasIndex("GenreID");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("GenreID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.Music", b =>
                {
                    b.Property<int>("MusicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("YearReleased")
                        .HasColumnType("TEXT");

                    b.HasKey("MusicId");

                    b.HasIndex("ArtistID");

                    b.HasIndex("GenreID");

                    b.ToTable("Music");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.User", b =>
                {
                    b.Property<int>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("UID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.UserArtist", b =>
                {
                    b.Property<int>("UserArtistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserUID")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserArtistID");

                    b.HasIndex("ArtistID");

                    b.HasIndex("UserUID");

                    b.ToTable("UserArtist");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.UserGenre", b =>
                {
                    b.Property<int>("UserGenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserUID")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserGenreID");

                    b.HasIndex("GenreID");

                    b.HasIndex("UserUID");

                    b.ToTable("UserGenre");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.UserMusic", b =>
                {
                    b.Property<int>("UserMusicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MusicId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserUID")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserMusicID");

                    b.HasIndex("MusicId");

                    b.HasIndex("UserUID");

                    b.ToTable("UserMusic");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.Artist", b =>
                {
                    b.HasOne("Database_Project.Database.DatabaseModels.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.Music", b =>
                {
                    b.HasOne("Database_Project.Database.DatabaseModels.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database_Project.Database.DatabaseModels.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.UserArtist", b =>
                {
                    b.HasOne("Database_Project.Database.DatabaseModels.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database_Project.Database.DatabaseModels.User", null)
                        .WithMany("UserArtists")
                        .HasForeignKey("UserUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.UserGenre", b =>
                {
                    b.HasOne("Database_Project.Database.DatabaseModels.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database_Project.Database.DatabaseModels.User", null)
                        .WithMany("UserGenres")
                        .HasForeignKey("UserUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.UserMusic", b =>
                {
                    b.HasOne("Database_Project.Database.DatabaseModels.Music", "Music")
                        .WithMany()
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database_Project.Database.DatabaseModels.User", null)
                        .WithMany("UserMusic")
                        .HasForeignKey("UserUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Music");
                });

            modelBuilder.Entity("Database_Project.Database.DatabaseModels.User", b =>
                {
                    b.Navigation("UserArtists");

                    b.Navigation("UserGenres");

                    b.Navigation("UserMusic");
                });
#pragma warning restore 612, 618
        }
    }
}
