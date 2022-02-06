using Domain.Repository;
using Services.Abstractions.Service;
using Services.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStoreBooksService> _storeBooksService;
        private readonly Lazy<IOrdersService> _ordersService;
        private readonly Lazy<IPurchasesService> _purchasesService;

        public IStoreBooksService StoreBooksService => _storeBooksService.Value;
        public IOrdersService OrdersService => _ordersService.Value;
        public IPurchasesService PurchasesService => _purchasesService.Value;

        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _storeBooksService = new Lazy<IStoreBooksService>(() => new StoreBooksService(unitOfWork));
            _ordersService = new Lazy<IOrdersService>(() => new OrdersService(unitOfWork));
            _purchasesService = new Lazy<IPurchasesService>(() => new PurchasesService(unitOfWork));
        }
    }
}
