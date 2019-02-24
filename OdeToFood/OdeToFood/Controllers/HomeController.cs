using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{

    public class HomeController:Controller
    {
        private IRestaurantData _restaurantDataService;
        private IGreeting _greetingService;

        public HomeController(IRestaurantData restaurantDataService, IGreeting greetingService)
        {
            _restaurantDataService = restaurantDataService;
            _greetingService = greetingService;
        }
        public IActionResult Index()
        {
            //var restaurant = new Restaurant() { Id = 1, Name = "Scott's Pizza Place" };
            // return Content("Hello From Home Controller");
            // return new ObjectResult(restaurant);
            var model = new HomeIndexViewModel();
            model.CurrentMessage = _greetingService.GetMessageOfTheDay();
            model.Restaurants = _restaurantDataService.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantDataService.Get(id);
            return View(model);
        }
    }
}
