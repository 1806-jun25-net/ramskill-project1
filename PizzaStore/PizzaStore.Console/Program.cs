using PizzaStore.Library.Models;
using System;


namespace PizzaStore.UI
{
     public class Program
    {

        static string WelcomeMessage()
        {
            string userName;

            Console.WriteLine("Welcome! Please sign in to place an order.\nName: ");
            userName = Console.ReadLine();

            Console.WriteLine($"Welcome {userName}. Thank you for choosing Checker's Pizza.");

            return userName; 
        }

        static string LocationPicker()
        {
            string location;

            Console.WriteLine("Thank you {userName}. Please select a loction to order from.\n1. Ashburn\n2. Leesburg\n3. Sterling\n4. Reston");
            location = Console.ReadLine();
            location = location.ToLower();

            if (location != "1" && location != "2" && location != "3" && location != "4" && 
                location != "ashburn" && location != "leesburg" && location != "sterling" && location != "reston")
            {
                do
                {
                    Console.WriteLine("Please select an option from the menu.");
                    location = Console.ReadLine();
                    location = location.ToLower();
                } while (location != "1" && location != "2" && location != "3" && location != "4" && 
                        location != "ashburn" && location != "leesburg" && location != "sterling" && location != "reston");
                
            }
            return location;
        }

        public static void Main(string[] args)
        {
            
            string userName = WelcomeMessage();
            string favLocation = LocationPicker();

            Order order = new Order(userName, favLocation);

            string menuSelect = null;
            menuSelect = order.mainMenu();






        }//end main
    }//end class
}//end namespace

