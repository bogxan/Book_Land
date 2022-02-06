using Services.Abstractions.Dto.StoreBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Web.Models.Admin
{
    public class HomeIndexBookViewModel
    {
        public List<StoreBookDto> Books { get; set; }
        public string SrchWrd { get; set; }
    }
}
