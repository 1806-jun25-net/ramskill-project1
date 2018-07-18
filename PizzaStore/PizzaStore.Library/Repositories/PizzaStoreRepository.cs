using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Repositories
{
    public class PizzaStoreRepository
    {
        private readonly PizzaStoreDBContext _db;

        public PizzaStoreRepository(PizzaStoreDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
    }
}
