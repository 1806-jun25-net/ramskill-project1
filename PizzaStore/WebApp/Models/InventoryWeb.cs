using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class InventoryWeb
    {
        public int LocationId { get; set; }
        public int ToppingId { get; set; }
        public int? Quantity { get; set; }
        public string Name { get; set; }
    }
}
