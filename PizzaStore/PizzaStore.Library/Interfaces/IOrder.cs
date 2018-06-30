using PizzaStore.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Interfaces
{
    public interface IOrder
    {
        string orderLocation { get; set; }
        User orderUser { get; set; }
        DateTime orderTime { get; set; }
        int pizzaCount { get; set; }
        double orderTotal { get; set; }
        //??? orderReciept { get; set; }
        //??? orderCart { get; set; }
        int[] orderInvCount { get; set; }

        void CreateOrder();

    }
}
