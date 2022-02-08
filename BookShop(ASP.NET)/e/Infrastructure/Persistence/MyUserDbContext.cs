using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class MyUserDbContext : IdentityDbContext<MyUser>
    {
        public MyUserDbContext(DbContextOptions<MyUserDbContext> options)
            : base(options)
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
