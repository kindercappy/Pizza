using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBL
{
    public class Pizza
    {
        public string pizzID;
        public string name;
        public PizzaBase pizzaBase;
        public List<Topping> toppings;
    }
}
