using PizzaStore.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Interfaces
{
    public interface ILocation
    {
        string storeNumber { get; set; }
        int[] inventory { get; set; }
    }
}
