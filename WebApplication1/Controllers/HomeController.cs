using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
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
    }
}
