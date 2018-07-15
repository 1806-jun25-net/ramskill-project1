﻿using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;

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

        public LocationWeb GetLocationById(int id)
        {
            return Mapper.Map(_db.Location.AsNoTracking().First(r => r.Id == id));
        }

        public IEnumerable<string> GetPizzaNames()
        {
            var names = _db.Pizza.AsEnumerable().Select(r => r.Name).ToList();
            return names;
        }

        public CustomerWeb GetCustomerById(int id)
        {
            // disable pointless tracking for performance
            return Mapper.Map(_db.Customer.AsNoTracking().First(r => r.Id == id));
        }

        public OrderWeb GetOrderByDateTime(DateTime dt)
        {
            var order = _db.OrderHistory;
            OrderWeb orderNow = null;

            foreach(var item in order)
            {
                orderNow = Mapper.Map(item);
            }

            return orderNow;
        }

        public PizzaWeb GetPizza(int id, string size)
        {
            return Mapper.Map(_db.Pizza.AsNoTracking().First(r => r.Id == id && r.Size == size));
        }

        public PizzaWeb GetPizzaById(int id)
        {
            return Mapper.Map(_db.Pizza.AsNoTracking().First(p => p.Id == id));
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
