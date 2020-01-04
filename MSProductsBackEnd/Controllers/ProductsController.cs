using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSProductsBackEnd.API.Models;
using MSProductsBackEnd.Data;

namespace MSProductsBackEnd.API.Controllers
{
    //TO DO:
    //Deploy to asure portal
    //Set connection string to the asure portal as an environment variable
    //Set up deployment into a pipeline
    //Set up JUnit testing

    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly MSProductsDB _context;

        public ProductsController(MSProductsDB context) 
        {
            _context = context;
        }

       
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _context.Products.Include(p => p.Brand).Include(p => p.Category).AsEnumerable();
         
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>>  GetProduct(Guid id)
        {
            var product = await _context.Products.Include(p => p.Brand).Include(p => p.Category).Where(x => x.Id == id).FirstOrDefaultAsync();
            
            if(product == null) 
            {
                return NotFound();
            }
                   
            return Ok(product);
        }


        [HttpGet("Filtered")]
        public ActionResult<IEnumerable<Product>> GetFilteredProducts([FromBody]FilterAPI filter) 
        {
            var prods = _context.Products.Include(r => r.Category).Include(r => r.Brand).AsEnumerable();

            if (filter.categoryId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                prods = prods.Where(x => x.CategoryId == filter.categoryId);
            }
            if (filter.brandId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                prods = prods.Where(x => x.BrandId == filter.brandId);
            }
            if (filter.text != null)
            {
                prods = prods.Where(x => x.Name.Contains(filter.text, StringComparison.OrdinalIgnoreCase) || x.Description.Contains(filter.text, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(prods);
        }






        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
