using Services.Abstractions.Dto.StoreBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Web.Models
{
    public class IndexViewModel
    {
        public IEnumerable<StoreBookDto> Books { get; set; }
        public string SrchWrd { get; internal set; }

        //public PageViewModel<T> PageViewModel { get; set; }
    }
}
