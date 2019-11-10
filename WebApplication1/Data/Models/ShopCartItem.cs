using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Models {
    /// <summary>
    /// Класс товара в корзине
    /// </summary>
    public class ShopCartItem {
        /// <summary>
        /// Id товара
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Товар
        /// </summary>
        public Car Car { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Id корзины
        /// </summary>
        public string ShopCartId { get; set; }
    }
}
