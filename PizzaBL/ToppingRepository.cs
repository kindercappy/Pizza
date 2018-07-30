using PizzaBL;
using PizzaBL.DBContexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBL
{
    [Table("Toppings")]
    public class ToppingRepository
    {
        [Key]
        public int toppingId { get; set; }
        public ToppingType topping { get; set; }

        public int InsertNewTopping(ToppingRepository toppingBody)
        {
            ToppingRepository newTopping = new ToppingRepository() {
                topping = toppingBody.topping
            };
            using (var db = new PizzaDbContext())
            {
                db.Toppings.Add(newTopping);
                db.SaveChanges();
            }
            return newTopping.toppingId;
        }
    }
}
