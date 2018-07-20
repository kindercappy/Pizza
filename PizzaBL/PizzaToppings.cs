using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBL
{
    public class PizzaToppings
    {
        [Key]
        public int id { get; set; }
        public int pizzaId { get; set; }
        public int toppingId { get; set; }

    }
}
