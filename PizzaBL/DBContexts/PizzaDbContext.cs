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
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<PizzaToppings> PizzaToppings { get; set; }
    }
}
