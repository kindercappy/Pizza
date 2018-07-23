using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaBL
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Key]
        public int orderItemId { get; set; }
        public int orderId { get; set; }
        public int pizzaItemId { get; set; }
    }
}