using Database_Project.Database.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Project.Database.Repositories
{
    public class UserRepository
    {
        public DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public User GetUser(string email)
        {
            return _context.User.Where(x => x.Email == email).FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public void AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public void AddUserGenre(Genre genre, User user) // test to make sure works
        {
            var userGenre = new UserGenre()
            {
                Genre = genre,
                User = user
            };

            _context.UserGenre.Add(userGenre);
            _context.SaveChanges();
        }

        public void AddUserArtist(Artist artist, User user)
        {
            var userArtist = new UserArtist()
            {
                Artist = artist,
                User = user
            };

            _context.UserArtist.Add(userArtist);
            _context.SaveChanges();
        }

        public void AddUserMusic(Music music, User user)
        {
            var userMusic = new UserMusic()
            {
                Music = music,
                User = user
            };

            _context.UserMusic.Add(userMusic);
            _context.SaveChanges();
        }
    }
}
