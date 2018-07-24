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
        public IHttpActionResult CreateNewPizza([FromBody]Pizza pizzaBody)
        {
            Pizza pizza = new Pizza();
            var pizzaAdded = pizza.CreateOrder(pizzaBody);
            if (pizzaAdded > 0)
            {
                return Ok(pizzaAdded);
            }
            else
            {
                return BadRequest(Message.PIZZA_NOT_CREATED);
            }
        }
        [Route("{pizzaId}")]
        [HttpPost]
        public IHttpActionResult UpdatePizza(int pizzaId, [FromBody]Pizza pizzaBody)
        {
            Pizza pizza = new Pizza();
            var pizzaUpdated = pizza.UpdatePizza(pizzaId, pizzaBody);
            if (pizzaUpdated != null)
            {
                return Ok(pizzaUpdated);
            }
            else
            {
                return BadRequest(Message.REQUEST_NOT_UPDATED);
            }
        }
        [Route("{pizzaId}")]
        [HttpGet]
        public IHttpActionResult GetPizza(int pizzaId)
        {
            Pizza pizza = new Pizza();
            var pizzaReceived = pizza.GetPizza(pizzaId);
            if (pizzaReceived != null)
            {
                return Ok(pizzaReceived);
            }
            else
            {
                return NotFound();
            }
        }
        // Toppings Actions
        [Route("{pizzaId}/toppings")]
        [HttpPost]
        public IHttpActionResult UpdatePizzaToppingList(int pizzaid)
        {
            Pizza pizza = new Pizza();
            var pizzaUpdated = pizza.UpdatePizzaToppingList(pizzaid);
            if (pizzaUpdated != null)
            {
                return Ok(pizzaUpdated);
            }
            else
            {
                return BadRequest(Message.REQUEST_NOT_UPDATED);
            }
        }
    }
}
