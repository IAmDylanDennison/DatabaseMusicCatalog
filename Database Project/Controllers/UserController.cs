using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_Project.Database.DatabaseModels;
using Database_Project.Database.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Database_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<string> Test()
        {
            return "Hello world";
        }

        [HttpGet("{email}")]
        [Authorize]
        public ActionResult<User> Get(string email)
        {
            return _userRepository.GetUser(email);
        }

        [HttpPost("New")]
        public ActionResult<User> New(User user)
        {
            try
            {
                if (_userRepository.GetUser(user.Email) == null)
                    _userRepository.AddUser(user);
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpPost("like/music")]
        public ActionResult LikeMusic(UserMusic likedMusic)
        {
            _userRepository.AddUserMusic(likedMusic);
            return Ok();
        }

        [HttpPost("like/artist")]
        public ActionResult LikeArtist(UserArtist userArtist)
        {
            _userRepository.AddUserArtist(userArtist);
            return Ok();
        }

        [HttpPost("like/genre")]
        public ActionResult LikeGenre(UserGenre userGenre)
        {
            _userRepository.AddUserGenre(userGenre);
            return Ok();
        }

        [HttpPost("dislike/music")]
        public ActionResult DislikeMusic(UserMusic song)
        {
            _userRepository.DeleteUserMusic(song);
            return Ok();
        }

        [HttpPost("dislike/genre")]
        public ActionResult DislikeGenre(UserGenre genre)
        {
            _userRepository.DeleteUserGenre(genre);
            return Ok();
        }

        [HttpPost("dislike/artist")]
        public ActionResult DislikeArtist(UserArtist artist)
        {
            _userRepository.DeleteUserArtist(artist);
            return Ok();
        }

        [HttpGet("get/genre/{uid}")]
        public ActionResult<List<UserGenre>> GetUserGenre(int uid)
        {
            var usergenres = _userRepository.GetUserGenres(uid);
            return usergenres;
        }

        [HttpGet("get/artist/{uid}")]
        public ActionResult<List<UserArtist>> GetUserArtist(int uid)
        {
            return _userRepository.GetUserArtists(uid);
        }

        [HttpGet("get/music/{uid}")]
        public ActionResult<List<UserMusic>> GetUserMusic(int uid)
        {
            return _userRepository.GetUserMusic(uid);
        }
    }
}
