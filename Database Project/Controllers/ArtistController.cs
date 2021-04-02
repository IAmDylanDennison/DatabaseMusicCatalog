using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_Project.Database.DatabaseModels;
using Database_Project.Database.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Database_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private ArtistRepository _artistRepository;
        public ArtistController(ArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        [HttpGet]
        public ActionResult<List<Artist>> Get()
        {
            return _artistRepository.GetAll();
        }
    }
}
