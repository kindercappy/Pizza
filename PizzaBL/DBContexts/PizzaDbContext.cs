using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBL.DBContexts
{
    public class PizzaDbContext: DbContext
    {
        public DbSet<PizzaRepository> Pizza { get; set; }
        public DbSet<ToppingRepository> Toppings { get; set; }
        public DbSet<PizzaToppingsRepository> PizzaToppings { get; set; }
        public DbSet<OrderRepository> Order { get; set; }
        public DbSet<OrderItemRepository> OrderItem { get; set; }
    }
}
