using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Project.Database.DatabaseModels
{
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; }
        public string Name { get; set; }

        public int GenreID { get; set; }
        [ForeignKey("GenreID")] 
        public Genre Genre { get; set; }
        // Image
        public List<Music> ArtistMusic { get; set; }

        public Artist(Artist x)
        {
            ArtistID = x.ArtistID;
            Name = x.Name;
            GenreID = x.GenreID;
            Genre = x.Genre;
            foreach (var music in x.ArtistMusic)
            {
                ArtistMusic.Add(new Music()
                {
                    MusicId = music.MusicId,
                    ArtistID = ArtistID,
                    Genre = music.Genre,
                    GenreID = music.GenreID,
                    Length = music.Length,
                    Name = music.Name,
                    YearReleased = music.YearReleased
                });
            }
        }

        public Artist() { }
    }
}
