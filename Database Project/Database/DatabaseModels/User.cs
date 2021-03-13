using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Database_Project.Database.DatabaseModels
{
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
        public List<UserArtist> UserArtists { get; set; } // fix later
        public List<UserGenre> UserGenres { get; set; }
        public string Bio { get; set; }
    }
}
