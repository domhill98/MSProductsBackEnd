using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSProductsBackEnd.Data;

namespace MSProductsBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly MSProductsDB _context;

        [HttpGet("{prodID}")]
        public ActionResult<IEnumerable<Review>> GetReviews(Guid prodID)
        {
            var reviews = "";

            return Ok(reviews);
        }
    }
}