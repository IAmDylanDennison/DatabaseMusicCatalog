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
                _userRepository.AddUser(user);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return Ok(user);
        }
    }
}
