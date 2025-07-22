using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int UserIdx { get; set; }
        public int BookIdx { get; set; }
        public float Rating { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public float Age { get; set; }
        public bool IsNewMuslim { get; set; }
        public bool BornMuslim { get; set; }
        public string EducationLevel { get; set; }
        public string ReligiousLevel { get; set; }
        public int TopicIdx { get; set; }
        public int AuthorIdx { get; set; }
        public string Category { get; set; }
        public float AverageRating { get; set; }
        public float UserRatingCount { get; set; }



        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Location { get; set; }

        public virtual List<Book>? Books { get; set; } = new();
        public virtual List<Order>? Orders { get; set; } = new();
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
    }

}
