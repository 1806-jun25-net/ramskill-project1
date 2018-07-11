using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Pizza
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
