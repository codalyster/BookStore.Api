using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Services.DTOs.ApplicationUser
{
    public class ApplicationUserCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? Address { get; set; }
        public string? Bio { get; set; }

        [Range(10, 120)]
        public int? Age { get; set; }

        public string? ProfilePictureUrl { get; set; }

        [Range(0, int.MaxValue)]
        public int? NumberOfBooks { get; set; }

        [Range(1, 5)]
        public int? Rating { get; set; }

        [StringLength(100)]
        public string? Location { get; set; }

        [RegularExpression("^(Male|Female)$")]
        public string Gender { get; set; }

        public bool? IsNewMuslim { get; set; }
        public bool? BornMuslim { get; set; }

        [StringLength(100)]
        public string? EducationLevel { get; set; }

        [StringLength(100)]
        public string? ReligiousLevel { get; set; }

        [StringLength(500)]
        public string? PreferredTopics { get; set; }
    }


}
