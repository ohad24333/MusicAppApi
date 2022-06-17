using System.ComponentModel.DataAnnotations;

namespace MusicApp.WebApi.DTO
{
    public class SignUpModel
    {
        [Key]
        [Required]
        public string Email{ get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
