using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Mapper
    {
        public static Customer Map(CustomerWeb customer) => new Customer
        {
            Id = customer.id,
            FirstName = customer.firstName,
            LastName = customer.lastName,
            UserName = customer.userName,
            Password = customer.password,
            FavoriteLocationId = customer.favoriteLocationId
        };
        public static CustomerWeb Map(Customer customer) => new CustomerWeb
        {
            id = customer.Id,
            firstName = customer.FirstName,
            lastName = customer.LastName,
            userName = customer.UserName,
            password = customer.Password,
            favoriteLocationId = customer.FavoriteLocationId.GetValueOrDefault(),
        };

        public static PizzaStore.Data.OrderHistory Map(Models.OrderWeb order) => new PizzaStore.Data.OrderHistory
        {
            Id = order.Id,
            Dt = order.Dt,
            LocationId = order.LocationId,
            PizzaCount = order.PizzaCount,
            Pizza1Id = order.Pizza1Id,
            Pizza2Id = order.Pizza2Id,
            Pizza3Id = order.Pizza3Id,
            Pizza4Id = order.Pizza4Id,
            Pizza5Id = order.Pizza5Id,
            Pizza6Id = order.Pizza6Id,
            Pizza7Id = order.Pizza7Id,
            Pizza8Id = order.Pizza8Id,
            Pizza9Id = order.Pizza9Id,
            Pizza10Id = order.Pizza10Id,
            Pizza11Id = order.Pizza11Id,
            Pizza12Id = order.Pizza12Id,
            CustomerId = order.CustomerId,
            Total = order.Total
        };

        public static OrderWeb Map(PizzaStore.Data.OrderHistory order) => new Models.OrderWeb
        {
            Id = order.Id,
            Dt = order.Dt,
            LocationId = order.LocationId,
            PizzaCount = order.PizzaCount,
            Pizza1Id = order.Pizza1Id,
            Pizza2Id = order.Pizza2Id.GetValueOrDefault(),
            Pizza3Id = order.Pizza3Id.GetValueOrDefault(),
            Pizza4Id = order.Pizza4Id.GetValueOrDefault(),
            Pizza5Id = order.Pizza5Id.GetValueOrDefault(),
            Pizza6Id = order.Pizza6Id.GetValueOrDefault(),
            Pizza7Id = order.Pizza7Id.GetValueOrDefault(),
            Pizza8Id = order.Pizza8Id.GetValueOrDefault(),
            Pizza9Id = order.Pizza9Id.GetValueOrDefault(),
            Pizza10Id = order.Pizza10Id.GetValueOrDefault(),
            Pizza11Id = order.Pizza11Id.GetValueOrDefault(),
            Pizza12Id = order.Pizza12Id.GetValueOrDefault(),
            CustomerId = order.CustomerId,
            Total = order.Total
        };

        public static LocationWeb Map(Location location) => new LocationWeb
        {
            Id = location.Id,
            Name = location.Name
        };

        public static Location Map(LocationWeb location) => new Location
        {
            Id = location.Id,
            Name = location.Name
        };

        public static Pizza Map(PizzaWeb pizza) => new Pizza
        {
            Id = pizza.Id,
            Size = pizza.Size,
            Name = pizza.Name,
            Cost = pizza.Cost
        };

        public static PizzaWeb Map(Pizza pizza) => new PizzaWeb
        {
            Id = pizza.Id,
            Size = pizza.Size,
            Name = pizza.Name,
            Cost = pizza.Cost
        }; 
    }
}
