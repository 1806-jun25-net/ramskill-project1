using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Interfaces
{
    public interface IPizza
    {
        string crust { get; set; }
        List<string> toppings { get; set; }
    }
}
