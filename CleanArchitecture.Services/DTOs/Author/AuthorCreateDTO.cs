using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Services.DTOs.Author
{
    public class AuthorCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(1000)]
        public string Bio { get; set; }

        [Range(18, 120)]
        public int Age { get; set; }

        [Range(0, int.MaxValue)]
        public int NumberOfBooks { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }

}
