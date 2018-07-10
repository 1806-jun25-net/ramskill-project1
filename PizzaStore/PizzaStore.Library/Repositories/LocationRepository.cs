﻿using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStore.Library.Models
{
    public class LocationRepository
    {
        private PizzaStoreDBContext _db;

        public LocationRepository(PizzaStoreDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Data.Location GetLocation(int favLocID)
        {
            Data.Location locationName = _db.Location.First(u => u.Id == favLocID );
            return locationName;
        }
    }
}
