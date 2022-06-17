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
    public class AlbumRepository : IAlbumRepository
    {
        private MusicAppDBContext _context;
        public AlbumRepository(MusicAppDBContext context)
        {
            _context = context;
        }
        public async Task<List<Album>> GetArtistAlbumsAsync(int artistId)
        {
            try
            {
                var query1 = _context.Albums.Where(album => album.Artist.Id == artistId).Select(album => album);
                return await query1.ToListAsync();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;

            }

        }
        public async Task<Album> GetAlbumAsync(int? id)
        {
            if (id != null)
            {
                try
                {
                    return await _context.Albums.SingleOrDefaultAsync(a => a.Id == id);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return null;
                }
            }
            return null;
        }
        public async Task<int> AddToDataBaseAsync(Album album)
        {
            try
            {
                await _context.Albums.AddAsync(album);
                await _context.SaveChangesAsync();
                return album.Id;
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                return -1;
            }

        }
        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
