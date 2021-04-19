using Database_Project.Database.DatabaseModels;
using Microsoft.EntityFrameworkCore;
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
            return _context.User
                .Where(x => x.Email == email)
                .Include(x => x.UserArtists)
                .ThenInclude(x => x.Artist)
                .Include(x => x.UserMusic)
                .ThenInclude(x => x.Music)
                .Include(x => x.UserGenres)
                .ThenInclude(x => x.Genre)
                .Select(x => new User(x))
                .FirstOrDefault();
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

        public void AddUserGenre(UserGenre userGenre) // test to make sure works
        {
            _context.UserGenre.Add(userGenre);
            _context.SaveChanges();
        }

        public void AddUserArtist(UserArtist userArtist)
        {
            _context.UserArtist.Add(userArtist);
            _context.SaveChanges();
        }

        public void AddUserMusic(UserMusic userMusic)
        {
            _context.UserMusic.Add(userMusic);
            _context.SaveChanges();
        }
        
        public List<UserGenre> GetUserGenres(int uid)
        {
            return _context.UserGenre.Where(x => x.UserUID == uid).ToList();
        }

        public List<UserArtist> GetUserArtists(int uid)
        {
            return _context.UserArtist.Where(x => x.UserUID == uid).ToList();
        }

        public List<UserMusic> GetUserMusic(int uid)
        {
            return _context.UserMusic.Where(x => x.UserUID == uid).ToList();
        }

        public void DeleteUserMusic(UserMusic userMusic)
        {
            var toRemove = _context.UserMusic
                .Where(x => x.MusicId == userMusic.MusicId
                && x.UserUID == userMusic.UserUID)
                .FirstOrDefault();
            _context.UserMusic.Remove(toRemove);
            _context.SaveChanges();
        }

        public void DeleteUserArtist(UserArtist userArtist)
        {
            var toRemove = _context.UserArtist
                .Where(x => x.ArtistID == userArtist.ArtistID
                && x.UserUID == userArtist.UserUID)
                .FirstOrDefault();
            _context.UserArtist.Remove(toRemove);
            _context.SaveChanges();
        }

        public void DeleteUserGenre(UserGenre userGenre)
        {
            var toRemove = _context.UserGenre
                .Where(x => x.GenreID == userGenre.GenreID 
                && x.UserUID == userGenre.UserUID)
                .FirstOrDefault();
            _context.UserGenre.Remove(toRemove);
            _context.SaveChanges();
        }
    }
}
