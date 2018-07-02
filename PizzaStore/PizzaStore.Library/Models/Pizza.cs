using System;
using System.Collections.Generic;
using System.Text;
using PizzaStore.Library;

namespace PizzaStore.Library.Models
{
    public class Pizza
    {
        public string AddPizza()
        {
            Console.WriteLine("1. Add Classic Pizza\n2. Add Custom Pizza\n3. Cancel");
            string menuSelect = Console.ReadLine();
            menuSelect = menuSelect.ToLower();

            if (menuSelect == "1" || menuSelect == "classic")
            {
                menuSelect = "addClassic";
            }
            else if (menuSelect == "2" || menuSelect == "custom")
            {
                menuSelect = "addCustom";
            }
            else if (menuSelect == "3" || menuSelect == "cancel")
            {
                menuSelect = "cancel";
            }
            else
            {
                Console.WriteLine("Please selct a pizza to add.\n");
                AddPizza();
            }

            return menuSelect;
        }

        public string AddClassicPizza()
        {
            string pizza = "return Classic";
            return pizza;
        }

        public string AddCustomPizza()
        {
            string pizza = "return Custom";
            return pizza;
        }


    }
}
