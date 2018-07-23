using PizzaBL.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBL
{
    public class DummyData
    {
        private int globalNumberForPizza;

        public int GlobalNumberForPizza
        {
            get
            {
                return globalNumberForPizza;
            }

            set
            {
                globalNumberForPizza = value;
            }
        }

        public void EnterDummyData()
        {
            using (var db = new PizzaDbContext())
            {

            }
        }
        public List<Pizza> GetNewPizzaListToInsert()
        {
            return new List<Pizza>() {
                new Pizza() { name = "Farmhouse",pizzaBase = PizzaBase.Cheese, nonVeg = false, veg = true, toppingsList =   new List<PizzaToppings>() {
                    new PizzaToppings() { }
                } },
            };
        }
        public Pizza GetNewPizzaToInsert()
        {
            DummyData newDataOps = new DummyData();
            PizzaToppings newPizzaToppinsToInsert = new PizzaToppings();

            List<PizzaToppings> pizzaToppings = new List<PizzaToppings>() {
                new PizzaToppings() {
                    toppingId = GetPizzaToppings().FirstOrDefault().toppingId
                },
                new PizzaToppings() {
                    toppingId = GetPizzaToppings().LastOrDefault().toppingId
                }
            };
            return new Pizza()
            {
                name = "Farmhouse " + GlobalNumberForPizza,
                nonVeg = false,
                pizzaBase = PizzaBase.Cheese,
                veg = true,
                toppingsList = pizzaToppings
            };
        }
        public List<Topping> GetNewToppingsToInsert()
        {
            return new List<Topping>() {
                new Topping()
                {
                    topping = ToppingType.Onion
                },
                new Topping()
                {
                    topping = ToppingType.Onion
                },
                new Topping()
                {
                    topping = ToppingType.Onion
                },
                new Topping()
                {
                    topping = ToppingType.Onion
                }
            };
        }
        public Topping GetNewToppingToInsert()
        {
            return new Topping()
            {
                topping = ToppingType.Tomato
            };
        }
        public List<Pizza> GetPizzas()
        {
            List<Pizza> pizzas = new List<Pizza>();
            using (var db = new PizzaDbContext())
            {
                pizzas = db.Pizza.ToList();

            }
            return pizzas;
        }
        public List<Topping> GetPizzaToppings()
        {
            List<Topping> toppings = new List<Topping>();
            using (var db = new PizzaDbContext())
            {
                toppings = db.Toppings.ToList();
            }
            return toppings;
        }
        public PizzaToppings GetNewPizzaToppingToInsert()
        {
            DummyData newDataOps = new DummyData();
            return new PizzaToppings() { };
        }
        // TODO : Methods for the order and orderItem table 
    }
}
