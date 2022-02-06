using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Web.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Обов'язково ввести!")]
        [MinLength(10, ErrorMessage = "Мінімальна довжина - 10!")]
        [MaxLength(40, ErrorMessage = "Максимальна довжина - 40!")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Некоректна адреса електронної пошти!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [Display(Name = "Год рождения")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [MinLength(6, ErrorMessage = "Мінімальна довжина - 6!")]
        [MaxLength(20, ErrorMessage = "Максимальна довжина - 20!")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Тільки великі та малі латинські літери, цифри!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [Display(Name = "Ім'я")]
        [MinLength(2, ErrorMessage = "Мінімальна довжина - 2!")]
        [MaxLength(15, ErrorMessage = "Максимальна довжина - 15!")]
        [RegularExpression(@"^[а-щА-ЩЬьЮюЯяЇїІіЄєҐґ -]+$", ErrorMessage = "Тільки українські літери та спеціальні символи( -)!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [Display(Name = "Прізвище")]
        [MinLength(2, ErrorMessage = "Мінімальна довжина - 2!")]
        [MaxLength(15, ErrorMessage = "Максимальна довжина - 15!")]
        [RegularExpression(@"^[а-щА-ЩЬьЮюЯяЇїІіЄєҐґ -]+$", ErrorMessage = "Тільки українські літери та спеціальні символи( -)!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [MinLength(2, ErrorMessage = "Мінімальна довжина - 13!")]
        [MaxLength(15, ErrorMessage = "Максимальна довжина - 13!")]
        [RegularExpression(@"^\+38\d{3}\d{3}\d{4}$", ErrorMessage = "Тільки такий формат номеру телефону: +380XXXXXXXXX")]
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [Compare("Password", ErrorMessage = "Пароли не співпадають")]
        [DataType(DataType.Password)]
        [Display(Name = "Підтвердити пароль")]
        [MinLength(6, ErrorMessage = "Мінімальна довжина - 6!")]
        [MaxLength(20, ErrorMessage = "Максимальна довжина - 20!")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Тільки великі та малі латинські літери, цифри!")]
        public string PasswordConfirm { get; set; }
    }
}
