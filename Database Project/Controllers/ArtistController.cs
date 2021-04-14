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

        [HttpGet("artist/{id}")]
        public ActionResult<Artist> GetArtist(int id)
        {
            return _artistRepository.GetById(id);
        }

        [HttpPost]
        public ActionResult AddArtist(Artist artist)
        {
            _artistRepository.AddArtist(artist);
            return Ok();
        }

        [HttpPost("update")]
        public ActionResult UpdateMusic(Artist music)
        {
            _artistRepository.UpdateArtist(music);
            return Ok();
        }

        [HttpPost("delete")]
        public ActionResult DeleteArtist(Artist artist)
        {
            _artistRepository.DeleteArtist(artist);
            return Ok();
        }
    }
}
