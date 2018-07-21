using PizzaBL;
using PizzaBL.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace PizzaApi.Controllers
{
    [RoutePrefix("api/pizza")]
    public class PizzaController : ApiController
    {
        //Pizza Actions
        [Route("new")]
        [HttpPost]
        public int CreateNewPizza([FromBody]Pizza pizzaBody)
        {
            Pizza pizza = new Pizza();
            var pizzaAdded = pizza.AddPizza(pizzaBody);
            return pizzaAdded;
        }
        [Route("{pizzaId}")]
        [HttpPost]
        public Pizza UpdatePizza(int pizzaId,[FromBody]Pizza pizzaBody)
        {
            Pizza pizza = new Pizza();
            var pizzaUpdated = pizza.UpdatePizza(pizzaId,pizzaBody);
            return pizzaUpdated;
        }
        // Toppings Actions
        [Route("{pizzaId}/toppings")]
        [HttpPost]
        public Pizza UpdatePizzaToppingList(int pizzaid)
        {
            Pizza pizza = new Pizza();
            var pizzaUpdated = pizza.UpdatePizzaToppingList(pizzaid);
            return pizzaUpdated;
        }
    }
}
