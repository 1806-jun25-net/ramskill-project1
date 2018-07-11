using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Customer
    {
        public Customer()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public Customer(string firstName, string lastName, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? FavoriteLocationId { get; set; }
        public int Admin { get; set; }

        public Location FavoriteLocation { get; set; }
        public ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
