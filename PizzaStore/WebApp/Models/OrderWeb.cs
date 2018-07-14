using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OrderWeb
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        public DateTime Dt { get; set; }

        [Display(Name = "Location")]
        public int LocationId { get; set; }

        [Display(Name = "Number of Pizzas")]
        public int PizzaCount { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

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
       

       public OrderWeb()
        {

        }

        public OrderWeb(int locationId, int customerId)
        {
            LocationId = locationId;
            CustomerId = customerId;
        }
    }
}
