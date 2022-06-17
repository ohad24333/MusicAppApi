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
    public class ArtistRepository :  IArtistRepository
    {

        private MusicAppDBContext _context;
      
        public ArtistRepository(MusicAppDBContext context)
        {
            _context = context;
        }
        public async Task<List<Artist>> GetAllArtistsAsync()
        {
            try
            {
                return await _context.Artists.ToListAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("my..", e.Message);
                return null;
            }
        }
        public async Task<Artist> GetArtistAsync(int id)
        {
            try
            {
                if (_context.Artists.Any(a => a.Id == id))
                {
                    Artist artist = await _context.Artists.SingleOrDefaultAsync(a => a.Id == id);
                    return artist;
                }
                else return null;
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                return null;
            }
          

        }
        public async Task<List<Artist>> SearchArtistsAsync(string txtSearchInsert)
        {
            try
            {
                if (_context.Artists.Any(a => a.StageName.ToLower().StartsWith(txtSearchInsert.ToLower())))
                {
                    var query1 = _context.Artists.Where(a => a.StageName.ToLower().StartsWith(txtSearchInsert.ToLower())).Select(a => a);
                    List<Artist> artists = await query1.ToListAsync();
                    return artists;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
          

        }
        public async Task<int> AddNewArtistAsync(Artist artist)
        {
            string msg = "";
            if (!Regexes.NameRegex.IsMatch(artist.LastName))
            {
                msg += "First Name Shoulde Be Only Letters 2-10 Charachters";
            }
            if (!Regexes.NameRegex.IsMatch(artist.FirstName))
            {
                msg += "Last Name Shoulde Be Only Letters 2-10 Charachters";
            }
            if (msg != "")
            {
                Debug.WriteLine(msg);
                return -1;
            }
            else
            {
                try
                {
                    await _context.Artists.AddAsync(artist);
                    await _context.SaveChangesAsync();
                    return artist.Id;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.InnerException.Message);
                    return -1;
                }
            }

        }  
        public async Task<bool> UpdateToDataBaseAsync(Artist artist)
        {
            string msg = "";
            if (!Regexes.NameRegex.IsMatch(artist.LastName))
            {
                msg += "First Name Shoulde Be Only Letters 2-10 Charachters";
            }
            if (!Regexes.NameRegex.IsMatch(artist.FirstName))
            {
                msg += "Last Name Shoulde Be Only Letters 2-10 Charachters";
            }
            if (msg != "")
            {
                Debug.WriteLine(msg);
                return false;
            }
            else
            {

                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return false;
                }
            }

        }
        public async Task<Coutry> GetArtistCoutryAsync(int artistId)
        {
            try
            {
                var artist = await _context.Artists.Where(a => a.Id == artistId).Include(a => a.Coutry).FirstOrDefaultAsync();

                if (artist == null)
                {
                    return null;
                }
                return artist.Coutry;
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
