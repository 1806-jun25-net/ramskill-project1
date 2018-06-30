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
    }
}
