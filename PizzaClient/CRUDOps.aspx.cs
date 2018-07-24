using PizzaBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace PizzaClient
{
    public partial class CRUD_Ops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDataOps_Click(object sender, EventArgs e)
        {
            DummyData newDataOps = new DummyData();
            Pizza newPizzaOps = new Pizza();
            Topping newTopping = new Topping();
            Order newOrder = new Order();
            newTopping.InsertNewTopping(newDataOps.GetNewToppingToInsert());
            newPizzaOps.CreateOrder(newDataOps.GetNewPizzaToInsert());
            newOrder.CreateOrder(newDataOps.GetNewOrderToInsert());

            //newPizzaOps.CreateOrder(newPizzas.GetPizzaToppings());
            //Console.WriteLine(newDataOps.GetPizzaToppings());

            //BulletedListToppingsData.DataSource = newDataOps.GetPizzaToppings().Select(topping => topping.topping);
            //BulletedListToppingsData.DataBind();
            //BulletedListPizzaData.DataSource = newDataOps.GetPizzas().Select(pizza => pizza.name);
            //BulletedListPizzaData.DataBind();
        }
    }
}