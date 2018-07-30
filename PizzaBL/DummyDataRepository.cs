using PizzaBL.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBL
{
    public class DummyDataRepository
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
        public List<PizzaRepository> GetNewPizzaListToInsert()
        {
            return new List<PizzaRepository>() {
                new PizzaRepository() { name = "Farmhouse",pizzaBase = PizzaBase.Cheese, nonVeg = false, veg = true, toppingsList =   new List<PizzaToppingsRepository>() {
                    new PizzaToppingsRepository() { }
                } },
            };
        }
        public PizzaRepository GetNewPizzaToInsert()
        {
            DummyDataRepository newDataOps = new DummyDataRepository();
            PizzaToppingsRepository newPizzaToppinsToInsert = new PizzaToppingsRepository();

            List<PizzaToppingsRepository> pizzaToppings = new List<PizzaToppingsRepository>() {
                new PizzaToppingsRepository() {
                    toppingId = GetPizzaToppings().FirstOrDefault().toppingId
                },
                new PizzaToppingsRepository() {
                    toppingId = GetPizzaToppings().LastOrDefault().toppingId
                }
            };
            return new PizzaRepository()
            {
                name = "Farmhouse " + GlobalNumberForPizza,
                nonVeg = false,
                pizzaBase = PizzaBase.Cheese,
                veg = true,
                toppingsList = pizzaToppings
            };
        }
        public List<ToppingRepository> GetNewToppingsToInsert()
        {
            return new List<ToppingRepository>() {
                new ToppingRepository()
                {
                    topping = ToppingType.Onion
                },
                new ToppingRepository()
                {
                    topping = ToppingType.Onion
                },
                new ToppingRepository()
                {
                    topping = ToppingType.Onion
                },
                new ToppingRepository()
                {
                    topping = ToppingType.Onion
                }
            };
        }
        public ToppingRepository GetNewToppingToInsert()
        {
            return new ToppingRepository()
            {
                topping = ToppingType.Tomato
            };
        }
        public List<PizzaRepository> GetPizzas()
        {
            List<PizzaRepository> pizzas = new List<PizzaRepository>();
            using (var db = new PizzaDbContext())
            {
                pizzas = db.Pizza.ToList();

            }
            return pizzas;
        }
        public List<ToppingRepository> GetPizzaToppings()
        {
            List<ToppingRepository> toppings = new List<ToppingRepository>();
            using (var db = new PizzaDbContext())
            {
                toppings = db.Toppings.ToList();
            }
            return toppings;
        }
        public PizzaToppingsRepository GetNewPizzaToppingToInsert()
        {
            DummyDataRepository newDataOps = new DummyDataRepository();
            return new PizzaToppingsRepository() { };
        }
        // TODO : Methods for the order and orderItem table 
        public OrderRepository GetNewOrderToInsert()
        {
            PizzaRepository pizzaList = new PizzaRepository();
            int pizzaIdToOrderFirst = pizzaList.GetAllPizzas().Select(pizz => pizz.pizzaId).FirstOrDefault();
            int pizzaIdToOrderLast = pizzaList.GetAllPizzas().Select(pizz => pizz.pizzaId).LastOrDefault();
            List<OrderItemRepository> newOrderItems = new List<OrderItemRepository>() {
                new OrderItemRepository()
                {
                    pizzaItem = pizzaIdToOrderFirst
                },
                new OrderItemRepository()
                {
                    pizzaItem = pizzaIdToOrderLast
                }
            };

            OrderRepository newOrder = new OrderRepository() {
                customerName = "Kinder",
                customerPhone = "0000000000",
                orderItems = newOrderItems
            };

            return newOrder;
        }
    }
}
