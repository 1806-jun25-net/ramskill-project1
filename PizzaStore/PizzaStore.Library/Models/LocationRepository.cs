using PizzaStore.Data;
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

        public Location GetLocation(int favLocID)
        {
            Location locationName = _db.Location.First(u => u.Id == favLocID );
            return locationName;
        }

        public static void DisplayLocations()
        {
            using (var _db = new PizzaStoreDBContext())
            {
                foreach (var item in _db.Location)
                {
                    int iterator = 1;
                    Console.WriteLine($"{iterator++}. {item.Name}");
                }
            }
        }
    }
}
