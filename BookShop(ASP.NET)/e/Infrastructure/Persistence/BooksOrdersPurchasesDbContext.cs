using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class BooksOrdersPurchasesDbContext: DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<StoreBook> StoreBook { get; set; }
        public DbSet<Purchase> Purchase { get; set; }

        public BooksOrdersPurchasesDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MyUser>().HasData(new MyUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin@gmail.com",
                Password = "Admin123",
                FirstName = "Адмін",
                LastName = "Адмін",
                PhoneNumber = "+380673938899"
            });
            base.OnModelCreating(builder);
        }
    }
}
