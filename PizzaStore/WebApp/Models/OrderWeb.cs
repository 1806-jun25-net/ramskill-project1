using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaStore.Library.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OrderWeb
    {
        [Display(Name = "Order ID")]
        public int Id { get; set; }

        [Display(Name = "Date")]
        public DateTime Dt { get; set; }

        [Display(Name = "Location")]
        public int LocationId { get; set; }

        [Display(Name = "Number of Pizzas")]
        [Range(1,12)]
        public int PizzaCount { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Pizza")]
        public int[] PizzaId { get; set; }

        [Display(Name = "Size")]
        public string[] PizzaSize { get; set; }

        public int Pizza1Id { get; set; }
        public int Pizza2Id { get; set; }
        public int Pizza3Id { get; set; }
        public int Pizza4Id { get; set; }
        public int Pizza5Id { get; set; }
        public int Pizza6Id { get; set; }
        public int Pizza7Id { get; set; }
        public int Pizza8Id { get; set; }
        public int Pizza9Id { get; set; }
        public int Pizza10Id { get; set; }
        public int Pizza11Id { get; set; }
        public int Pizza12Id { get; set; }








        public OrderWeb()
        {
        }

        public OrderWeb(int locationId, int customerId)
        {
            LocationId = locationId;
            CustomerId = customerId;
        }

        public List<SelectListItem> LocationEnumerable = new List<SelectListItem>
        {
            new SelectListItem {Value = "1", Text = "Reston"},
            new SelectListItem {Value = "2", Text = "Ashburn"},
            new SelectListItem {Value = "3", Text = "Sterling"}
        };

        public List<SelectListItem> PizzaEnumerable = new List<SelectListItem>
        {
            new SelectListItem {Value = "1", Text = "Cheese"},
            new SelectListItem {Value = "2", Text = "Pepperoni"},
            new SelectListItem {Value = "3", Text = "Meat Lovers"},
            new SelectListItem {Value = "4", Text = "Veggie"},
            new SelectListItem {Value = "5", Text = "Hawaiian"},
            new SelectListItem {Value = "6", Text = "Golden Sun"}
        };

        public List<SelectListItem> SizeEnumerable = new List<SelectListItem>
        {
            new SelectListItem {Value = "SM", Text = "Small"},
            new SelectListItem {Value = "MD", Text = "Medium"},
            new SelectListItem {Value = "LG", Text = "Large"}
        };

        [Display(Name = "Sort By:")]
        public List<SelectListItem> SortEnumerable = new List<SelectListItem>
        {
            new SelectListItem {Value = "PriceHigh", Text = "Most Expensive"},
            new SelectListItem {Value = "PriceLow", Text = "Least Expensive"},
            new SelectListItem {Value = "Newest", Text = "Newest"},
            new SelectListItem {Value = "Oldest", Text = "Oldest"}
        };

        [Display(Name = "Sort By:")]
        public string sortSelect { get; set; }

        public int[] CheeseInv = { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] PepperoniInv = { 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
        public int[] MeatLoversInv = { 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0 };
        public int[] VeggieInv = { 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0 };
        public int[] HawaiianInv = { 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0 };
        public int[] GoldenSunInv = { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

    }
}
