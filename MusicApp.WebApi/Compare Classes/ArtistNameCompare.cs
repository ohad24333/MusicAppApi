using MusicApp.Entities.Models;
using System.Collections.Generic;

namespace MusicApp.WebApi
{
    public class ArtistNameCompare : IComparer<Artist>
    {
        public int Compare(Artist x, Artist y)
        {
            return x.StageName.CompareTo(y.StageName);
        }
    }
}
