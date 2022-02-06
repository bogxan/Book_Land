using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    internal sealed class StoreBooksRepository : BaseRepository<Guid, StoreBook>
    {
        public StoreBooksRepository(BooksOrdersPurchasesDbContext context) : base(context)
        {

        }

        public override Task<StoreBook> AddBookToOrder(StoreBook entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<StoreBook> Create(StoreBook entity)
        {
            await db.StoreBook.AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public override async Task<IEnumerable<StoreBook>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await db.StoreBook.ToListAsync();
        }

        public override async Task<IEnumerable<StoreBook>> GetAllAsync(Func<StoreBook, bool> predicate, CancellationToken cancellationToken = default)
        {
            return (await db.StoreBook.ToListAsync()).Where(predicate).ToList();
        }

        public override async Task<StoreBook> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await db.StoreBook.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public override async Task Remove(Guid id)
        {
            var entity = await GetAsync(id);
            db.Entry(entity).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public override async Task Update(StoreBook entity)
        {
            var updateBook = await GetAsync(entity.Id);
            updateBook.Count = entity.Count;
            updateBook.Cost = entity.Cost;
            updateBook.CreatedAt = entity.CreatedAt;
            updateBook.Authors = entity.Authors;
            updateBook.CountPages = entity.CountPages;
            updateBook.CreatedAt = entity.CreatedAt;
            updateBook.Genre = entity.Genre;
            updateBook.Name = entity.Name;
            updateBook.PublishOffice = entity.PublishOffice;
            updateBook.PublishYear = entity.PublishYear;
            db.Entry(updateBook).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public override async Task<IEnumerable<StoreBook>> Search(string srch)
        {
            List<StoreBook> result = new List<StoreBook>();
            if(srch != null)
            {
                result = (await GetAllAsync()).Where(a => a.Authors.ToLower().Contains(srch.ToLower()) || a.Genre.ToLower().Contains(srch.ToLower()) || a.Name.ToLower().Contains(srch.ToLower()) || a.PublishOffice.ToLower().Contains(srch.ToLower())).ToList();
            }
            else
            {
                result = (await GetAllAsync()).ToList();
            }
            return result;
        }
    }
}
