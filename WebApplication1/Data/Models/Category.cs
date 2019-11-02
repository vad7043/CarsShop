using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Models {
    public class Category {
        /// <summary>
        /// Id категории
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название категории
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Описание категории
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// Список автомобилей в данной категории
        /// </summary>
        public List<Car> cars { get; set; }
    }
}
