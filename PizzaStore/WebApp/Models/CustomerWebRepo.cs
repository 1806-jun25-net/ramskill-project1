using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CustomerWebRepo
    {
        private PizzaStoreDBContext _db;

        public CustomerWebRepo(PizzaStoreDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddCustomer(CustomerWeb customer)
        {
            _db.Add(Mapper.Map(customer));
        }

        public CustomerWeb Login(CustomerWeb customer)
        {
            return Mapper.Map(_db.Customer.First(u => u.UserName == customer.userName && u.Password == customer.password));
        }

        public CustomerWeb GetCustomerById(int id)
        {
            // disable pointless tracking for performance
            return Mapper.Map(_db.Customer.AsNoTracking().First(r => r.Id == id));
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
