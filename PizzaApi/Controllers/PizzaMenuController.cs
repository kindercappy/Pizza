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
        public IHttpActionResult GetAllPizzas()
        {
            Pizza pizzas = new Pizza();
            List<Pizza> allPizzas = pizzas.GetAllPizzas();
            if (allPizzas != null)
            {
                return Ok(allPizzas);
            }
            else
            {

                return NotFound();
            }
        }
        [Route("{typeOfPizza}")]
        [HttpGet]
        public IHttpActionResult GetVegOrNonvegPizzaMenu(string typeOfPizza)
        {
            Pizza pizzas = new Pizza();
            List<Pizza> typesOfPizza = pizzas.GetTypesOfPizzas(typeOfPizza);
            if (typeOfPizza != null)
            {
                return Ok(typesOfPizza);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
