using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository {
    public class OrdersRepository : IAllOrders {
        private readonly AppDBContent AppDBContent;
        private readonly ShopCart ShopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart) {
            AppDBContent = appDBContent;
            ShopCart = shopCart;
        }
        public void createOrder(Order order) {
            try {
                if (order != null) {
                    order.OrderTime = DateTime.Now;
                    AppDBContent.Order.Add(order);

                    var items = ShopCart.ListShopItems; //получаем все товары

                    foreach (var elem in items) {
                        var orderDetail = new OrderDetail() {
                            CarId = elem.Car.Id,
                            OrderId = order.Id,
                            Price = elem.Car.Price
                        };
                        AppDBContent.OrderDetail.Add(orderDetail);
                    }
                    AppDBContent.SaveChanges();
                }
            }
            catch (Exception e) {
                Console.WriteLine("Ошибка: " + e);
            }
        }
    }
}
