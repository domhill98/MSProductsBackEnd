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

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>>  GetProduct(Guid id)
        {
            var product = await _context.Products.Include(p => p.Brand).Include(p => p.Category).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("Filtered")]
        public ActionResult<IEnumerable<Product>> GetFilteredProducts([FromBody]FilterAPI filter) 
        {
            var prods = _context.Products.Include(r => r.Category).Include(r => r.Brand).AsEnumerable();

            if (prods == null)
            {
                return Ok(prods);
            }

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
    
        [HttpGet("Price/{prodID}")]
        public async Task<ActionResult<double>> GetResellPrice(Guid prodID) 
        {
            var product = await _context.Products.FindAsync(prodID);

            if(product == null) 
            {
                return NotFound();
            }

            return Ok(product.Price);           
        }

        [HttpPost("Price/{prodID}")]
        public async Task<ActionResult> SetResellPrice(Guid prodID, [FromBody] decimal price) 
        {
            var product = await _context.Products.FindAsync(prodID);

            if(product == null) 
            {
                return NotFound();
            }

            try 
            {
                
                ResellHistory newModel = new ResellHistory()
                {
                    Id = new Guid(),
                    productId = prodID,
                    oldPrice = product.Price,
                    newPrice = price,
                    created = DateTime.Now

                };

                product.Price = price;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                _context.ResellHistory.Add(newModel);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e) 
            {
                return BadRequest(e);
            }         
        }


        [HttpGet("Resell/{prodID}")]
        public ActionResult<IEnumerable<ResellHistory>> GetResellHistory(Guid prodID)
        {
            var resell = _context.ResellHistory.Where(x => x.productId == prodID).AsEnumerable();

            if (resell == null)
            {
                return NotFound();
            }

            return Ok(resell);
        }


        [HttpPost("Resell")]
        public async Task<ActionResult> UpdateResellHistory([FromBody] ResellHistory dto) 
        {
            if(dto.productId == null) 
            {
                return BadRequest();
            }

            try 
            {
                dto.created = DateTime.Now;
                dto.Id = Guid.NewGuid();
                _context.ResellHistory.Add(dto);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception e) 
            {
                return BadRequest(e);
            }
        }









    }
}
