using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Database_Project.Database.DatabaseModels
{
    public class Music
    {
        [Key]
        public int MusicId { get; set; }
        public string Name { get; set; }
        public string YearReleased { get; set; }
        public int Length { get; set; } // Int or string?
        public int ArtistID { get; set; }
        [ForeignKey("ArtistID")]
        public Artist Artist { get; set; }

        public int GenreID { get; set; }
        [ForeignKey("GenreID")]
        public Genre Genre { get; set; }

        public Music(Music x)
        {
            MusicId = x.MusicId;
            Name = x.Name;
            YearReleased = x.YearReleased;
            Length = x.Length;
            GenreID = x.GenreID;
            Genre = x.Genre;
            ArtistID = x.ArtistID;
            Artist = new Artist()
            {
                ArtistID = x.Artist.ArtistID,
                Genre = x.Artist.Genre,
                GenreID = x.Artist.GenreID,
                Name = x.Artist.Name
            };
        }

        public Music() { }
    }
}
