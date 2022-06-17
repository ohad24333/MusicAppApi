using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MusicApp.Entities.Models
{
    public partial class Song 
    {
        public Song()
        {
            SongsUsers = new HashSet<SongsUser>();
        }
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public int Watched { get; set; }
        [Required]
        public DateTime Duration { get; set; }
        public int? PublisherId { get; set; }
        [Required]
        public DateTime DatePublished { get; set; }
        public int? AlbumId { get; set; }
        public int? GenreId { get; set; }


        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<SongsUser> SongsUsers { get; set; }

      
    }
}
