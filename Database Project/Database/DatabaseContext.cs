using Database_Project.Database.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Project.Database
{
    public class DatabaseContext  : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=database.db");
        }
        public DbSet<User> User { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Genre> Genre { get; set; }

        // Many to many junction tables
        public DbSet<UserArtist> UserArtist { get; set; }
        public DbSet<UserMusic> UserMusic { get; set; }
        public DbSet<UserGenre> UserGenre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(c => c.UserArtists);
            modelBuilder.Entity<User>()
                .HasMany(c => c.UserMusic);
            modelBuilder.Entity<User>()
                .HasMany(c => c.UserGenres);

            modelBuilder.Entity<Music>()
                .HasOne(c => c.Artist);
            modelBuilder.Entity<Music>()
                .HasOne(c => c.Genre);

            modelBuilder.Entity<Artist>()
                .HasOne(c => c.Genre);
            modelBuilder.Entity<Artist>()
                .HasMany(c => c.ArtistMusic);


            modelBuilder.Entity<UserMusic>()
                .HasOne(c => c.Music);
            modelBuilder.Entity<UserGenre>()
                .HasOne(c => c.Genre);
            modelBuilder.Entity<UserArtist>()
                .HasOne(c => c.Artist);
        }
    }
}
