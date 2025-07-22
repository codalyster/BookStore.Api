using CleanArchitecture.DataAccess.Models;
using CsvHelper.Configuration;

namespace CleanArchitecture.Infrastructure.DataSeed
{
    public sealed class UserRatingMap : ClassMap<UserRating>
    {
        public UserRatingMap()
        {
            Map(m => m.UserIdx).Name("user_idx");
            Map(m => m.BookIdx).Name("book_idx");
            Map(m => m.Rating).Name("rating");
            Map(m => m.Country).Name("country");
            Map(m => m.Gender).Name("gender");
            Map(m => m.Age).Name("age");
            Map(m => m.IsNewMuslim).Name("is_new_muslim");
            Map(m => m.BornMuslim).Name("born_muslim");
            Map(m => m.EducationLevel).Name("education_level");
            Map(m => m.ReligiousLevel).Name("religious_level");
            Map(m => m.TopicIdx).Name("topic_idx");
            Map(m => m.AuthorIdx).Name("author_idx");
            Map(m => m.Category).Name("category");
            Map(m => m.AverageRating).Name("average_rating");
            Map(m => m.UserRatingCount).Name("user_rating_count");
        }
    }

}
