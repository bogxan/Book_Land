using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    internal sealed class OrdersRepository : BaseRepository<Guid, Order>
    {
        public OrdersRepository(BooksOrdersPurchasesDbContext context) : base(context)
        {

        }

        public override Task<Order> AddBookToOrder(Order entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<Order> Create(Order entity)
        {
            await db.Order.AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public override async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await db.Order.ToListAsync();
        }

        public override Task<IEnumerable<Order>> GetAllAsync(Func<Order, bool> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override async Task<Order> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await db.Order.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public override async Task Remove(Guid id)
        {
            var entity = await GetAsync(id);
            db.Entry(entity).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public override Task<IEnumerable<Order>> Search(string srch)
        {
            throw new NotImplementedException();
        }

        public override async Task Update(Order entity)
        {
            var updateOrder = await GetAsync(entity.Id);
            updateOrder.Adress = entity.Adress;
            updateOrder.City = entity.City;
            updateOrder.CreatedAt = entity.CreatedAt;
            updateOrder.PostalCode = entity.PostalCode;
            updateOrder.CountBooks = entity.CountBooks;
            updateOrder.Price = entity.Price;
            updateOrder.Purchases = entity.Purchases;
            updateOrder.MyUserId = entity.MyUserId;
            updateOrder.IsCompleted = entity.IsCompleted;
            db.Entry(updateOrder).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
