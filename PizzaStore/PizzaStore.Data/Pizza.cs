using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderHistoryPizza1 = new HashSet<OrderHistory>();
            OrderHistoryPizza10 = new HashSet<OrderHistory>();
            OrderHistoryPizza11 = new HashSet<OrderHistory>();
            OrderHistoryPizza12 = new HashSet<OrderHistory>();
            OrderHistoryPizza2 = new HashSet<OrderHistory>();
            OrderHistoryPizza3 = new HashSet<OrderHistory>();
            OrderHistoryPizza4 = new HashSet<OrderHistory>();
            OrderHistoryPizza5 = new HashSet<OrderHistory>();
            OrderHistoryPizza6 = new HashSet<OrderHistory>();
            OrderHistoryPizza7 = new HashSet<OrderHistory>();
            OrderHistoryPizza8 = new HashSet<OrderHistory>();
            OrderHistoryPizza9 = new HashSet<OrderHistory>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Size { get; set; }
        public decimal Cost { get; set; }
        public int? Topping1Id { get; set; }
        public int? Topping2Id { get; set; }
        public int? Topping3Id { get; set; }
        public int? Topping4Id { get; set; }
        public int? Topping5Id { get; set; }
        public int? Topping6Id { get; set; }
        public int? Topping7Id { get; set; }
        public int? Topping8Id { get; set; }
        public int? Topping9Id { get; set; }
        public int? Topping10Id { get; set; }

        public OrderHistory Order { get; set; }
        public Topping Topping1 { get; set; }
        public Topping Topping10 { get; set; }
        public Topping Topping2 { get; set; }
        public Topping Topping3 { get; set; }
        public Topping Topping4 { get; set; }
        public Topping Topping5 { get; set; }
        public Topping Topping6 { get; set; }
        public Topping Topping7 { get; set; }
        public Topping Topping8 { get; set; }
        public Topping Topping9 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza1 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza10 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza11 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza12 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza2 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza3 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza4 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza5 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza6 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza7 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza8 { get; set; }
        public ICollection<OrderHistory> OrderHistoryPizza9 { get; set; }
    }
}
