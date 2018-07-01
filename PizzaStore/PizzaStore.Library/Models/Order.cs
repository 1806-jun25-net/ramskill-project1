using PizzaStore.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Models
{
    public class Order
    {


        public Order(string orderUser, string orderLocation)
        {

        }

        public string orderLocation { get; set; }
        public string orderUser { get; set; }
        

        public void CreateOrder(string userName, string location)
        {
            mainMenu();
        }

        public string mainMenu()
        {
            string menuSelect;

            Console.WriteLine($"Please select an option from the menu to contine.\n1. Add Pizza\n2. View order\n3. Checkout\n4. Change user\n5. Change location\n6. Quit Application");
            menuSelect = Console.ReadLine();
            menuSelect = menuSelect.ToLower();

            switch(menuSelect)
            {
                case "1":
                    AddPizza();
                    break;

                case "2":
                    ViewOrder();
                    break;

                case "3":
                    Checkout();
                    break;

                case "4":
                    ChangeUser();
                    break;

                case "5":
                    ChangeLocation();
                    break;

                case "6":
                    QuitApp();
                    break;

                default:
                    mainMenu();
                    break;
            }
                 

            return menuSelect;
        }

        public void AddPizza()
        {
            string menuSelect = null;

            Console.WriteLine("1. Add Classic Pizza\n2. Add Custom Pizza\n3. Main Menu");
            menuSelect = Console.ReadLine();
            menuSelect = menuSelect.ToLower();

            if (menuSelect == "1" || menuSelect == "classic")
            {
                AddClassicPizza();
            }
            else if (menuSelect == "2" || menuSelect == "custom")
            {
                AddCustomPizza();
            }
            else if (menuSelect == "3" || menuSelect == "menu" || menuSelect == "main menu")
            {
                mainMenu();
            }
            else
            {
                Console.WriteLine("Please selct a pizza to add.\n");
                AddPizza();
            }

        }

        public void AddClassicPizza()
        {
            throw new NotImplementedException();
        }

        public void AddCustomPizza()
        {
            throw new NotImplementedException();
        }

        public void ViewOrder()
        {
            throw new NotImplementedException();
        }

        public void Checkout()
        {
            throw new NotImplementedException();
        }

        public string ChangeUser()
        {
            throw new NotImplementedException();
        }

        public string ChangeLocation()
        {
            throw new NotImplementedException();
        }

        public void QuitApp()
        {
            string quitSelect;
            Console.WriteLine("Are you sure you want to quit? If you have not checked out, your order will be lost.");
            quitSelect = Console.ReadLine();
            quitSelect = quitSelect.ToLower();
            if (quitSelect == "yes" || quitSelect == "y")
            {
                System.Environment.Exit(1);
            }
            else
            {
                mainMenu();
            }
        }

    }



    
}
