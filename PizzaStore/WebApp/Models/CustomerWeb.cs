﻿using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CustomerWeb
    {
        public int id { get; set; }
        [Display(Name="First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Username")]
        public string userName { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Favorite Location")]
        public int favoriteLocationId { get; set; }
        public int admin { get; set; }

        public CustomerWeb()
        {
        }

        public CustomerWeb(string firstName, string lastName, string userName, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.password = password;
        }

        public CustomerWeb SignIn(PizzaStoreDBContext dbContext)
        {
            string userName;
            string password;


            while (true)
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
            CustomerWeb customerObj = Mapper.Map(customerInfo);
            return customerObj;
        }

    }
}