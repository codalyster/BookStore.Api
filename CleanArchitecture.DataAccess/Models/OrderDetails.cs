using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.DataAccess.Models
{
    public class OrderDetails
    {
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }




    }
}
