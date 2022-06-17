using Microsoft.AspNetCore.Identity;
using MusicApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            ArtistsUsers = new HashSet<ArtistsUser>();
            UserListeningHistory = new HashSet<SongPlayedLog>();
            SongsUsers = new HashSet<SongsUser>();
        }


        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<ArtistsUser> ArtistsUsers { get; set; }
        public virtual ICollection<SongPlayedLog> UserListeningHistory { get; set; }
        public virtual ICollection<SongsUser> SongsUsers { get; set; }
    }
}
