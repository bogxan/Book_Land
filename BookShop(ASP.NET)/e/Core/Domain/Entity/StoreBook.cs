using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class StoreBook : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Authors { get; set; }
        public int CountPages { get; set; }
        public string PublishOffice { get; set; }
        public int PublishYear { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }
    }
}
