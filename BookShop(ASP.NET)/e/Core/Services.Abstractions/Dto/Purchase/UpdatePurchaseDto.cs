using Services.Abstractions.Dto.Order;
using Services.Abstractions.Dto.StoreBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Dto.Purchase
{
    public class UpdatePurchaseDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public StoreBookDto Book { get; set; }
        public int CountBooks { get; set; }
        public double Price { get; set; }
    }
}
