using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Models;

namespace WebApplication1.Data {
    public class DbObjects {
        public static void Initial(AppDBContent content) {
            
            if (!content.Category.Any()) {
                content.Category.AddRange(Categories.Select(o => o.Value));
            }
            if (!content.Car.Any()) {
                content.AddRange(
                     new Car {
                         Name = "Tesla Model S",
                         ShortDesc = "Быстрый автомобиль",
                         LongDesc = "Красивый и быстрый и тихий автомобиль",
                         SpeedTo100 = 2.7,
                         Img = "/img/tesla model s.png",
                         Price = 50000,
                         IsFavorite = true,
                         Avaliable = true,
                         Category = Categories["Электромобили"]
                     },
                    new Car {
                        Name = "Tesla Model 3",
                        ShortDesc = "Бюджетный автомобиль",
                        LongDesc = "Самый бюджетный автомобиль Tesla",
                        SpeedTo100 = 3.4,
                        Img = "img/tesla model 3.png",
                        Price = 35000,
                        IsFavorite = true,
                        Avaliable = true,
                        Category = Categories["Электромобили"]
                    }
                    );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> CategoryDict;
        public static Dictionary<string, Category> Categories {
            get {
                if (CategoryDict == null) {
                    var list = new Category[] {
                         new Category {CategoryName = "Электромобили", Desc =  "Современный вид транспорта"},
                         new Category {CategoryName = "Классические автомобили", Desc = "Машины с двигателем внутреннего сгорания"}
                    };
                    CategoryDict = new Dictionary<string, Category>();
                    foreach(var elem in list) {
                        CategoryDict.Add(elem.CategoryName, elem);
                    }
                }
                return CategoryDict;
            }
        }
    }
}
