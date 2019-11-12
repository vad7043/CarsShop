using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers {
    public class HomeController : Controller {
        private readonly IAllCars CarRepository;

        public HomeController (IAllCars carRepository) {
            CarRepository = carRepository;
        }
        public ViewResult Index() {
            var homeCars = new HomeViewModel {
                FavCars = CarRepository.GetFavCars
            };
            return View(homeCars);
        }
        [HttpPost]
        public ViewResult Index(string from, string to) {
            
            IEnumerable<Car> cars = null;
            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to)) {
                cars = CarRepository.Cars.Where(o => o.Price >= Convert.ToInt32(from, CultureInfo.CurrentCulture) && o.Price <= Convert.ToInt32(to, CultureInfo.CurrentCulture));
                var filterCars = new HomeViewModel {
                    FavCars = cars
                };
                return View(filterCars);
            }
            else {
                var homeCars = new HomeViewModel {
                    FavCars = CarRepository.GetFavCars
                };
                return View(homeCars);
            }
        }
    }
}
