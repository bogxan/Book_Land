using System;
using Services.Abstractions.Dto.Order;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Web.Models.Admin
{
    public class HomeIndexOrderViewModel
    {
        public List<OrderDto> Orders { get; set; }
    }
}
