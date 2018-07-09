using PizzaStore.Library.Interfaces;
using PizzaStore.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Models
{
    public class Order
    {
        public int orderLocation { get; set; }
        public int orderCustomerID { get; set; }
        private double total = 0;

        public Order(string firstName, string lastName, string orderLocation)
        {

        }

        public Order(int orderCustomerID)
        {
            this.orderCustomerID = orderCustomerID;
        }

        public void CreateOrder(string firstName,string lastName, string location)
        {
            mainMenu();
        }

        public string mainMenu()
        {
            string menuSelect;

            //loop through menu till user selects a valid option
            do
            {
                Console.WriteLine($"Please select an option from the menu to contine.\n1. Add Pizza\n2. View order\n3. Checkout\n4. Change user\n5. Change location\n6. Quit Application");
                menuSelect = Console.ReadLine();
                menuSelect = menuSelect.ToLower();

                //if user doesn't select a valid option, display error message and loop
                if (menuSelect != "1" && menuSelect != "2" && menuSelect != "3" &&
                menuSelect != "4" && menuSelect != "5" && menuSelect != "6")
                {
                    Console.WriteLine("Not a valid input");
                }

            } while (menuSelect != "1" && menuSelect != "2" && menuSelect != "3" &&
                menuSelect != "4" && menuSelect != "5" && menuSelect != "6");
                        
            return menuSelect;
        }

        public void ViewOrder()
        {
            throw new NotImplementedException();
        }

        public bool Checkout()
        {
            Console.WriteLine($"You're total is ${total}. Would you like to checkout?");
            string input = Console.ReadLine();
            input = input.ToLower();

            bool quit = false;
            if (input == "yes")
            {
                Console.WriteLine("Thank you for your business. Application will now close.");
                quit = true;
                Console.ReadLine();
            }

            return quit;
        }

    }
}
