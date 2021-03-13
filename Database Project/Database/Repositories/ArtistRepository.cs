﻿using Database_Project.Database.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Project.Database.Repositories
{
    public class ArtistRepository
    {
        private DatabaseContext _context;
        public ArtistRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddArtist(Artist artist)
        {
            _context.Artist.Add(artist);
            _context.SaveChanges();
        }

        public void UpdateArtist(Artist artist)
        {
            _context.Artist.Update(artist);
            _context.SaveChanges();
        }

        public void DeleteArtist(Artist artist)
        {
            _context.Artist.Remove(artist);
            _context.SaveChanges();
        }
    }
}
