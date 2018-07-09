using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Data;

namespace PizzaStore.Library.Models
{
    public class CustomerRepository
    {
        private PizzaStoreDBContext _db;

        public CustomerRepository(string firstName, string lastName, string ID)
        {
        }

        public CustomerRepository(PizzaStoreDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public Customer NewUser()
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
                    _db.Customer.Add(customer);
                    _db.SaveChanges();
                    break;
                }
                catch
                {
                    Console.WriteLine("Error communicating with database. Please try again later.");
                    System.Console.ReadLine();
                }
            }

            Customer customerInfo = _db.Customer.First(u => u.UserName == userName && u.Password == password);
            return customerInfo;
        }
        public Customer SignIn()
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
                    var customer = _db.Customer.First(u => u.UserName == userName && u.Password == password).ToString();
                    break;
                }
                catch
                {
                    Console.WriteLine("Either your username or password is incorrect. Please try again.");
                }

            }

            Customer customerInfo = _db.Customer.First(u => u.UserName == userName && u.Password == password);
            return customerInfo;
        }
        


    }//end class
}
