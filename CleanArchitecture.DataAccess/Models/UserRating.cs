namespace CleanArchitecture.DataAccess.Models
{
    public class UserRating
    {
        public int Id { get; set; }
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
    }

}
