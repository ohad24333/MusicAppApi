
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MusicApp.Entities.Models
{
    public partial class Coutry
    {
        public Coutry()
        {
            Artists = new HashSet<Artist>();
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public virtual ICollection<Artist> Artists { get; set; }
    }
}
