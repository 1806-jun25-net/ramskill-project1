using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApp.Models;

namespace PizzaStore.Library.Repositories
{
    public class OrderRepository
    {
        private PizzaStoreDBContext _db;

        public OrderRepository(PizzaStoreDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<string> GetLocationNames()
        {
            var names = _db.Location.AsEnumerable().Select(r => r.Name).ToList();
            return names;

        }

        public LocationWeb GetLocationByName(string name)
        {
            return Mapper.Map(_db.Location.AsNoTracking().First(r => r.Name == name));
        }

        public IEnumerable<string> GetPizzaNames()
        {
            var names = _db.Pizza.AsEnumerable().Select(r => r.Name).ToList();
            return names;
        }

        public PizzaWeb GetPizza(int id, string size)
        {
            return Mapper.Map(_db.Pizza.AsNoTracking().First(r => r.Id == id && r.Size == size));
        }

        public void AddOrder(OrderWeb order)
        {
            _db.Add(Mapper.Map(order));
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
