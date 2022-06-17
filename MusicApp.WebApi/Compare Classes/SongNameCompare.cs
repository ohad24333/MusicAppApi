using MusicApp.Entities.Models;
using System.Collections.Generic;

namespace MusicApp.WebApi
{
    public class SongNameCompare : IComparer<Song>
    {
        public int Compare(Song x, Song y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
