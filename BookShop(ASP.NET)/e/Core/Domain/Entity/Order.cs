using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Order: BaseEntity<Guid>
    {
        public double Price { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Adress { get; set; }
        public int CountBooks { get; set; }
        public bool IsCompleted { get; set; }
        public Guid MyUserId { get; set; }
        public MyUser MyUser { get; set; }
        public List<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
