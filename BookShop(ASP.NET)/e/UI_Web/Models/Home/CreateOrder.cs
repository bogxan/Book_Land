using Domain.Entity;
using Services.Abstractions.Dto.Purchase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Web.Models.Home
{
    public class CreateOrder
    {
        public string Price { get; set; }
        [Required(ErrorMessage = "Обов'язково ввести!")]
        [MinLength(3, ErrorMessage = "Мінімальна довжина - 3!")]
        [MaxLength(50, ErrorMessage = "Максимальна довжина - 50!")]
        [RegularExpression(@"^[а-щА-ЩЬьЧчЮюЯяЇїІіЄєҐґ -]+$", ErrorMessage = "Тільки українські літери та спеціальні символи( -)!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Обов'язково ввести!")]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Тільки цифри!")]
        [Range(10000, 99999, ErrorMessage = "Максимальна довжина - 5 символів")]
        public int PostalCode { get; set; }
        [Required(ErrorMessage = "Обов'язково ввести!")]
        [MinLength(3, ErrorMessage = "Мінімальна довжина - 3!")]
        [MaxLength(50, ErrorMessage = "Максимальна довжина - 50!")]
        [RegularExpression(@"^[0-9а-щА-ЩЬьЮюЧчЯяЇїІіЄєҐґ -/.,]+$", ErrorMessage = "Тільки українські літери, цифри та спеціальні символи( -,./)")]
        public string Adress { get; set; }
        public int CountBooks { get; set; }
        public string CreatedAt { get; set; } = DateTime.Now.ToString();
        public Guid MyUserId { get; set; }
        public MyUser MyUser { get; set; }
        public List<PurchaseDto> Purchases { get; set; } = new List<PurchaseDto>();
    }
}
