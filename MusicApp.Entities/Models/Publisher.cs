using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MusicApp.Entities.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Songs = new HashSet<Song>();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public DateTime DayOfFounding { get; set; }


        public virtual ICollection<Song> Songs { get; set; }
    }
}
