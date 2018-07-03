using System;
using System.Collections.Generic;
using System.Text;
using PizzaStore.Library;

namespace PizzaStore.Library.Models
{
    public class Pizza
    {
        public string crust { get; set; }
        public string sauce { get; set; }
        public List<string> toppings { get; set; }

        public string AddPizza()
        {
            Console.WriteLine("1. Add Classic Pizza\n2. Add Custom Pizza\n3. Cancel");
            string menuSelect = Console.ReadLine();
            menuSelect = menuSelect.ToLower();

            if (menuSelect == "1" || menuSelect == "classic")
            {
                menuSelect = "classic";
            }
            else if (menuSelect == "2" || menuSelect == "custom")
            {
                menuSelect = "custom";
            }
            else if (menuSelect == "3" || menuSelect == "cancel")
            {
                menuSelect = null;
            }
            else
            {
                Console.WriteLine("Please selct a pizza to add.\n");
                AddPizza();
            }

            return menuSelect;
        }

        public void AddClassicPizza()
        {
            List<string> toppings = new List<string>();

            Console.WriteLine("1. Classic Pepperoni\n2. Thin Crust Vegetarian\n3. Deep Dish Meat Lovers\n4. Cancel");
            string input = Console.ReadLine();
            input = input.ToLower();
            
            if (input == "1" || input == "classic" || input == "pepperoni" || input == "classic pepperoni")
            {
                crust = "recular";
                sauce = "marinara";
                toppings.Add("pepperoni");
            }
            else if (input == "2" || input == "vegetarian" || input == "thin crust vegetarian" )
            {
                crust = "thin";
                sauce = "marinara";
                toppings.Add("onions");
                toppings.Add("tomatoes");
                toppings.Add("green peppers");
                toppings.Add("spinach");
                toppings.Add("mushrooms");
            }
            else if (input =="3" || input == "meat" || input == "mean lovers" || input == "deep dish meat lovers")
            {
                crust = "deep";
                sauce = "BBQ";
                toppings.Add("pepperoni");
                toppings.Add("ham");
                toppings.Add("sausage");
                toppings.Add("bacon");
            }
            else if (input == "4" || input == "cancel")
            {
                //let method end, doing nothing
            }
            else
            {
                Console.WriteLine("Please select a valid input.");
                AddClassicPizza();
            }
        }

        public void AddCustomPizza()
        {
            throw new NotImplementedException();
        }


    }
}
