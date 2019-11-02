using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Mocks {
    public class MockCars : IAllCars {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars {
            get {
                return new List<Car> {
                    new Car {
                        Name = "Tesla Model S",
                        ShortDesc = "Быстрый автомобиль",
                        LongDesc="Красивый и быстрый и тихий автомобиль",
                        SpeedTo100 = 2.7,
                        Img="https://static-assets.tesla.com/configurator/compositor?&options=$WTAS,$PPSW,$MTS03&view=STUD_3QTR_V2&model=ms&size=1441&bkba_opt=1&version=v0027d201910301056&version=v0027d201910301056",
                        Price = 50000,
                        IsFavorite = true,
                        Avaliable = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        Name = "Tesla Model 3",
                        ShortDesc = "Бюджетный автомобиль",
                        LongDesc="Самый бюджетный автомобиль Tesla",
                        SpeedTo100 = 3.4,
                        Img="https://static-assets.tesla.com/configurator/compositor?&options=$W38B,$PPSW,$DV2W,$MT308,$IN3B2&view=STUD_3QTR&model=m3&size=1441&bkba_opt=1&version=v0027d201910301056&version=v0027d201910301056",
                        Price = 35000,
                        IsFavorite = true,
                        Avaliable = true,
                        Category = _categoryCars.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car getObjectCar(int carId) {
            throw new NotImplementedException();
        }
    }
}
