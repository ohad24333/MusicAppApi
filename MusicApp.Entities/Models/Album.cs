using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MusicApp.Entities.Models
{
    public partial class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string AlbumName { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public DateTime DatePublished { get; set; }


        public virtual Artist Artist { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
