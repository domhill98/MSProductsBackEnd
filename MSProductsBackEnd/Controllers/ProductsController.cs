using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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



        //public async Task<Product> Products(Guid id) 
        //{
        //    var product = await _context.Products.Include(r => r.Brand).Include(r => r.Category).FirstOrDefaultAsync(r => r.Id == id);                  
        //    return product;
        //}

        //public IEnumerable<Product> Products(Guid category, Guid brand, string text) 
        //{
        //    IEnumerable<Product> prods = _context.Products.Include(r => r.Category).Include(r => r.Brand);

        //    if(category != null) 
        //    {
        //        prods = prods.Where(x => x.CategoryId == category);
        //    }
        //    if(brand != null) 
        //    {
        //        prods = prods.Where(x => x.BrandId == brand);
        //    }
        //    if(text != null) 
        //    {
        //        prods = prods.Where(x => x.Name.Contains(text, StringComparison.OrdinalIgnoreCase) || x.Description.Contains(text, StringComparison.OrdinalIgnoreCase));
        //    }

        //    return prods;
        //}

        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var test = _context.Products;

            var test2 = test.ToList();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>>  Get(Guid id)
        {
            var test = _context.Products;

            var product =  _context.Products.Find(id);
            
            if(product == null) 
            {
                return NotFound();
            }
                   
            return product;
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
