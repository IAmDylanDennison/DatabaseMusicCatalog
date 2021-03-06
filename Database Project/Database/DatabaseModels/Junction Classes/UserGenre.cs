using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Project.Database.DatabaseModels
{
    public class UserGenre
    {
        [Key]
        public int UserGenreID { get; set; }
        [ForeignKey("User")]
        public int UserUID { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
