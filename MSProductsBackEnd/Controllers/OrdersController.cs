using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSProductsBackEnd.Data;

namespace MSProductsBackEnd.API.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MSProductsDB _context;

        public OrdersController(MSProductsDB context)
        {
            _context = context;
        }



        [HttpGet("History/{prodID}")]
        public ActionResult<IEnumerable<OrderHistory>> GetOrderHistory(Guid prodID)
        {
            var orders = _context.OrderHistory.Where(x => x.productId == prodID).AsEnumerable();

            return Ok(orders);
        }
    }
}