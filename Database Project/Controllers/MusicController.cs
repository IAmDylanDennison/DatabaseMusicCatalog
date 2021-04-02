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
    public class MusicController : ControllerBase
    {
        private MusicRepository _musicRepository;
        public MusicController(MusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        [HttpGet]
        public ActionResult<List<Music>> GetMusic()
        {
            return _musicRepository.GetAll();
        }

        [HttpGet("song/{id}")]
        public ActionResult<Music> GetSong(int id)
        {
            return _musicRepository.GetById(id);
        }

        [HttpPost("add")]
        public ActionResult AddMusic(Music music)
        {
            try
            {
                _musicRepository.AddMusic(music);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("update")]
        public ActionResult UpdateMusic(Music music)
        {
            try
            {
                _musicRepository.UpdateMusic(music);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
