using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ASPproject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ASPproject
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration) => _configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("ASPprojectProducts")));

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMemoryCache();
            services.AddSession();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseStatusCodePages();
            app.UseSession();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: null,
                        pattern: "{category}/Page{productPage:int}",
                        defaults: new { controller = "Product", action = "List" });
                    endpoints.MapControllerRoute(
                        name: null, 
                        pattern: "Page{productPage:int}", 
                        defaults: new { Controller = "Product", action = "List", productPage = 1 });  
                    endpoints.MapControllerRoute(
                        name: null, 
                        pattern: "{category}",
                        defaults: new { Controller = "Product", action = "List", productPage = 1 });
                    endpoints.MapControllerRoute(
                        name: null,
                        pattern: "",
                        defaults: new { Controller = "Product", action = "List", productPage = 1 });
                    endpoints.MapControllerRoute(name: null, pattern: "{controller}/{action}/{id?}");
                });

            SeedData.EnsurePopulated(app);
        }
    }
}
