using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaStore.Library.Models;

namespace PizzaStore.Library.Repositories
{
    public static class PizzaRepository
    {
        public static Models.Pizza DBContextToObj(Data.Pizza pizza) => new Models.Pizza
        {
            id = pizza.Id,
            size = pizza.Size,
            name = pizza.Name,
            cost = pizza.Cost
        };
    }
}
