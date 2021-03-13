using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Project.Database.DatabaseModels
{
    public class UserArtist
    {
        [Key]
        public int UserArtistID { get; set; }
        public User User { get; set; }
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
    }
}
