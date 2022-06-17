using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Entities.Models;
using MusicApp.WebApi.DTO;
using System.Threading.Tasks;

namespace MusicApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public ArtistsController(IArtistRepository artistRepository,
                                 IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllArtists()
        {
            var artists = await _artistRepository.GetAllArtistsAsync();
            if (artists.Count > 0)
            {
                artists.Sort(new ArtistNameCompare());
                return Ok(artists);
            }
            return NotFound();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist([FromRoute] int id)
        {
            Artist artist = await _artistRepository.GetArtistAsync(id);

            if (artist != null)
            {
                return Ok(artist);
            }
            return NotFound();
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchArtist([FromQuery] string artist)
        {
            var list = await _artistRepository.SearchArtistsAsync(artist);

            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }


        [HttpGet("country/{artistid}")]
        public async Task<IActionResult> GetArtistCoutry([FromRoute] int artistid)
        {
            var country = await _artistRepository.GetArtistCoutryAsync(artistid);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewArtist([FromBody] ArtistModel artistModel)
        {
            var artist = _mapper.Map<Artist>(artistModel);
            int id = await _artistRepository.AddNewArtistAsync(artist);
            if (id == -1)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetArtist), new { id = id, controller = "Artists" }, id);
        } 


        [HttpPut]
        public async Task<IActionResult> UpdateArtist([FromBody] ArtistModel artistModel)
        {
            var artist = _mapper.Map<Artist>(artistModel);
            var result = await _artistRepository.UpdateToDataBaseAsync(artist);
            if (result)
            {
                return Ok("Artist Update Successfuly");
            }
            return BadRequest();

        }  

    }
}
