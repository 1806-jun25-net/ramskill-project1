using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaStore.Data;
using System.IO;
using PizzaStore.Library.Models;
using System.Linq;
using System;
using PizzaStore.Library.Repositories;

namespace PizzaStore.Console
{
    class Program
    {

        public static CustomerRepository LoginPrompt(CustomerRepository customer, PizzaStoreDBContext dbContext)
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
                customer = customer.SignIn(dbContext);
            }
            else if (signInInput == "2")
            {
                customer = customer.NewUser(dbContext);
            }
            return customer;
        }

        public static void DisplayLocations(PizzaStoreDBContext dbContext)
        {
            using (dbContext)
            {
                foreach (var item in dbContext.Location)
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

            CustomerRepository customer = new CustomerRepository();
            customer = LoginPrompt(customer, dbContext);

            //create order object
            

            /**********************************************
             * This is the beginning of the menu
             * *******************************************/
            while (true)
            {
                //create new dbContext to fix a login bug that threw a null exeption on dbContext
                //sometimes when switching between users
                dbContext = new PizzaStoreDBContext(options);

                System.Console.WriteLine($"Welcome {customer.firstName} {customer.lastName}.");
                System.Console.WriteLine("Please select a valid option from the menu.");
                //if the customer is an admin, display additional menu options
                if (customer.admin == 1)
                {
                    System.Console.WriteLine("Admin: View Admin Menu");
                }
                System.Console.WriteLine("1. Start an order");
                System.Console.WriteLine("2. Change user");
                System.Console.WriteLine("3. View Order History");
                System.Console.WriteLine("4. Quit");
                string input = System.Console.ReadLine().ToLower();
                if (input == "1")
                {
                    //set orderLocation and/or update customer's favorite location if empty
                    Order order = new Order(customer.id);

                    //if customer has not set a favorite location
                    if (customer.favoriteLocationId == 0)
                    {
                        //get locations
                        while(true)
                        {
                            System.Console.WriteLine("What location would you like to order from?");
                            DisplayLocations(dbContext);
                            //remake dbContext after disposal
                            dbContext = new PizzaStoreDBContext(options);
                            //initialize locInputInt for later
                            int locInputInt;

                            //loop until user put in valid location ID
                            while(true)
                            {
                                string locInputStr = System.Console.ReadLine();
                                //try converting string to int or display error message
                                try
                                {
                                    locInputInt = Convert.ToInt32(locInputStr);
                                    break;
                                }
                                catch
                                {
                                    System.Console.WriteLine("Invalid input.");
                                }
                            }

                            //add location to Customer.FavoriteLocationId && add location to order.LocationId

                            //checks if locInputInt matches a locationID in the DB
                            if (dbContext.Location.Any(o => o.Id == locInputInt))
                            {
                                customerRepository.UpdateFavoriteLocation(customer, locInputInt, dbContext);
                                break;
                            }
                            else
                            {
                                System.Console.WriteLine("That location doesn't exist. Please try again.");
                            }
                        }
                    }
                    //if customer already has a favorite location
                    else
                    {
                        //set order location and inform customer of their default location
                        order.LocationId = customer.favoriteLocationId;
                        Location location = locationRepository.GetLocation(dbContext, customer.favoriteLocationId);
                        System.Console.WriteLine($"Ordering from {location.Name}");
                        System.Console.WriteLine("To select a different location, enter \"1\".");
                        System.Console.WriteLine("Otherwise, press any key to continue.");
                        string locInput = System.Console.ReadLine();

                        //if 1, choose new location
                        if (locInput == "1")
                        {
                            System.Console.WriteLine("Select a location to place your order:");
                            //display locations and replace the disposed dbContext object
                            DisplayLocations(dbContext);
                            dbContext = new PizzaStoreDBContext(options);

                            int locInputInt;
                            //loop until user put in valid location ID
                            while (true)
                            {
                                string locInputStr = System.Console.ReadLine();
                                //try converting string to int or display error message
                                try
                                {
                                    locInputInt = Convert.ToInt32(locInputStr);
                                    break;
                                }
                                catch
                                {
                                    System.Console.WriteLine("Invalid input.");
                                }
                            }
                        }
                        //if not 1, use default FavoriteLocation
                        else
                        {
                            int pizzaSelection;
                            int pizzaCount = 1;

                            while(true)
                            {
                                while (true)
                                {
                                    //Customer select pizza and initialize new dbContext
                                    pizzaSelection = Library.Models.Pizza.PickPizza(dbContext);
                                    dbContext = new PizzaStoreDBContext(options);

                                    //check if input pizzaId exists in DB
                                    if (dbContext.Pizza.Any(o => o.Id == pizzaSelection))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Invalid Input.");
                                    }
                                }

                                //get pizza size
                                string size = Library.Models.Pizza.GetSize();

                                //add pizza to order
                                order = Order.AddPizza(dbContext, order, pizzaSelection, pizzaCount, size);

                                //if there is a pizza at current count, increment counter.
                                if (order.Pizza1Id != 0)
                                {
                                    pizzaCount = 1;
                                }
                                if (order.Pizza2Id != 0)
                                {
                                    pizzaCount = 2;
                                }
                                if (order.Pizza3Id != 0)
                                {
                                    pizzaCount = 3;
                                }
                                if (order.Pizza4Id != 0)
                                {
                                    pizzaCount = 4;
                                }
                                if (order.Pizza5Id != 0)
                                {
                                    pizzaCount = 5;
                                }
                                if (order.Pizza6Id != 0)
                                {
                                    pizzaCount = 6;
                                }
                                if (order.Pizza7Id != 0)
                                {
                                    pizzaCount = 7;
                                }
                                if (order.Pizza8Id != 0)
                                {
                                    pizzaCount = 8;
                                }
                                if (order.Pizza9Id != 0)
                                {
                                    pizzaCount = 9;
                                }
                                if (order.Pizza10Id != 0)
                                {
                                    pizzaCount = 10;
                                }
                                if (order.Pizza11Id != 0)
                                {
                                    pizzaCount = 11;
                                }
                                if (order.Pizza12Id != 0)
                                {
                                    pizzaCount = 12;
                                }

                                //ask if customer wants another pizza or to checkout
                                bool checkoutInput = false;
                                while(true)
                                {
                                    System.Console.WriteLine("Would you like to add another pizza to your order? (Y/N)");
                                    string again = System.Console.ReadLine().ToLower();
                                    if (again == "y")
                                    {
                                        pizzaCount++;
                                        break;
                                    }
                                    else if (again == "n")
                                    {
                                        checkoutInput = true;
                                        break;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Invalid input.");
                                    }
                                }

                                if (checkoutInput == true)
                                {
                                    order.Dt = System.DateTime.Now;
                                    order.PizzaCount = pizzaCount;
                                    order.DisplayOrder(dbContext, order);
                                    try
                                    {
                                        dbContext.OrderHistory.Add(OrderRepository.ObjToDBContext(order));
                                        dbContext.SaveChanges();
                                        break;
                                    }
                                    catch
                                    {
                                        System.Console.WriteLine("Error communicating with database. Please try again later.");
                                    }
                                    System.Console.ReadLine();
                                    break;
                                }
                            }
                            

                        }
                    }
                    
                }
                else if (input == "2")
                {
                    customer = LoginPrompt(customer, dbContext);
                }
                else if (input == "3")
                {
                    CustomerRepository.DisplayOrderHistory(dbContext, customer);
                }
                else if (input == "4")
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
                    if (customer.admin == 1)
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

