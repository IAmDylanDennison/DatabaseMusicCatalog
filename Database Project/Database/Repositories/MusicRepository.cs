using Database_Project.Database.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Project.Database.Repositories
{
    public class MusicRepository
    {
        private DatabaseContext _context;
        public MusicRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddMusic(Music music)
        {
            _context.Music.Add(music);
            _context.SaveChanges();
        }

        public void UpdateMusic(Music music)
        {
            _context.Music.Update(music);
            _context.SaveChanges();
        }

        public void DeleteMusic(Music music)
        {
            _context.Music.Remove(music);
            _context.SaveChanges();
        }

        public List<Music> GetAll()
        {
            return _context.Music
                .Include(m => m.Genre)
                .Include(m => m.Artist)
                .Select(x => new Music(x))
                .IgnoreAutoIncludes()
                .ToList();
        }

        public Music GetById(int id)
        {
            return _context.Music
                .Include(m => m.Artist)
                .Include(m => m.Genre)
                .Select(x => new Music(x))
                .IgnoreAutoIncludes()
                .Where(x => x.MusicId == id).FirstOrDefault();
        }
    }
}
