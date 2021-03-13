using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Project.Database.DatabaseModels
{
    public class UserMusic
    {
        [Key]
        public int UserMusicID { get; set; }

        public User User { get; set; }

        public int MusicId { get; set; }
        public Music Music { get; set; }
    }
}
