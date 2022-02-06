using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Dto.StoreBook
{
    public class UpdateStoreBookDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Обов'язково ввести!")]
        [MinLength(3, ErrorMessage = "Мінімальна довжина - 3!")]
        [MaxLength(50, ErrorMessage = "Максимальна довжина - 50!")]
        [RegularExpression(@"^[а-щА-ЩЬьЮюЯяЇїІіЄєҐґ -():+.,!]+$", ErrorMessage = "Тільки українські літери, цифри та спеціальні символи( -():+.,!)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [MinLength(3, ErrorMessage = "Мінімальна довжина - 3!")]
        [MaxLength(50, ErrorMessage = "Максимальна довжина - 50!")]
        [RegularExpression(@"^[а-щА-ЩЬьЮюЯяЇїІіЄєҐґ -]+$", ErrorMessage = "Тільки українські літери, цифри та спеціальні символи( -)")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [MinLength(3, ErrorMessage = "Мінімальна довжина - 3!")]
        [MaxLength(50, ErrorMessage = "Максимальна довжина - 50!")]
        [RegularExpression(@"^[а-щА-ЩЬьЮюЯяЇїІіЄєҐґ -,]+$", ErrorMessage = "Тільки українські літери, цифри та спеціальні символи( -,)")]
        public string Authors { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [Range(3, 10000, ErrorMessage = "Від 3 сторінок до 10000 сторінок")]
        public int CountPages { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [MinLength(3, ErrorMessage = "Мінімальна довжина - 3!")]
        [MaxLength(50, ErrorMessage = "Максимальна довжина - 50!")]
        [RegularExpression(@"^[а-щА-ЩЬьЮюЯяЇїІіЄєҐґ -():+.,!]+$", ErrorMessage = "Тільки українські літери, цифри та спеціальні символи( -():+.,!)")]
        public string PublishOffice { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [Range(1500, 2022, ErrorMessage = "Від 1500 року по 2022 рік")]
        public int PublishYear { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [Range(1, 100, ErrorMessage = "Від 1 до 100")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Обов'язково ввести!")]
        [Range(1, 10000, ErrorMessage = "Від 1 у.е. до 10000 у.е.")]
        public double Cost { get; set; }
    }
}
