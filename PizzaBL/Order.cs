using PizzaBL.DBContexts;
using PizzaBL.Enums;
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
        public OrderStatus orderStatus { get; set; }


        public int CreateOrder(Order orderBody)
        {
            try
            {
                using (var db = new PizzaDbContext())
                {
                    db.Order.Add(orderBody);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return orderBody.orderId;
        }

        public Order GetOrder(int orderId)
        {
            Order getOrder = new Order();
            try
            {
                using (var db = new PizzaDbContext())
                {
                    getOrder = db.Order.Include("orderItems").Where(orr => orr.orderId == orderId).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
            return getOrder;
        }
    }
}
