using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class OrderHistory
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int LocationId { get; set; }
        public int PizzaCount { get; set; }
        public int Pizza1Id { get; set; }
        public int? Pizza2Id { get; set; }
        public int? Pizza3Id { get; set; }
        public int? Pizza4Id { get; set; }
        public int? Pizza5Id { get; set; }
        public int? Pizza6Id { get; set; }
        public int? Pizza7Id { get; set; }
        public int? Pizza8Id { get; set; }
        public int? Pizza9Id { get; set; }
        public int? Pizza10Id { get; set; }
        public int? Pizza11Id { get; set; }
        public int? Pizza12Id { get; set; }
        public int CustomerId { get; set; }

        public Location Location { get; set; }
        public Pizza Pizza1 { get; set; }
        public Pizza Pizza10 { get; set; }
        public Pizza Pizza11 { get; set; }
        public Pizza Pizza12 { get; set; }
        public Pizza Pizza2 { get; set; }
        public Pizza Pizza3 { get; set; }
        public Pizza Pizza4 { get; set; }
        public Pizza Pizza5 { get; set; }
        public Pizza Pizza6 { get; set; }
        public Pizza Pizza7 { get; set; }
        public Pizza Pizza8 { get; set; }
        public Pizza Pizza9 { get; set; }
        public Customer CustomerID { get; set; }
    }
}
