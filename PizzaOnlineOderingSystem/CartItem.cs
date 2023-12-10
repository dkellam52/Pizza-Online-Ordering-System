using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOnlineOderingSystem
{
    public class CartItem
    {
        public int pizzaId;
        public string pizzaName;
        public decimal price;

        // Constructor
        public CartItem(int pizzaId, string pizzaName, decimal price)
        {
            this.pizzaId = pizzaId;
            this.pizzaName = pizzaName;
            this.price = price;
        }

        // Override ToString for display purposes
        public override string ToString()
        {
            return $"{pizzaName} - ${price}";
        }
    }


}
