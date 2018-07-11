using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Library;
using PizzaStore.Library.Repositories;

namespace PizzaStore.Library.Models
{
    public class Order
    {
        public int Id;
        public DateTime Dt;
        public int LocationId;
        public int PizzaCount;
        public int Pizza1Id;
        public int Pizza2Id;
        public int Pizza3Id;
        public int Pizza4Id;
        public int Pizza5Id;
        public int Pizza6Id;
        public int Pizza7Id;
        public int Pizza8Id;
        public int Pizza9Id;
        public int Pizza10Id;
        public int Pizza11Id;
        public int Pizza12Id;
        public int CustomerId;
        public decimal Total;

        public Order()
        {
        }

        public Order(int customerId)
        {
            CustomerId = customerId;
        }

        public static Order AddPizza(PizzaStoreDBContext dbContext, Order order, int pizzaId, int pizzaCount, string size)
        {
            if (pizzaCount == 1)
            {
                
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza1Id = pizzaId;
                }
            }
            else if (pizzaCount == 2)
            {
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza2Id = pizzaId;
                }
            }
            else if (pizzaCount == 3)
            {
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza3Id = pizzaId;
                }
            }
            else if (pizzaCount == 4)
            {
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza4Id = pizzaId;
                }
            }
            else if (pizzaCount == 5)
            {
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza5Id = pizzaId;
                }
            }
            else if (pizzaCount == 6)
            {
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza6Id = pizzaId;
                }
            }
            else if (pizzaCount == 7)
            {
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza7Id = pizzaId;
                }
            }
            else if (pizzaCount == 8)
            {
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza8Id = pizzaId;
                }
            }
            else if (pizzaCount == 9)
            {
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza9Id = pizzaId;
                }
            }
            else if (pizzaCount == 10)
            {
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza10Id = pizzaId;
                }
            }
            else if (pizzaCount == 11)
            {
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza11Id = pizzaId;
                }
            }
            else if (pizzaCount == 12)
            {
                Pizza pizza = Repositories.PizzaRepository.DBContextToObj(dbContext.Pizza.First(u => u.Id == pizzaId && u.Size.Equals(size)));
                decimal temp = order.Total + pizza.cost;
                if (temp > 500)
                {
                    Console.WriteLine("Sorry, your order cannot exceeed $500.");
                }
                else
                {
                    order.Total += pizza.cost;
                    order.Pizza12Id = pizzaId;
                }
            }
            else
            {
                Console.WriteLine("You can have a maximum of twelve pizzas on your order.");
            }

            return order;
        }

        public void DisplayOrder(PizzaStoreDBContext dbContext, Order order)
        {
            Console.WriteLine("Reciept: ");
            Console.WriteLine($"Date: {Dt}");
            if (order.Pizza1Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza1Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            if (order.Pizza2Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza2Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            if (order.Pizza3Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza3Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            if (order.Pizza4Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza4Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            if (order.Pizza5Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza5Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            if (order.Pizza6Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza6Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            if (order.Pizza7Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza7Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            if (order.Pizza8Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza8Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            if (order.Pizza9Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza9Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            if (order.Pizza10Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza10Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            if (order.Pizza11Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza11Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            if (order.Pizza12Id != 0)
            {
                Pizza nameId = PizzaRepository.DBContextToObj(dbContext.Pizza.First(p => p.Id == order.Pizza12Id));
                Console.WriteLine($"   - {nameId.name}");
            }
            
            Console.WriteLine($"Total: ${order.Total} + tax");
        }
    }
}
