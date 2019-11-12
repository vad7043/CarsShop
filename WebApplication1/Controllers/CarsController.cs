using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers {
    public class CarsController : Controller{
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCategory) {
            _allCars = iAllCars;
            _allCategories = iCarsCategory;
        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category) {
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category)) {
                cars = _allCars.Cars.OrderBy(o => o.Id);
            }
            else if(string.Equals("electro",category,System.StringComparison.OrdinalIgnoreCase)) {
                cars = _allCars.Cars.Where(o => o.CategoryId.Equals(1)).OrderBy(o=> o.Id);
                currCategory = "Электромобили";
            }else if(string.Equals("fuel",category,System.StringComparison.OrdinalIgnoreCase)) {
                cars = _allCars.Cars.Where(o => o.CategoryId.Equals(2)).OrderBy(o=> o.Id);
                currCategory = "Автомобили с ДВС";
            }

            var carObj = new CarsListViewModel {
                AllCars = cars,
                CurrCategory = currCategory
            };


            ViewBag.Title = "Страница с автомобилями";
            return View(carObj);
        }

    }
}
