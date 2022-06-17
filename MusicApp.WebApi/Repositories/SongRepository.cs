using Microsoft.EntityFrameworkCore;
using MusicApp.Entities.DB;
using MusicApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.WebApi
{
    public class SongRepository : ISongRepository
    {

        private MusicAppDBContext _context;

        public SongRepository(MusicAppDBContext context)
        {
            _context = context;
        }


        #region Get

        public async Task<List<Song>> GetAllAsync()
        {
            try
            {
                return await _context.Songs.ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<Song> GetSongAsync(int id)
        {
            try
            {
                return await _context.Songs.SingleOrDefaultAsync(s => s.Id == id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }
        public async Task<List<Song>> SearchSongAsync(string songName)
        {
            try
            {
                var list = await _context.Songs.Where(s => s.Name.ToLower().StartsWith(songName.ToLower()))
                                            .Include(s => s.Artist).Include(s => s.Album)
                                             .ToListAsync();
                return list;
            }
            catch (Exception e)
            {
                Debug.WriteLine("my..", e);
                return null;
            }
        }
        public async Task<List<Song>> GetListeningHistoryAsync(string userEmail)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == userEmail);
                var list = await _context.SongPlayedLogs.Where(sl => sl.UserId == user.Id).Include(sl => sl.Song).ThenInclude(s => s.Artist).ToListAsync();
                list.Sort(new SongLastPlayedCompare());
                var songs =  list.Select(sl => sl.Song).ToList();
                return songs;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;

            }


        }
        public async Task<List<Song>> GetLikedSongAsync(string userEmail)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == userEmail);
                var query = _context.SongsUsers.Where(s => s.UserId == user.Id).Include(s => s.Song).ThenInclude(s => s.Artist);
                return await query.Select(su => su.Song).ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }
        public async Task<List<Song>> GetAlbumSongsAsync(int albumId)
        {
            try
            {
                var query = _context.Songs.Where(s => s.Album.Id == albumId).Include(s => s.Album);
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        #endregion

        #region Add

        public async Task<int> AddToDataBaseAsync(Song song)
        {
            try
            {
                await _context.Songs.AddAsync(song);
                await _context.SaveChangesAsync();
                return song.Id;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return -1;
            }
        }
        public async Task<string> AddSongToSongLogAsync(int songId, string userEmail)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == userEmail);
                var song = await _context.Songs.FindAsync(songId);
                song.Watched++;
                _context.Songs.Update(song);
                var songLog = await _context.SongPlayedLogs.SingleOrDefaultAsync(s => s.SongId == song.Id);

                if (songLog != null)
                {
                    songLog.TimePlayed = DateTime.Now;
                }
                else
                {
                    SongPlayedLog newSongLoad = new SongPlayedLog()
                    {
                        TimePlayed = DateTime.Now,
                        SongId = song.Id,
                        UserId = user.Id
                    };
                    await _context.SongPlayedLogs.AddAsync(newSongLoad);
                }

                await _context.SaveChangesAsync();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public async Task<string> AddSongToLikesAsync(int songId, string userEmail)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == userEmail);
                var songLiked = await _context.SongsUsers.SingleOrDefaultAsync(su => su.SongId == songId && su.UserId == user.Id);
                if (songLiked == null)
                {
                    await _context.SongsUsers.AddAsync(new SongsUser() { SongId = songId, UserId = user.Id });
                    await _context.SaveChangesAsync();
                    return "";
                  
                }
                else
                {
                    return "Song Already In List";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        #endregion

        #region Delete

        public async Task<bool> DeleteAsync(int songID)
        {
            try
            {
                var song = new Song { Id = songID };
                 _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
        public async Task<string> RemoveSongFromLikesAsync(int songId, string userEmail)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == userEmail);
                var likedSong = await  _context.SongsUsers.SingleOrDefaultAsync(su => su.UserId == user.Id && su.SongId == songId);
                if (likedSong != null)
                {
                    _context.SongsUsers.Remove(likedSong);
                    await _context.SaveChangesAsync();
                    return "";
                }
                return "Song Is Not On List"; 
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        #endregion
        
        public async Task<bool> UpdateToDataBaseAsync(Song song)
        {
            try
            {
                _context.Songs.Update(song);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }
        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        
    }
}
