
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MusicApp.Entities.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
            ArtistsUsers = new HashSet<ArtistsUser>();
            Songs = new HashSet<Song>();
        }

        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string StageName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public int? CoutryId { get; set; }

        public virtual Coutry Coutry { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<ArtistsUser> ArtistsUsers { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
