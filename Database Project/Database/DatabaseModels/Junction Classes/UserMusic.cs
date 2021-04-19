using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Project.Database.DatabaseModels
{
    public class UserMusic
    {
        [Key]
        public int UserMusicID { get; set; }
        [ForeignKey("User")]
        public int UserUID { get; set; }

        public int MusicId { get; set; }
        public Music Music { get; set; }

        public UserMusic(UserMusic x)
        {
            UserMusicID = x.UserMusicID;
            UserUID = x.UserUID;
            MusicId = x.MusicId;
            Music = new Music(x.Music);
        }

        public UserMusic() { }
    }
}
