using Services.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions.Service
{
    public interface IServiceManager
    {
        public IOrdersService OrdersService { get; }
        public IStoreBooksService StoreBooksService { get; }
        public IPurchasesService PurchasesService { get; }
    }
}
