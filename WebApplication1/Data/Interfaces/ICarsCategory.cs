using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Interfaces {
    /// <summary>
    /// Интерфейс для получения категорий авто
    /// </summary>
    public interface ICarsCategory {
        /// <summary>
        /// Получение всех категорий авто
        /// </summary>
        IEnumerable<Category> AllCategories { get; }
    }
}
