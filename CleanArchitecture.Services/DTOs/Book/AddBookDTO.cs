using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Services.DTOs.Book
{
    public class AddBookDTO
    {
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateOnly PublishDate { get; set; }
        public string AuthorId { get; set; }
        public int? CategoryId { get; set; }
    }
}
