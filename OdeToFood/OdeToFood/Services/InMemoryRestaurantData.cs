using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>();
            _restaurants.Add(new Restaurant() { Id = 1, Name = "Scott's Pizza Place" });
            _restaurants.Add(new Restaurant() { Id = 2, Name = "Mostafa's Grill House" });
            _restaurants.Add(new Restaurant() { Id = 3, Name = "Bill's Burger Joint" });
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}
