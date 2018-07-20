using PizzaBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PizzaApi.Controllers
{
    [RoutePrefix("api/pizzaMenu")]
    public class PizzaMenuController : ApiController
    {
        [Route("")]
        [HttpGet]
        public List<Pizza> GetAllPizzas()
        {
            Pizza pizzas = new Pizza();
            List<Pizza> allPizzas = pizzas.GetAllPizzas();
            return allPizzas;
        }
        [Route("{typeOfPizza}")]
        [HttpGet]
        public List<Pizza> GetVegOrNonvegPizzaMenu(string typeOfPizza)
        {
            Pizza pizzas = new Pizza();
            List<Pizza> typesOfPizza = pizzas.GetTypesOfPizzas(typeOfPizza);
            return typesOfPizza;
        }
    }
}
