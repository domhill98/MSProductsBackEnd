using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProductsBackEnd.Data
{
    public static class MSProductsDBInitialiser
    {
        public static async Task SeedTestData(MSProductsDB context, IServiceProvider services)
        {
            if (context.Products.Any())
            {
                //DB already seeded
                return;
            }

            var categories = new List<Category>
            {
                new Category{ Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Name = "Soap", Description = "To clean things."},
                new Category{ Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), Name = "Clothes", Description = "To dress yourself."},
                new Category{ Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaac"), Name = "Shoes", Description = "To support your feet."},
                new Category{ Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaad"), Name = "Accessories", Description = "To look fabulous."},
               
            };
            categories.ForEach(c => context.Categories.Add(c));

            var brands = new List<Brand>
            {
                new Brand {Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), Name = "Adodas"},
                new Brand {Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbc"), Name = "Noke"},
                new Brand {Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbd"), Name = "Feela"}
            };
            brands.ForEach(b => context.Brands.Add(b));

            //wait context.SaveChangesAsync();

            var products = new List<Product>
            {
                new Product { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Brand = brands[0], Category = categories[0], Name = "Bleach", Price = 0.0m, StockLevel = 0, Description = "" },
                new Product { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), Brand = brands[0], Category = categories[0], Name = "Mens", Price = 0.0m, StockLevel = 0, Description = "" },
                new Product { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaac"), Brand = brands[0], Category = categories[0], Name = "Womens", Price = 0.0m, StockLevel = 0, Description = "" },
                new Product { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaad"), Brand = brands[1], Category = categories[1], Name = "Childrens", Price = 0.0m, StockLevel = 0, Description = "" },
                new Product { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaba"), Brand = brands[2], Category = categories[1], Name = "Pets", Price = 0.0m, StockLevel = 0, Description = "" },
            
            };
            products.ForEach(p => context.Products.Add(p));

            await context.SaveChangesAsync();

        }


    }
}
