using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Models
{
    public class Order
    {
        public Order(int customerId)
        {
            CustomerId = customerId;
        }

        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int LocationId { get; set; }
        public int PizzaCount { get; set; }
        public int Pizza1Id { get; set; }
        public int? Pizza2Id { get; set; }
        public int? Pizza3Id { get; set; }
        public int? Pizza4Id { get; set; }
        public int? Pizza5Id { get; set; }
        public int? Pizza6Id { get; set; }
        public int? Pizza7Id { get; set; }
        public int? Pizza8Id { get; set; }
        public int? Pizza9Id { get; set; }
        public int? Pizza10Id { get; set; }
        public int? Pizza11Id { get; set; }
        public int? Pizza12Id { get; set; }
        public int CustomerId { get; set; }

        public static Order AddPizza(Order order, int pizzaId, int pizzaCount)
        {
            if (pizzaCount == 1)
            {
                order.Pizza1Id = pizzaId;
            }
            else if (pizzaCount == 2)
            {
                order.Pizza2Id = pizzaId;
            }
            else if (pizzaCount == 3)
            {
                order.Pizza3Id = pizzaId;
            }
            else if (pizzaCount == 4)
            {
                order.Pizza4Id = pizzaId;
            }
            else if (pizzaCount == 5)
            {
                order.Pizza5Id = pizzaId;
            }
            else if (pizzaCount == 6)
            {
                order.Pizza6Id = pizzaId;
            }
            else if (pizzaCount == 7)
            {
                order.Pizza7Id = pizzaId;
            }
            else if (pizzaCount == 8)
            {
                order.Pizza8Id = pizzaId;
            }
            else if (pizzaCount == 9)
            {
                order.Pizza9Id = pizzaId;
            }
            else if (pizzaCount == 10)
            {
                order.Pizza10Id = pizzaId;
            }
            else if (pizzaCount == 11)
            {
                order.Pizza11Id = pizzaId;
            }
            else if (pizzaCount == 12)
            {
                order.Pizza12Id = pizzaId;
            }
            else
            {
                Console.WriteLine("You can have a maximum of twelve pizzas on your order.");
            }

            return order;
        }
    }
}
