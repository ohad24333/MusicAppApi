using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MusicApp.Entities.Models
{
    public partial class SongPlayedLog
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime TimePlayed { get; set; }
        [Required]
        public int SongId { get; set; }
        [Required]
        public string UserId { get; set; }


        public virtual Song Song { get; set; }
        public virtual ApplicationUser User{ get; set; }
    }
}
