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
    internal abstract class BaseRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        protected BooksOrdersPurchasesDbContext db;
        DbSet<TValue> Table => db.Set<TValue>();

        public BaseRepository(BooksOrdersPurchasesDbContext context)
        {
            db = context;
        }

        public abstract Task<TValue> Create(TValue entity);
        public abstract Task<TValue> AddBookToOrder(TValue entity);
        public abstract Task<TValue> GetAsync(TKey id, CancellationToken cancellationToken = default);
        public abstract Task<IEnumerable<TValue>> GetAllAsync(CancellationToken cancellationToken = default);
        public abstract Task<IEnumerable<TValue>> Search(string srch);
        public abstract Task<IEnumerable<TValue>> GetAllAsync(Func<TValue, bool> predicate, CancellationToken cancellationToken = default);
        public abstract Task Remove(TKey id);
        public abstract Task Update(TValue entity);
    }
}
