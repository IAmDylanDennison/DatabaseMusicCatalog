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
    }
}
