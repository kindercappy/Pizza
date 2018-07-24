using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBL
{
    public static class Message
    {
        // General
        public static string REQUEST_NOT_UPDATED = "Sorry, we were not able to update your request";

        // Order
        public static string ORDER_NOT_CREATED = "Sorry, coundn't create your order";
        public static string ORDER_NOT_FOUND = "Sorry, the order you are looking for doesn't exist";

        // Pizza
        public static string PIZZA_NOT_CREATED = "Sorry, coundn't create your delicious pizza";
        public static string PIZZAS_NOT_FETCHED = "Sorry, we were not able to fetch your menu";

    }
}
