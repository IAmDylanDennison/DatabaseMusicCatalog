using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_Project.Database.DatabaseModels;
using Database_Project.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Database_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private GenreRepository _genreRepository;
        public GenreController(GenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public ActionResult<List<Genre>> Get()
        {
            return _genreRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Genre> Get(int id)
        {
            return _genreRepository.Get(id);
        }

        [HttpPost("update")]
        public ActionResult Update(Genre genre)
        {
            _genreRepository.UpdateGenre(genre);
            return Ok();
        }

        [HttpPost("add")]
        public ActionResult Add(Genre genre)
        {
            _genreRepository.AddGenre(genre);
            return Ok();
        }

        [HttpPost("delete")]
        public ActionResult Delete(Genre genre)
        {
            _genreRepository.DeleteGenre(genre);
            return Ok();
        }
    }
}
