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

        private readonly PizzaStoreDBContext _db;

        public CustomerRepository(PizzaStoreDBContext db)
        {

            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public CustomerRepository()
        {
        }

        public CustomerRepository NewUser(PizzaStoreDBContext dbContext)
        {
            string customerName;
            string pass;
            string customerFirst;
            string customerLast;

            while (true)
            {
                //get fist name from user
                do
                {
                    Console.WriteLine("Please enter your first name:");
                    customerFirst = Console.ReadLine();
                    if (customerFirst.Length == 0)
                    {
                        Console.WriteLine("Name cannot be empty.");
                    }
                    else if (!customerFirst.All(Char.IsLetter))
                    {
                        Console.WriteLine("Name can only have alphabetical letters.");
                    }
                } while (customerFirst.Length == 0 || !customerFirst.All(Char.IsLetter));

                //get last name from user (optional)
                do
                {
                    Console.WriteLine("Please enter your last name (optional):");
                    customerLast = Console.ReadLine();
                    if (!customerLast.All(Char.IsLetter))
                    {
                        Console.WriteLine("Name can only have alphabetical letters.");
                    }
                } while (customerLast.Length != 0 && !customerLast.All(Char.IsLetter));

                //get userName from user
                do
                {
                    Console.WriteLine("Please enter your desired username:");
                    customerName = Console.ReadLine();
                    if (customerName.Length == 0)
                    {
                        Console.WriteLine("Username cannot be empty.");
                    }
                } while (customerName.Length == 0);

                //get password from user
                do
                {
                    Console.WriteLine("Please enter your desired password:");
                    pass = Console.ReadLine();
                    if (pass.Length == 0)
                    {
                        Console.WriteLine("Password cannot be empty.");
                    }
                } while (pass.Length == 0);
                Customer customer = new Customer(customerFirst, customerLast, customerName, pass);

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

            CustomerRepository customerInfo = CustomerRepository.DBContextToObj(dbContext.Customer.First(u => u.UserName == customerName && u.Password == pass));
            return customerInfo;
        }
        public CustomerRepository SignIn(PizzaStoreDBContext dbContext)
        {
            string customerName;
            string pass;
            
            
            while(true)
            {
                do
                {
                    Console.WriteLine("Please enter your username:");
                    customerName = Console.ReadLine();
                    if (customerName.Length == 0)
                    {
                        Console.WriteLine("Username cannot be empty.");
                    }
                } while (customerName.Length == 0);

                do
                {
                    Console.WriteLine("Please enter your password:");
                    pass = Console.ReadLine();
                    if (pass.Length == 0)
                    {
                        Console.WriteLine("Password cannot be empty.");
                    }
                } while (pass.Length == 0);
                
                
                try
                {
                    if(dbContext.Customer.First(u => u.UserName == customerName && u.Password == pass) != null)
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Either your username or password is incorrect. Please try again.");
                }

            }

            Customer customerInfo = dbContext.Customer.First(u => u.UserName == customerName && u.Password == pass);
            CustomerRepository customerObj = DBContextToObj(customerInfo);
            return customerObj;
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
