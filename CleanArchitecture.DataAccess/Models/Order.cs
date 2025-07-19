using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateOnly OrderDate { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public virtual ApplicationUser Customer { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
