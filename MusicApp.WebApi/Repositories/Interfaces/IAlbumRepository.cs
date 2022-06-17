using MusicApp.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.WebApi
{
    public interface IAlbumRepository
    {
        Task<int> AddToDataBaseAsync(Album album);
        Task DisposeAsync();
        Task<Album> GetAlbumAsync(int? id);
        Task<List<Album>> GetArtistAlbumsAsync(int artistId);
    }
}