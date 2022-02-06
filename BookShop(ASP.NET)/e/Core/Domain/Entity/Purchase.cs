using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
     public class Purchase: BaseEntity<Guid>
    {
        public int CountBooks { get; set; }
        public double Price { get; set; }
        public Guid BookId { get; set; }
        public StoreBook Book { get; set; }
    }
}
