using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSProductsBackEnd.Data;

namespace MSProductsBackEnd.API.Controllers
{
    [Route("api/Reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly MSProductsDB _context;

        public ReviewsController(MSProductsDB context)
        {
            _context = context;
        }




        [HttpGet("{prodID}")]
        public ActionResult<IEnumerable<Review>> GetReviews(Guid prodID)
        {
            var reviews = _context.Reviews.Where(x => x.ProductId == prodID && x.Show == true).AsEnumerable();

            return Ok(reviews);
        }


        [HttpPost("Create")]
        public async Task<ActionResult> CreateReview([FromBody] Review dto)
        {
            try
            {
                await _context.Reviews.AddAsync(dto);
                await _context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception)
            {
                //dto.Id = Guid.NewGuid();
                //var tryAgain = CreateReview(dto);
                
                //if (tryAgain.Result.Result.ToString() == "Success")
                //{
                //    return Ok("Success");
                //}

                return BadRequest();
            }
        }

        [HttpGet("Hide/{reviewID}")]
        public async Task<ActionResult> HideReview(Guid reviewID) 
        {
            var review = await _context.Reviews.FindAsync(reviewID);
            
            if(review == null) 
            {
                return NotFound();
            }

            try
            {
                review.Show = false;
                _context.Reviews.Update(review);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception) 
            {
                return BadRequest();
            }

        }







        

    }
}