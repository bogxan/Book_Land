using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        BooksOrdersPurchasesDbContext db;
        readonly Lazy<IRepository<Guid, Order>> _orderRepository;
        readonly Lazy<IRepository<Guid, StoreBook>> _storeBookRepository;
        readonly Lazy<IRepository<Guid, Purchase>> _purchaseRepository;
        public IRepository<Guid, Order> OrdersRepository => _orderRepository.Value;
        public IRepository<Guid, StoreBook> StoreBooksRepository => _storeBookRepository.Value;
        public IRepository<Guid, Purchase> PurchasesRepository => _purchaseRepository.Value;

        public UnitOfWork(BooksOrdersPurchasesDbContext context)
        {
            db = context;
            _orderRepository = new Lazy<IRepository<Guid, Order>>(() => new OrdersRepository(context));
            _storeBookRepository = new Lazy<IRepository<Guid, StoreBook>>(() => new StoreBooksRepository(context));
            _purchaseRepository = new Lazy<IRepository<Guid, Purchase>>(() => new PurchasesRepository(context));
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return db.SaveChangesAsync();
        }
    }
}
