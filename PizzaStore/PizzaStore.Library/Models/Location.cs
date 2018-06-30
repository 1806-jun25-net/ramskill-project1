using PizzaStore.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Models
{
    public class Location : ILocation
    {
        public string storeNumber { get; set; }
        public int[] inventory { get; set; }

        public List<Order> storeOrderHistory { get; set; }
    }
}
