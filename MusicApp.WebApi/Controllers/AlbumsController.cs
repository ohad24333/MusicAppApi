using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Entities.Models;
using MusicApp.WebApi.DTO;
using System.Threading.Tasks;

namespace MusicApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {

        private IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumsController(IAlbumRepository albumRepository,
                                 IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        [HttpGet("artist/{artistid}")]
        public async Task<IActionResult> GetArtistAlbums([FromRoute] int artistid)
        {
            var albums = await _albumRepository.GetArtistAlbumsAsync(artistid);
            if (albums.Count > 0 && albums != null)
            {
                return Ok(albums);
            }
            return NotFound();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum([FromRoute] int id)
        {
            var artist = await _albumRepository.GetAlbumAsync(id);
            if (artist != null)
            {
                return Ok(artist);
            }
            return NotFound();
        }
      

        [HttpPost]
        public async Task<IActionResult> AddNewAlbumAsync([FromBody] AlbumModel albumModel)
        {
            var album = _mapper.Map<Album>(albumModel);
            int id = await _albumRepository.AddToDataBaseAsync(album);
            if (id == -1)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetAlbum), new { id = id, controller = "Albums" }, id);
        }
       

    }
}
