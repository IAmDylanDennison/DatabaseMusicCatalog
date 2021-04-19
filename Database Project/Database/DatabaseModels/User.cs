using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Database_Project.Database.DatabaseModels
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        // Eventually do Image
        public List<UserMusic> UserMusic { get; set; } // make sure this works
        public List<UserArtist> UserArtists { get; set; }
        public List<UserGenre> UserGenres { get; set; }
        public string Bio { get; set; }

        public User(User x)
        {
            UID = x.UID;
            FirstName = x.FirstName;
            LastName = x.LastName;
            Email = x.Email;
            UserMusic = new List<UserMusic>();
            foreach (var song in x.UserMusic)
                UserMusic.Add(new UserMusic(song));

            UserArtists = new List<UserArtist>();
            foreach (var artist in x.UserArtists)
                UserArtists.Add(new UserArtist(artist));

            UserGenres = x.UserGenres;
        }

        public User() { }
    }
}
