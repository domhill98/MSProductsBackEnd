﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSProductsBackEnd.Data;

namespace MSProductsBackEnd.API.Controllers
{
    [Route("api/Brands")]
    [ApiController]
    [Authorize]
    public class BrandsController : ControllerBase
    {
        private readonly MSProductsDB _context;

        public BrandsController(MSProductsDB context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Brand>> GetBrands()
        {
            var brands = _context.Brands.AsEnumerable();

            return Ok(brands);
        }
    }
}