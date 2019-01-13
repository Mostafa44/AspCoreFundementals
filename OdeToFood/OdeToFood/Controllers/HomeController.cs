using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController:Controller
    {
        private IRestaurantData _restaurantDataService;

        public HomeController(IRestaurantData restaurantDataService)
        {
            _restaurantDataService = restaurantDataService;
        }
        public IActionResult Index()
        {
            //var restaurant = new Restaurant() { Id = 1, Name = "Scott's Pizza Place" };
            // return Content("Hello From Home Controller");
            // return new ObjectResult(restaurant);

            return View(_restaurantDataService.GetAll());
        }
    }
}
