using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Web.Models.Users
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Обов'язково ввести!")]
        [MinLength(10, ErrorMessage = "Мінімальна довжина - 10!")]
        [MaxLength(40, ErrorMessage = "Максимальна довжина - 40!")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Некоректна адреса електронної пошти!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Обов'язково ввести!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [MinLength(6, ErrorMessage = "Мінімальна довжина - 6!")]
        [MaxLength(20, ErrorMessage = "Максимальна довжина - 20!")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Тільки великі та малі латинські літери, цифри!")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [MinLength(6, ErrorMessage = "Мінімальна довжина - 6!")]
        [MaxLength(20, ErrorMessage = "Максимальна довжина - 20!")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Тільки великі та малі латинські літери, цифри!")]
        public string OldPassword { get; set; }
    }
}
