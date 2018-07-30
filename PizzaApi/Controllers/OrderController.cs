using PizzaBL;
using PizzaBL.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PizzaApi.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateOrderController([FromBody] OrderRepository orderBody)
        {
            OrderRepository newOrder = new OrderRepository();
            int statusMessage = newOrder.CreateOrder(orderBody);
            if (statusMessage > 0)
            {
                return Ok(statusMessage);
            }
            else
            {
                return BadRequest(Message.ORDER_NOT_CREATED);
            }

        }
        [Route("{orderId}")]
        [HttpGet]
        public HttpResponseMessage GetOrderController(int orderId)
        {
            OrderRepository getOrder = new OrderRepository();
            var result = getOrder.GetOrder(orderId);
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,result);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,Message.ORDER_NOT_FOUND);
            }
        }
    }
}
