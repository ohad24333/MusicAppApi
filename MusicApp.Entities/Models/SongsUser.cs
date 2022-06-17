#nullable disable

using System.ComponentModel.DataAnnotations;

namespace MusicApp.Entities.Models
{
    public partial class SongsUser
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int SongId { get; set; }
        [Required]
        public string UserId { get; set; }


        public virtual Song Song { get; set; }
        public virtual ApplicationUser User{ get; set; }
    }
}
