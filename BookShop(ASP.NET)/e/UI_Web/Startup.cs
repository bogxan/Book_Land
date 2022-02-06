using Domain.Entity;
using Domain.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Persistence.Repository;
using Services;
using Services.Abstractions.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_Web.Services;

namespace UI_Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyUserDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection1")));
            services.AddDbContext<BooksOrdersPurchasesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection1")));
            services.AddIdentity<MyUser, IdentityRole>(optns =>
            {
                optns.Password.RequireDigit = false;
                optns.Password.RequireLowercase = false;
                optns.Password.RequireNonAlphanumeric = false;
                optns.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<MyUserDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ISessionService, SessionService>();
            services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
