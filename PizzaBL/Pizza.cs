using PizzaBL.DBContexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzaBL
{
    [Table("Pizza")]
    public class Pizza
    {
        [Key]
        public int pizzaId { get; set; }
        public string name { get; set; }
        public PizzaBase pizzaBase { get; set; }
        public bool veg { get; set; }
        public bool nonVeg { get; set; }
        public ICollection<PizzaToppings> toppingsList { get; set; }

        public int AddPizza(Pizza pizzaBody)
        {
            Pizza pizza = new Pizza()
            {
                name = pizzaBody.name,
                pizzaBase = pizzaBody.pizzaBase,
                toppingsList = pizzaBody.toppingsList
            };
            using (var db = new PizzaDbContext())
            {
                db.Pizza.Add(pizza);
                db.SaveChanges();
            }
            return pizza.pizzaId;
        }

        public List<Pizza> GetTypesOfPizzas(string typeOfPizza)
        {
            List<Pizza> pizzas = new List<Pizza>();
            using (var db = new PizzaDbContext())
            {
                if (typeOfPizza.ToLower() == "veg")
                {
                    pizzas = db.Pizza.Include("toppingsList").Where(pizzasFilter => pizzasFilter.veg == true).ToList();
                }
                else if (typeOfPizza.ToLower() == "nonveg")
                {
                    pizzas = db.Pizza.Include("toppingsList").Where(pizzasFilter => pizzasFilter.nonVeg == true).ToList();
                }
                else
                {
                    pizzas = db.Pizza.Include("toppingsList").ToList();
                }
            }
            return pizzas;
        }

        public Pizza UpdatePizza(int pizzaId, Pizza pizzaBody)
        {
            Pizza pizza = new Pizza();
            var pizzaProps = typeof(Pizza).GetProperties();

            using (var db = new PizzaDbContext())
            {
                foreach (var pizzaProp in pizzaProps)
                {
                    pizza = db.Pizza.Where(e => e.pizzaId == pizzaId).FirstOrDefault();
                    string pizzaPropToString = pizzaProp.Name;
                    bool isPrimaryId = Regex.IsMatch(pizzaPropToString, @"\w+Id$");
                    var pizzaProperty = pizzaBody.GetType().GetProperty(pizzaPropToString);
                    if (!isPrimaryId)
                    {
                        if (pizzaProperty.GetValue(pizzaBody) != null)
                        {
                            var getPizzaBodyPropValue = pizzaProp.GetValue(pizzaBody);
                            pizza.GetType().GetProperty(pizzaPropToString).SetValue(pizza, pizzaProperty.GetValue(pizzaBody));
                            pizzaProperty.SetValue(pizza, pizzaProp.GetValue(pizzaBody));
                        }
                    }
                }

                //pizza.pizzaBase = pizzaBody.pizzaBase;
                //pizza.name = pizzaBody.name;
                //pizza.nonVeg = pizzaBody.nonVeg;
                //pizza.veg = pizzaBody.veg;
                //pizza.toppingsList = pizzaBody.toppingsList;
                db.SaveChanges();
            }
            return pizza;
        }

        public List<Pizza> GetAllPizzas()
        {
            List<Pizza> pizzas = new List<Pizza>();
            using (var db = new PizzaDbContext())
            {
                pizzas = db.Pizza.Include("toppingsList").ToList();

            }
            return pizzas;
        }

        public Pizza UpdatePizzaToppingList(int pizzaid)
        {
            Pizza pizza = new Pizza();
            using (var db = new PizzaDbContext())
            {
                pizza = db.Pizza.Where(element => element.pizzaId == pizzaid).FirstOrDefault();
                var pizzaToppings = new List<PizzaToppings>();
                pizzaToppings = db.PizzaToppings.Where(e => e.pizzaId == pizzaid).ToList();
                pizza.toppingsList = pizzaToppings;

            }
            return pizza;
        }
    }
}
