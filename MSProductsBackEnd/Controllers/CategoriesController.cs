using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSProductsBackEnd.Data;

namespace MSProductsBackEnd.API.Controllers
{

    [Route("api/Categories")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly MSProductsDB _context;

        public CategoriesController(MSProductsDB context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories = _context.Categories.AsEnumerable();
       
            return Ok(categories);
        }




    }
}