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
                new Category { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), Name = "Cat1", Description = "Cat1" },
                new Category { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), Name = "Cat2", Description = "Cat2" },
                new Category { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"), Name = "Cat3", Description = "Cat3" },
                new Category { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), Name = "Cat4", Description = "Cat4" },
            };
            categories.ForEach(c => context.Category.Add(c));

            var brands = new List<Brand>
            {
                new Brand { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), Name = "Brand1" },
                new Brand { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), Name = "Brand2" },
                new Brand { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"), Name = "Brand3" }
            };
            brands.ForEach(c => context.Brands.Add(c));

            await context.SaveChangesAsync();

            var products = new List<Product>
            {
                new Product { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), Name = "Prod1", Brand = brands[0], Category = categories[0], Description = "Prod1", Price = 1.0, StockLevel = 10},
                new Product { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), Name = "Prod2", Brand = brands[0], Category = categories[1], Description = "Prod2", Price = 2.0, StockLevel = 5},
                new Product { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"), Name = "Prod3", Brand = brands[1], Category = categories[2], Description = "Prod3", Price = 3.0, StockLevel = 3},
                new Product { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), Name = "Prod4", Brand = brands[0], Category = categories[3], Description = "Prod4", Price = 4.0, StockLevel = 1}
            };
            products.ForEach(c => context.Products.Add(c));
            await context.SaveChangesAsync();

        }


    }
}
