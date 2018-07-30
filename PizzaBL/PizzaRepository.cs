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
    public class PizzaRepository
    {
        [Key]
        public int pizzaId { get; set; }
        public string name { get; set; }
        public PizzaBase pizzaBase { get; set; }
        public bool veg { get; set; }
        public bool nonVeg { get; set; }
        public ICollection<PizzaToppingsRepository> toppingsList { get; set; }
        // TODO : Implement all proper exection handling and response message 
        public int CreateOrder(PizzaRepository pizzaBody)
        {
            try
            {
                using (var db = new PizzaDbContext())
                {
                    db.Pizza.Add(pizzaBody);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return pizzaBody.pizzaId;
        }

        public List<PizzaRepository> GetTypesOfPizzas(string typeOfPizza)
        {
            List<PizzaRepository> pizzas = new List<PizzaRepository>();
            try
            {
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
            }
            catch (Exception)
            {
                return null;
            }
            return pizzas;
        }

        public PizzaRepository GetPizza(int pizzaId)
        {
            PizzaRepository getPizza = new PizzaRepository();
            try
            {
                using (var db = new PizzaDbContext())
                {
                    getPizza = db.Pizza.Where(pizz => pizz.pizzaId == pizzaId).First();
                }
            }
            catch (Exception)
            {
                return null;
            }
            return getPizza;
        }

        public PizzaRepository UpdatePizza(int pizzaId, PizzaRepository pizzaBody)
        {
            PizzaRepository pizza = new PizzaRepository();
            try
            {
                var pizzaProps = typeof(PizzaRepository).GetProperties();

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
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return null;
            }
            return pizza;
        }

        public List<PizzaRepository> GetAllPizzas()
        {
            List<PizzaRepository> pizzas = new List<PizzaRepository>();
            try
            {
                using (var db = new PizzaDbContext())
                {
                    pizzas = db.Pizza.Include("toppingsList").ToList();

                }
            }
            catch (Exception)
            {
                return null;
            }
            return pizzas;
        }

        public PizzaRepository UpdatePizzaToppingList(int pizzaid)
        {
            PizzaRepository pizza = new PizzaRepository();
            try
            {
                using (var db = new PizzaDbContext())
                {
                    pizza = db.Pizza.Where(element => element.pizzaId == pizzaid).FirstOrDefault();
                    var pizzaToppings = new List<PizzaToppingsRepository>();
                    pizzaToppings = db.PizzaToppings.Where(e => e.pizzaId == pizzaid).ToList();
                    pizza.toppingsList = pizzaToppings;

                }
            }
            catch (Exception)
            {
                return null;
            }
            return pizza;
        }
    }
}
