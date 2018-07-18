using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Data;

namespace PizzaStore.Library.Models
{
    public class Pizza
    {

        public int id { get; set; }
        public string size { get; set; }
        public string name { get; set; }
        public decimal cost { get; set; }

        public static int PickPizza(PizzaStoreDBContext dbContext)
        {
            int pizzaInputInt;
            DisplayPizzas(dbContext);
            while (true)
            {
                System.Console.WriteLine("Select a pizza to order:");
                
                string pizzaInputStr = System.Console.ReadLine();

                //try converting string to int
                try
                {
                    pizzaInputInt = Convert.ToInt32(pizzaInputStr);
                    break;
                }
                catch
                {
                    System.Console.WriteLine("Invalid input.");
                }
            }
            return pizzaInputInt;
        }

        public static void DisplayPizzas(PizzaStoreDBContext dbContext)
        {
            Console.WriteLine("1. Cheese");
            Console.WriteLine("2. Pepperoni");
            Console.WriteLine("3. Meat Lovers");
            Console.WriteLine("4. Veggie");
            Console.WriteLine("5. Hawaiian");
            Console.WriteLine("6. Golden Sun");
        }

        public static string GetSize()
        {

            string pSize;
            while (true)
            {
                Console.WriteLine("What size?");
                Console.WriteLine("S: Small");
                Console.WriteLine("M: Medium");
                Console.WriteLine("L: Large");

                string input = Console.ReadLine().ToLower();
                if(input == "s")
                {
                    pSize = "SM";
                    break;
                }
                else if(input == "m")
                {
                    pSize = "MD";
                    break;
                }
                else if(input == "l")
                {
                    pSize = "LG";
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }

            return pSize;
        }
        
    }
}
