using System;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.WebApi.DTO
{
    public class AlbumModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string AlbumName { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public DateTime DatePublished { get; set; }
    }
}
