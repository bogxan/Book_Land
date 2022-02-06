using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUnitOfWork
    {
        public IRepository<Guid, Order> OrdersRepository { get; }
        public IRepository<Guid, StoreBook> StoreBooksRepository { get; }
        public IRepository<Guid, Purchase> PurchasesRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
