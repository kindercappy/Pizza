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
    public class OrderRepository
    {
        [Key]
        public int orderId { get; set; }
        public List<OrderItemRepository> orderItems { get; set; }
        public string customerName { get; set; }
        public string customerPhone { get; set; }
        public OrderStatus orderStatus { get; set; }


        public int CreateOrder(OrderRepository orderBody)
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

        public OrderRepository GetOrder(int orderId)
        {
            OrderRepository getOrder = new OrderRepository();
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
