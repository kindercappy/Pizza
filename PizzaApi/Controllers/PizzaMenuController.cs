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
            PizzaRepository pizzas = new PizzaRepository();
            List<PizzaRepository> allPizzas = pizzas.GetAllPizzas();
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
            PizzaRepository pizzas = new PizzaRepository();
            List<PizzaRepository> typesOfPizza = pizzas.GetTypesOfPizzas(typeOfPizza);
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
