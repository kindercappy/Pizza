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
    public class Topping
    {
        [Key]
        public int toppingId { get; set; }
        public ToppingType topping { get; set; }
    }
}
