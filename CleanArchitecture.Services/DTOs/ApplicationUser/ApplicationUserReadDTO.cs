namespace CleanArchitecture.Services.DTOs.ApplicationUser
{
    public class ApplicationUserReadDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Bio { get; set; }
        public int? Age { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int? NumberOfBooks { get; set; }
        public int? Rating { get; set; }
        public string? Location { get; set; }
        public string Gender { get; set; }
        public bool? IsNewMuslim { get; set; }
        public bool? BornMuslim { get; set; }
        public string? EducationLevel { get; set; }
        public string? ReligiousLevel { get; set; }
        public string? PreferredTopics { get; set; }
    }

}
