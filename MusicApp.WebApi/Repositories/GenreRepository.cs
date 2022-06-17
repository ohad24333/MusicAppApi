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
    public class GenreRepository : IGenreRepository
    {
        private MusicAppDBContext _context;
        public GenreRepository(MusicAppDBContext context)
        {
            _context = context;
        }
        public async Task<List<Genre>> GetAllGenresAsync()
        {
            try
            {
                return await _context.Genres.Select(g => g).ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }


        }
        public async Task<Genre> GetGenreAsync(string name)
        {
            try
            {
                return await _context.Genres.Where(g => g.Name == name).Select(g => g).SingleAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
