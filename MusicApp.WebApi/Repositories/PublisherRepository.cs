using Microsoft.EntityFrameworkCore;
using MusicApp.Entities.DB;
using MusicApp.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.WebApi
{
    public class PublisherRepository : IPublisherRepository
    {
        private MusicAppDBContext _context;
        public PublisherRepository(MusicAppDBContext context)
        {
            _context = context;
        }
        public async Task<List<Publisher>> GetAllPublishersAsync()
        {
            return await _context.Publishers.Select(p => p).ToListAsync();
        }
        public async Task<Publisher> GetPublisherAsync(string name)
        {
            return await _context.Publishers.SingleAsync(p => p.CompanyName == name);
        }
        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
