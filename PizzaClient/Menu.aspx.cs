using PizzaBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaClient
{
    public partial class Menu1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetupPizzaMenu();
        }

        private void SetupPizzaMenu()
        {
            PizzaRepository menu = new PizzaRepository();
            var pizzas = menu.GetAllPizzas();
            //BLMenu.DataSource = pizzas;
            //BLMenu.DataValueField = "name";
            //BLMenu.DataBind();
            foreach (var pizza in pizzas)
            {
                string vegOrNonveg = "";
                if (pizza.veg)
                {
                    vegOrNonveg = GeneralStrings.PIZZA_VEG;
                }
                else if (pizza.nonVeg)
                {
                    vegOrNonveg = GeneralStrings.PIZZA_NONVEG;
                }
                PLMenuList.Controls.Add(new Literal
                {
                    Text = "<div>" +
                                $"<h3>{pizza.name}</h3>" +
                                $"<p>{vegOrNonveg}</p>" +
                            "</div>"
                });
            }
        }

        protected void Tempbtn_Click(object sender, EventArgs e)
        {


        }
    }
}