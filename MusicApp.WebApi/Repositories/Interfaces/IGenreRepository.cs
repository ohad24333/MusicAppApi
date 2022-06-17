using MusicApp.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.WebApi
{
    public interface IGenreRepository
    {
        Task DisposeAsync();
        Task<List<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreAsync(string name);
    }
}