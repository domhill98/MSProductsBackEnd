﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MSProductsBackEnd.Data
{
    public class Product
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public Guid BrandId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int StockLevel { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }
    }
}