using MusicApp.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.WebApi
{
    public interface IPublisherRepository
    {
        Task DisposeAsync();
        Task<List<Publisher>> GetAllPublishersAsync();
        Task<Publisher> GetPublisherAsync(string name);
    }
}