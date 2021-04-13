using Database_Project.Database.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Project.Database.Repositories
{
    public class GenreRepository
    {
        private DatabaseContext _context;
        public GenreRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddGenre(Genre genre)
        {
            _context.Genre.Add(genre);
            _context.SaveChanges();
        }

        public void UpdateGenre(Genre genre)
        {
            _context.Genre.Update(genre);
            _context.SaveChanges();
        }

        public void DeleteGenre(Genre genre)
        {
            _context.Genre.Remove(genre);
            _context.SaveChanges();
        }

        public List<Genre> GetAll()
        {
            return _context.Genre.ToList();
        }

        public Genre Get(int id)
        {
            return _context.Genre.Find(id);
        }
    }
}
