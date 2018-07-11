using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Data;
using PizzaStore.Library.Repositories;

namespace PizzaStore.Library.Models
{
    public class CustomerRepository
    {

        public int id;
        public string firstName;
        public string lastName;
        public string userName;
        public string password;
        public int favoriteLocationId;
        public int admin;

        private PizzaStoreDBContext _db;

        public CustomerRepository(string firstName, string lastName, string ID)
        {
        }

        public CustomerRepository(PizzaStoreDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public CustomerRepository()
        {
        }

        public CustomerRepository NewUser(PizzaStoreDBContext dbContext)
        {
            string userName;
            string password;
            string firstName;
            string lastName;

            while (true)
            {
                //get fist name from user
                do
                {
                    Console.WriteLine("Please enter your first name:");
                    firstName = Console.ReadLine();
                    if (firstName.Length == 0)
                    {
                        Console.WriteLine("Name cannot be empty.");
                    }
                    else if (!firstName.All(Char.IsLetter))
                    {
                        Console.WriteLine("Name can only have alphabetical letters.");
                    }
                } while (firstName.Length == 0 || !firstName.All(Char.IsLetter));

                //get last name from user (optional)
                do
                {
                    Console.WriteLine("Please enter your last name (optional):");
                    lastName = Console.ReadLine();
                    if (!lastName.All(Char.IsLetter))
                    {
                        Console.WriteLine("Name can only have alphabetical letters.");
                    }
                } while (lastName.Length != 0 && !lastName.All(Char.IsLetter));

                //get userName from user
                do
                {
                    Console.WriteLine("Please enter your desired username:");
                    userName = Console.ReadLine();
                    if (userName.Length == 0)
                    {
                        Console.WriteLine("Username cannot be empty.");
                    }
                } while (userName.Length == 0);

                //get password from user
                do
                {
                    Console.WriteLine("Please enter your desired password:");
                    password = Console.ReadLine();
                    if (password.Length == 0)
                    {
                        Console.WriteLine("Password cannot be empty.");
                    }
                } while (password.Length == 0);
                Customer customer = new Customer(firstName, lastName, userName, password);

                try
                {
                    dbContext.Customer.Add(customer);
                    dbContext.SaveChanges();
                    break;
                }
                catch
                {
                    Console.WriteLine("Error communicating with database. Please try again later.");
                }
            }

            CustomerRepository customerInfo = CustomerRepository.DBContextToObj(dbContext.Customer.First(u => u.UserName == userName && u.Password == password));
            return customerInfo;
        }
        public CustomerRepository SignIn(PizzaStoreDBContext dbContext)
        {
            string userName;
            string password;
            
            
            while(true)
            {
                do
                {
                    Console.WriteLine("Please enter your username:");
                    userName = Console.ReadLine();
                    if (userName.Length == 0)
                    {
                        Console.WriteLine("Username cannot be empty.");
                    }
                } while (userName.Length == 0);

                do
                {
                    Console.WriteLine("Please enter your password:");
                    password = Console.ReadLine();
                    if (password.Length == 0)
                    {
                        Console.WriteLine("Password cannot be empty.");
                    }
                } while (password.Length == 0);
                
                
                try
                {
                    var customer = dbContext.Customer.First(u => u.UserName == userName && u.Password == password).ToString();
                    break;
                }
                catch
                {
                    Console.WriteLine("Either your username or password is incorrect. Please try again.");
                }

            }

            Customer customerInfo = dbContext.Customer.First(u => u.UserName == userName && u.Password == password);
            CustomerRepository customerObj = DBContextToObj(customerInfo);
            return customerObj;
        }

        public static void DisplayOrderHistory(PizzaStoreDBContext dbContext, CustomerRepository customer)
        {
            using (dbContext)
            {
                foreach (var item in dbContext.OrderHistory)
                {
                    if(item.CustomerId == customer.id)
                    {
                        Order order = OrderRepository.DBContextToObject(item);
                        order.DisplayOrder(dbContext, order);
                    }
                }
            }
        }

        public void UpdateFavoriteLocation(CustomerRepository customer, int newLocationId,PizzaStoreDBContext dbContext)
        {
            customer.favoriteLocationId = newLocationId;

            var currObj = dbContext.Customer.Find(customer.id);
            var newObj = ObjToDBContext(customer);

            dbContext.Entry(currObj).CurrentValues.SetValues(newObj);
            dbContext.SaveChanges();
        }

        public static Customer ObjToDBContext(CustomerRepository customer) => new Customer
        {
            Id = customer.id,
            FirstName = customer.firstName,
            LastName = customer.lastName,
            UserName = customer.userName,
            Password = customer.password,
            FavoriteLocationId = customer.favoriteLocationId
        };
        public static CustomerRepository DBContextToObj(Customer customer) => new CustomerRepository
        {
            id = customer.Id,
            firstName = customer.FirstName,
            lastName = customer.LastName,
            userName = customer.UserName,
            password = customer.Password,
            favoriteLocationId = customer.FavoriteLocationId.GetValueOrDefault(),
        };





    }//end class
}
