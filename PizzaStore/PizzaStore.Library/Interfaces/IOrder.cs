using PizzaStore.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Interfaces
{
    public interface IOrder
    {
        string orderLocation { get; set; }
        string orderUser { get; set; }
    }
}
