using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository {
    public class CarRepository : IAllCars {
        private readonly AppDBContent AppDBContent;
        public CarRepository(AppDBContent appDBContent) {
            AppDBContent = appDBContent;
        }

        public IEnumerable<Car> Cars => AppDBContent.Car.Include(o => o.Category);

        IEnumerable<Car> IAllCars.GetFavCars => AppDBContent.Car.Where(p => p.IsFavorite).Include(o => o.Category);

        public Car getObjectCar(int carId) => AppDBContent.Car.FirstOrDefault(o=> o.Id == carId);
    }
}
