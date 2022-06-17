using System.ComponentModel.DataAnnotations;

namespace MusicApp.WebApi.DTO
{
    public class ArtistModel
    {
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
    }
}
