using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Interfaces {
    /// <summary>
    /// Интерфейс для получения авто
    /// </summary>
    public interface IAllCars {
        /// <summary>
        /// Получение списка всех машин
        /// </summary>
        IEnumerable<Car> Cars { get;  }
        ///Получение списка избранных машин
        IEnumerable<Car> GetFavCars { get; }
        /// <summary>
        /// Получение авто по Id
        /// </summary>
        /// <param name="carId">id автомобиля</param>
        /// <returns></returns>
        Car getObjectCar(int carId);
    }
}
