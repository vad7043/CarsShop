using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Models {
    /// <summary>
    /// Класс заказа
    /// </summary>
    public class Order { 
        /// <summary>
        /// Id заказа
        /// </summary>
        [BindNever]
        public int Id { get; set; }
        /// <summary>
        /// Имя заказчика
        /// </summary>
        [Display(Name = "Имя")]
        [StringLength(20, ErrorMessage = "Длина имени не менее 2 символов", MinimumLength = 2)]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Name { get; set; }
        /// <summary>
        /// Фамилия заказчика
        /// </summary>
        [Display(Name = "Фамилия")]
        [StringLength(20, ErrorMessage = "Длина имени не менее 2 символов", MinimumLength = 2)]
        [Required(ErrorMessage = "Заполните поле!")]
        public string SurName { get; set; }
        /// <summary>
        /// Адрес заказчика
        /// </summary>
        [Display(Name = "Адрес")]
        [StringLength(100, ErrorMessage = "Длина имени не менее 10 символов", MinimumLength = 10)]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Adress { get; set; }
        /// <summary>
        /// Телефон заказчика
        /// </summary>
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, ErrorMessage = "Длина имени не менее 10 символов", MinimumLength = 10)]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Phone { get; set; }
        /// <summary>
        /// Email заказчика
        /// </summary>
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "Длина имени не менее 7 символов", MinimumLength = 7)]
        [Required(ErrorMessage = "Заполните поле!")]
        public string Email { get; set; }
        /// <summary>
        /// Время заказа
        /// </summary>
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        /// <summary>
        /// Приобретаемые товары
        /// </summary>
        public List<OrderDetail> OrderDetails { get;}
    }
}
