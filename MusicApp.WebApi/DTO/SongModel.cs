using System;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.WebApi.DTO
{
    public class SongModel
    {
        [Key]
        [Required]
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
    }
}
