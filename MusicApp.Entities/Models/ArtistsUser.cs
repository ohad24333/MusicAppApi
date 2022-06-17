
#nullable disable

using System.ComponentModel.DataAnnotations;

namespace MusicApp.Entities.Models
{
    public partial class ArtistsUser
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public string UserId { get; set; }


        public virtual Artist Artist { get; set; }
        public virtual ApplicationUser User{ get; set; }
    }
}
