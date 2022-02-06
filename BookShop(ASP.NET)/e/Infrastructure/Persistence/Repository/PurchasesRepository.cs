using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    internal sealed class PurchasesRepository : BaseRepository<Guid, Purchase>
    {
        public PurchasesRepository(BooksOrdersPurchasesDbContext context) : base(context)
        {

        }

        public override Task<Purchase> AddBookToOrder(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<Purchase> Create(Purchase entity)
        {
            await db.Purchase.AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public override async Task<IEnumerable<Purchase>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await db.Purchase.ToListAsync();
        }

        public override Task<IEnumerable<Purchase>> GetAllAsync(Func<Purchase, bool> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override async Task<Purchase> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await db.Purchase.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public override async Task Remove(Guid id)
        {
            var entity = await GetAsync(id);
            db.Entry(entity).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public override Task<IEnumerable<Purchase>> Search(string srch)
        {
            throw new NotImplementedException();
        }

        public override async Task Update(Purchase entity)
        {
            var updatePurchase = await GetAsync(entity.Id);
            updatePurchase.Book = entity.Book;
            updatePurchase.BookId = entity.BookId;
            updatePurchase.CountBooks = entity.CountBooks;
            updatePurchase.CreatedAt = entity.CreatedAt;
            updatePurchase.Price = entity.Price;
            db.Entry(updatePurchase).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
