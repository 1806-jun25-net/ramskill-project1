using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Inventory
    {
        public int LocationId { get; set; }
        public int ToppingId { get; set; }
        public int? Quantity { get; set; }

        public Location Location { get; set; }
    }
}
