using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASPproject.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if(!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "kapielowki", Description = "eleganckie i szykowne", Category = "sporty wodne", Price = 123 },
                    new Product { Name = "kajak", Description = "w sam raz na splywy", Category = "sporty wodne", Price = 234 },
                    new Product { Name = "korki", Description = "w zasadzie samograjki", Category = "pilka nozna", Price = 444 },
                    new Product { Name = "konopia", Description = "sadzic palic zalegalizowac", Category = "ogrodnictwo", Price = 23 },
                    new Product { Name = "rekawice", Description = "do lapania pilki", Category = "pilka nozna", Price = 754 },
                    new Product { Name = "lopata", Description = "do kopania w ziemii", Category = "ogrodnictwo", Price = 345 },
                    new Product { Name = "kula do rzucania", Description = "kula do rzucania, a niby do czego", Category = "lekkoatletyka", Price = 345 });
                context.SaveChanges();
            }
        }
    }
}
