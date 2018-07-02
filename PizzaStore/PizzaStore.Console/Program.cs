using PizzaStore.Library.Models;
using System;


namespace PizzaStore.UI
{
     public class Program
    {
        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome! Please sign in to place an order.");
        }

        static bool QuitApp()
        {
            string quitSelect;
            Console.WriteLine("Are you sure you want to quit? If you have not checked out, your order will be lost.");
            quitSelect = Console.ReadLine();
            quitSelect = quitSelect.ToLower();
            bool quit = false;
            if (quitSelect == "yes" || quitSelect == "y")
            {
                quit = true;
            }
            return quit;
        }

        public static void Main(string[] args)
        {
            WelcomeMessage();
            //take user name and location of order
            var user = new User();
            user.ChangeName();
            user.ChangeLocation();
            
            //create order to add to as the user navigates the menues
            Order order = new Order(user.firstName, user.lastName, user.favLocation);

        /***************************************************************
        goto point for returning to menu
        ****************************************************************/
        returnToMenu:

            string menuInput = order.mainMenu();
            bool quit = false;

            switch(menuInput)
            {
                case "1":
                    //add pizza
                    var pizza = new Pizza();
                    string pickPizza = pizza.AddPizza();
                    string thePizza;
                    if (pickPizza == "classic")
                    {
                        thePizza = pizza.AddClassicPizza();
                    }
                    else if (pickPizza == "custom")
                    {
                        thePizza = pizza.AddCustomPizza();
                    }
                    else
                    {
                        goto returnToMenu;
                    }
                    break;
                case "2":
                    //view order
                    Console.WriteLine("Not Implemented");
                    break;
                case "3":
                    //checkout - needs further implementation after DB is made
                    quit = order.Checkout();
                    break;
                case "4":
                    //change user
                    user.ChangeName();
                    break;
                case "5":
                    //change location
                    user.ChangeLocation();
                    break;
                case "6":
                    //quit app
                    quit = QuitApp();
                    if (quit == true)
                    {
                        break;
                    }
                    else
                    {
                        goto returnToMenu;
                    }
                default:
                    goto returnToMenu;

            }

            //return to menue is checkout is false
            if (quit == false)
            {
                goto returnToMenu;
            }
            
            System.Environment.Exit(1);

        }//end main
    }
}

