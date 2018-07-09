using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaStore.Data;
using System.IO;
using PizzaStore.Library.Models;
using System.Linq;
using System;

namespace PizzaStore.Console
{
    class Program
    {

        public static Customer LoginPrompt(CustomerRepository customerRepository, Customer customer)
        {
            System.Console.WriteLine("1. Sign in");
            System.Console.WriteLine("2. Create new account");
            string signInInput;
            do
            {
                signInInput = System.Console.ReadLine().ToLower();
                if (signInInput != "1" && signInInput != "2")
                {
                    System.Console.WriteLine("Invalid input. Please try again.");
                }
            } while (signInInput != "1" && signInInput != "2");

            if (signInInput == "1")
            {
                customer = customerRepository.SignIn();
            }
            else if (signInInput == "2")
            {
                customer = customerRepository.NewUser();
            }
            return customer;
        }

        public static void DisplayLocations(PizzaStoreDBContext DBContext)
        {
            using (DBContext)
            {
                foreach (var item in DBContext.Location)
                {
                    System.Console.WriteLine($"{item.Id}. {item.Name}");
                }
            }
        }

        public static void Main(string[] args)
        {

            //get configuration from file
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configBuilder.Build();

            // provide the connection string to the dbcontext 
            var optionsBuilder = new DbContextOptionsBuilder<PizzaStoreDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaStoreDB"));


            var options = optionsBuilder.Options;
            //access database
            var dbContext = new PizzaStoreDBContext(options);
            var customerRepository = new CustomerRepository(dbContext);
            var locationRepository = new LocationRepository(dbContext);

            //user sign in or create account. 
            System.Console.WriteLine("Please sign in to continue:");

            Customer customer = new Customer();
            customer = LoginPrompt(customerRepository, customer);

            //create order object
            Order order = new Order(customer.Id);

            /**********************************************
             * This is the beginning of the menu
             * *******************************************/
            while (true)
            {
                System.Console.WriteLine($"Welcome {customer.FirstName} {customer.LastName}.");
                System.Console.WriteLine("Please select a valid option from the menu.");
                //if the customer is an admit, display additional menu options
                if (customer.Admin == 1)
                {
                    System.Console.WriteLine("Admin: View Admin Menu");
                }
                System.Console.WriteLine("1. Start an order");
                System.Console.WriteLine("2. Change user");
                System.Console.WriteLine("3. Quit");
                string input = System.Console.ReadLine().ToLower();
                if (input == "1")
                {
                    //set orderLocation and/or update customer's favorite location if empty

                    //if customer has not set a favorite location
                    if (customer.FavoriteLocationId != null)//change back to == after debugging
                    {
                        //get locations
                        while(true)
                        {
                            System.Console.WriteLine("What location would you like to order from?");
                            DisplayLocations(dbContext);
                            string locInputStr = System.Console.ReadLine();
                            //try converting string to int or display error message
                            try
                            {
                                int locInputInt = Convert.ToInt32(locInputStr);
                                //add location to Customer.FavoriteLocationId && add location to order.LocationId

                                //if checks if locInputInt matches a locationID in the DB
                                if (dbContext.Location.Any(o => o.Id == locInputInt))
                                {
                                    customer.FavoriteLocationId = locInputInt;
                                    dbContext.SaveChanges();
                                    order.orderLocation = locInputInt;
                                    break;
                                }
                                
                            }
                            catch
                            {
                                System.Console.WriteLine("Invalid input.");
                            }
                        }
                        
                    }
                    //if customer already has a favorite location
                    else
                    {
                        //set order location and inform customer of their default location
                        order.orderLocation = customer.FavoriteLocationId.GetValueOrDefault();
                        Location location = locationRepository.GetLocation(customer.FavoriteLocationId.GetValueOrDefault());
                        System.Console.WriteLine($"Ordering from {location.Name}");
                        System.Console.WriteLine("To select a different location, enter \"1\".");
                        System.Console.WriteLine("Otherwise, press any key to continue.");

                    }
                    
                }
                else if (input == "2")
                {
                    customer = LoginPrompt(customerRepository, customer);
                }
                else if (input == "3")
                {
                    System.Console.WriteLine("Are you sure you wish to quit? (Y/N)");
                    string quit = System.Console.ReadLine();
                    quit = quit.ToLower();
                    if (quit == "y")
                    {
                        break;
                    }
                }
                else if (input == "admin")
                {
                    if (customer.Admin == 1)
                    {
                        System.Console.WriteLine("You're an administrator!");
                        System.Console.ReadLine();
                        //admin options and functionalities
                    }
                }
                else
                {
                    System.Console.WriteLine("Invalid input.");
                }
            }
        }//end main
    }
}

