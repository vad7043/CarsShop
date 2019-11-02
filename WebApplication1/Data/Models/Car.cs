using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Models {
    /// <summary>
    /// Модель автомобиля
    /// </summary>
    public class Car {
        /// <summary>
        /// Id авто
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название авто
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание авто
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// Краткое описание авто
        /// </summary>
        public string ShortDesc { get; set; }
        /// <summary>
        /// Длинное описание авто
        /// </summary>
        public string LongDesc { get; set; }
        /// <summary>
        /// Картинка авто
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// Разгон с 0 до 100 в сек.
        /// </summary>
        public double SpeedTo100 { get; set; }
        /// <summary>
        /// Цена авто
        /// </summary>
        public ushort Price { get; set; }
        /// <summary>
        /// Лучший товар (true, false)
        /// </summary>
        public bool IsFavorite { get; set; }
        /// <summary>
        /// Есть ли товар на складе
        /// </summary>
        public bool Avaliable { get; set; }
        /// <summary>
        /// Id категории, в которой находится авто
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Объект категории
        /// </summary>
        public virtual Category Category { get; set; }
    }
}
