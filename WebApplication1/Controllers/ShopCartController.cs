using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using WebApplication1.Data.Repository;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers {
    public class ShopCartController : Controller {
        private readonly IAllCars CarRepository;
        private readonly ShopCart ShopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart) {
            CarRepository = carRepository;
            ShopCart = shopCart;
        }
        public ViewResult Index() {
            var items = ShopCart.getShopItems();
            ShopCart.ListShopItems = items;
            var obj = new ShopCartVewModel {
                ShopCart = ShopCart
            };
            return View(obj);
        }

        public RedirectToActionResult addToCart(int id) {
            var item = CarRepository.Cars.FirstOrDefault(o=> o.Id == id);
            if(item!= null) {
                ShopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

    }
}
