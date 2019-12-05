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
                new Category { Id = Guid.NewGuid(), Name = "", Description = "" },
                new Category { Id = Guid.NewGuid(), Name = "", Description = "" },
                new Category { Id = Guid.NewGuid(), Name = "", Description = "" },
                new Category { Id = Guid.NewGuid(), Name = "", Description = "" },
            };
            categories.ForEach(c => context.Category.Add(c));

            var brands = new List<Brand>
            {

            };
            brands.ForEach(c => context.Brands.Add(c));

            await context.SaveChangesAsync();

            var products = new List<Product>
            {

            };
            products.ForEach(c => context.Products.Add(c));
            await context.SaveChangesAsync();

        }


    }
}
