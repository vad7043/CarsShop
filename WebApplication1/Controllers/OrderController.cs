using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers {
    public class OrderController : Controller{
        private readonly IAllOrders AllOrders;
        private readonly ShopCart ShopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart) {
            AllOrders = allOrders;
            ShopCart = shopCart;
        }
        public IActionResult CheckOut() {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order) {
            ShopCart.ListShopItems = ShopCart.getShopItems();
            if(ShopCart.ListShopItems.Count == 0) {
                ModelState.AddModelError("","Нет ни одного товара в корзине!");
            }
            if (ModelState.IsValid) {
                AllOrders.createOrder(order);
                return RedirectToAction("Complete");
            }


            return View(order);
        }
        public IActionResult Complete() {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
