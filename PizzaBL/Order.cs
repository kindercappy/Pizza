using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBL
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public string customerName { get; set; }
        public string customerPhone { get; set; }
    }
}
