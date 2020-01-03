using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSProductsBackEnd.Data
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockLevel { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
