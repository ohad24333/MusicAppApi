using MusicApp.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.WebApi
{
    public interface ISongRepository
    {

        #region Get

        Task<List<Song>> GetAllAsync();
        Task<Song> GetSongAsync(int id);
        Task<List<Song>> SearchSongAsync(string songName);
        Task<List<Song>> GetAlbumSongsAsync(int albumId);
        Task<List<Song>> GetLikedSongAsync(string userEmail);
        Task<List<Song>> GetListeningHistoryAsync(string userEmail);

        #endregion

        #region Add

        Task<string> AddSongToSongLogAsync(int songId,string userEmail);
        Task<string> AddSongToLikesAsync(int songId, string userEmail);
        Task<int> AddToDataBaseAsync(Song song);

        #endregion

        #region Delete

        Task<bool> DeleteAsync(int songID);
        Task<string> RemoveSongFromLikesAsync(int songId, string userEmail);
     
        #endregion
        
        Task<bool> UpdateToDataBaseAsync(Song song);

        Task DisposeAsync();
    }
}