﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Data;

namespace PizzaStore.Library.Models
{
    public class Pizza
    {

        public int id;
        public string size;
        public string name;
        public decimal cost;

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

            //purpose of below code is to try and dynamically print the ID numbers of pizzas
            //and the name of the corresponding pizza. It currently fails to match them up
            //when printing to the console

            //using (dbContext)
            //{
            //    var pizzaNameTemp = dbContext.Pizza.Select(m => m.Name).Distinct().ToArray();
            //    var pizzaId = dbContext.Pizza.Select(m => m.Id).Distinct().ToArray();
            //    var pizzaName = new string[pizzaId.Length];
                
            //    for(int i = 0; i < pizzaId.Length; i++) 
            //    {
            //        //dbContext.Customer.First(u => u.UserName == userName && u.Password == password).ToString();
            //        var temp = dbContext.Pizza.Find(pizzaNameTemp[i]).ToString();
                    
            //    }
            //    Console.ReadLine();
                
                

            //    int iterator = 0;
            //    foreach (var item in pizzaName)
            //    {

            //        System.Console.WriteLine($"{pizzaId[iterator]}. {pizzaName[iterator]}");
            //        iterator++;
            //    }
            //}
        }

        public static string GetSize()
        {

            string size;
            while (true)
            {
                Console.WriteLine("What size?");
                Console.WriteLine("S: Small");
                Console.WriteLine("M: Medium");
                Console.WriteLine("L: Large");

                string input = Console.ReadLine().ToLower();
                if(input == "s")
                {
                    size = "SM";
                    break;
                }
                else if(input == "m")
                {
                    size = "MD";
                    break;
                }
                else if(input == "l")
                {
                    size = "LG";
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }

            return size;
        }
        
    }
}
