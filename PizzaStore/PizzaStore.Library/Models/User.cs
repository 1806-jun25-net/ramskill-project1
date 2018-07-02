using PizzaStore.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Models
{
    public class User : IUser
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string favLocation { get; set; }
        
        

        List<Order> userOrderHistory { get; set; }

        int[] favPizza { get; set; }

        public string LogIn()
        {
            throw new NotImplementedException(); 
        }

        public void ChangeName()
        {
            Console.WriteLine("Please enter your first name.");
            this.firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name.");
            this.lastName = Console.ReadLine();
            Console.WriteLine($"Thank you. You have changed your name to {firstName} {lastName}");
        }

        public void ChangeLocation()
        {
            Console.WriteLine("Please select a loction to order from.\n1.Ashburn\n2.Leesburg\n3.Sterling\n4.Reston");
            string location = Console.ReadLine();
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
            this.favLocation = location;
            Console.WriteLine($"You have set your location to {favLocation}");
        }
    }
}
