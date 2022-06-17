using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MusicApp.Entities.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Songs = new HashSet<Song>();
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<Song> Songs { get; set; }
    }
}
