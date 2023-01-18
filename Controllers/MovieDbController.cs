using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieDbAngDotNet.DataAccessLayer;
using MovieDbAngDotNet.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieDbAngDotNet.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class MovieDbController : ControllerBase
    {
        private readonly IMovieDb _movieDataAccess;

        public MovieDbController(IMovieDb movieDataAccess)
        {
            this._movieDataAccess = movieDataAccess;
        }


        // GET: api/<MovieDbController>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<MovieDb> GetAll()
        {

            return _movieDataAccess.GetMovies();

        }

        // GET api/<MovieDbController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            return Ok(_movieDataAccess.GetMovieById(id));
        }

        // POST api/<MovieDbController>
        [HttpPost]
        public IActionResult Post(string name, string year)
        {
            int _year = int.Parse(year);
            if (_year < 1700 || _year > DateTime.Now.Year) return BadRequest();

            return Ok(_movieDataAccess.AddMovie(new MovieDb(name, _year)));

        }

        // PUT api/<MovieDbController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, string name, string year)
        {
            int _year = int.Parse(year);
            if (_year < 1700 || _year > DateTime.Now.Year) return BadRequest();
            _movieDataAccess.AddMovie(new MovieDb(int.Parse(id), name, _year));
            return Ok();
        }

        // DELETE api/<MovieDbController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieDataAccess.DeleteMovieById(id);
            return Ok();
        }
    }
}
