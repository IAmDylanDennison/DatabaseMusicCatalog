using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Project.Database.DatabaseModels
{
    public class UserArtist
    {
        [Key]
        public int UserArtistID { get; set; }
        [ForeignKey("User")]
        public int UserUID { get; set; }
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
    }
}
