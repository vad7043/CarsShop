using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Models {
    /// <summary>
    /// Класс корзины на сайте
    /// </summary>
    public class ShopCart {
        private readonly AppDBContent AppDBContent;
        public ShopCart(AppDBContent appDBContent) {
            AppDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider service) {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        public void AddToCart(Car car) {
            AppDBContent.ShopCartItem.Add(new ShopCartItem {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });
            AppDBContent.SaveChanges();
        }
        public List<ShopCartItem> getShopItems() {
            return AppDBContent.ShopCartItem.Where(o => o.ShopCartId == ShopCartId).Include(p => p.Car).ToList();
        }
    }
}
