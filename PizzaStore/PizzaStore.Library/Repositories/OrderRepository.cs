using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Repositories
{
    public class OrderRepository
    {
        public static Data.OrderHistory ObjToDBContext(Models.Order order) => new Data.OrderHistory
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

        public static Models.Order DBContextToObject(Data.OrderHistory order) => new Models.Order
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
    }
}
