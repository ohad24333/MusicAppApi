using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MusicApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
       
        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;        
        }


        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreRepository.GetAllGenresAsync();
            if (genres != null && genres.Count > 0)
            {
                return Ok(genres);
            }
            return NotFound();
        }


        [HttpGet("{genrename}")]
        public async Task<IActionResult> GetGenre([FromRoute] string genrename)
        {
            var genre = await _genreRepository.GetGenreAsync(genrename);
            if (genre != null)
            {
                return Ok(genre);
            }
            return NotFound();
        }
    }
}
