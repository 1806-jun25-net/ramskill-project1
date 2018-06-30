using PizzaStore.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Models
{
    public class Order : IOrder
    {
        public string orderLocation { get; set; }
        public User orderUser { get; set; }
        public DateTime orderTime { get; set; }
        public int pizzaCount { get; set; }
        public double orderTotal { get; set; }
        //??? orderReciept { get; set; }
        //??? orderCart { get; set; }
        public int[] orderInvCount { get; set; }




        public void CreateOrder()
        {
            throw new NotImplementedException();
        }



    }
}
