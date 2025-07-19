namespace CleanArchitecture.Services.DTOs.Author
{
    public class ApplicationUserReadDTO
    {
        public string Id { get; set; } // From IdentityUser
        public string FullName { get; set; }
        public string Bio { get; set; }
        public int Age { get; set; }
        public int NumberOfBooks { get; set; }
    }
}
