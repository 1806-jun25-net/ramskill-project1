using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Topping
    {
        public Topping()
        {
            PizzaTopping1 = new HashSet<Pizza>();
            PizzaTopping10 = new HashSet<Pizza>();
            PizzaTopping2 = new HashSet<Pizza>();
            PizzaTopping3 = new HashSet<Pizza>();
            PizzaTopping4 = new HashSet<Pizza>();
            PizzaTopping5 = new HashSet<Pizza>();
            PizzaTopping6 = new HashSet<Pizza>();
            PizzaTopping7 = new HashSet<Pizza>();
            PizzaTopping8 = new HashSet<Pizza>();
            PizzaTopping9 = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? CostSm { get; set; }
        public decimal? CostMd { get; set; }
        public decimal? CostLg { get; set; }

        public ICollection<Pizza> PizzaTopping1 { get; set; }
        public ICollection<Pizza> PizzaTopping10 { get; set; }
        public ICollection<Pizza> PizzaTopping2 { get; set; }
        public ICollection<Pizza> PizzaTopping3 { get; set; }
        public ICollection<Pizza> PizzaTopping4 { get; set; }
        public ICollection<Pizza> PizzaTopping5 { get; set; }
        public ICollection<Pizza> PizzaTopping6 { get; set; }
        public ICollection<Pizza> PizzaTopping7 { get; set; }
        public ICollection<Pizza> PizzaTopping8 { get; set; }
        public ICollection<Pizza> PizzaTopping9 { get; set; }
    }
}
