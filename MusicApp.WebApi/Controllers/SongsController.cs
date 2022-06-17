using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Entities.Models;
using MusicApp.WebApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public SongsController(ISongRepository songRepository,
                                IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }


        #region Get
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var songs = await _songRepository.GetAllAsync();
            if (songs != null && songs.Count > 0)
            {
                return Ok(songs);
            }
            return NotFound();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Song song = await _songRepository.GetSongAsync(id);
            if (song != null)
            {
                return Ok(song);
            }
            return null;
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchSong([FromQuery] string songName)
        {
            var list = await _songRepository.SearchSongAsync(songName);
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }


        [Authorize]
        [HttpGet("likes")]
        public async Task<IActionResult> GetLikedSongs([FromQuery] string useremail)
        {
             
            List<Song> songsList = await _songRepository.GetLikedSongAsync(useremail);
            if (songsList != null && songsList.Count > 0 )
            {
                songsList.Sort(new SongNameCompare());
                return Ok(songsList);
            }
            else return NotFound();
        }


        [Authorize]
        [HttpGet("listeninghistory")]
        public async Task<IActionResult> GetListeningHistory([FromQuery] string useremail)
        {
            List<Song> songsList = await _songRepository.GetListeningHistoryAsync(useremail);
            if (songsList.Count > 0)
            {
                return Ok(songsList);
            }
            else return NotFound();
        }


        [HttpGet("album")]
        public async Task<IActionResult> GetAlbumSongs([FromQuery] int albumid)
        {

            List<Song> songsList = await _songRepository.GetAlbumSongsAsync(albumid);
            if (songsList.Count > 0 && songsList != null)
            {
                return Ok(songsList);
            }
            else return NotFound();
        }


        #endregion


        #region Post


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddNewSong([FromBody] SongModel songModel)
        {
            var song = _mapper.Map<Song>(songModel);

            var id = await _songRepository.AddToDataBaseAsync(song);
            if (id != -1)
            {
                return CreatedAtAction(nameof(Get),new { id = id, controller = "songs" },id);
            }
            return BadRequest();
        }


        [Authorize]
        [HttpPost("songlog")]
        public async Task<IActionResult> AddSongToSongLog([FromQuery] int songid, [FromQuery] string useremail)
        {

            var result = await _songRepository.AddSongToSongLogAsync(songid, useremail);
            if (string.IsNullOrEmpty(result))
            {
                return Ok("Song Added Successfuly");                    
            }
            return BadRequest(result);
        }


        [Authorize]
        [HttpPost("likes")]
        public async Task<IActionResult> AddSongToLikes([FromQuery] int songid, [FromQuery] string useremail)
        {  

            var result = await _songRepository.AddSongToLikesAsync(songid, useremail);
            if (string.IsNullOrEmpty(result))
            {
                return Ok("Song Added Successfuly");
            }
            return BadRequest(result);
        }


        #endregion


        #region Put


        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateSong([FromBody] SongModel songModel)
        {
            var song = _mapper.Map<Song>(songModel);

            var result = await _songRepository.UpdateToDataBaseAsync(song);
            if (result)
            {
                return Ok("Song Updated Successfuly");
            }
            return BadRequest();
        }


        #endregion


        #region Delete


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong([FromRoute] int id)
        {
            var result = await _songRepository.DeleteAsync(id);
            if (result)
            {
                return Ok("Song Deleted.");
            }
            return BadRequest();
        }


        [Authorize]
        [HttpDelete("likes")]
        public async Task<IActionResult> RemoveSongFromLikes([FromQuery] int songid , [FromQuery] string useremail)
        { 
            var result = await _songRepository.RemoveSongFromLikesAsync(songid, useremail);
            if (string.IsNullOrEmpty(result))
            {
                return Ok("Song Deleted.");
            }
            return BadRequest(result);
        }

        #endregion
    }
}

