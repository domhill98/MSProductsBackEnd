using System;
using System.Collections.Generic;
using System.Text;

namespace MSProductsBackEnd.Data
{
    public class ResellHistory
    {
        public Guid Id { get; set; }

        public Guid productId { get; set; }

        public Guid userId { get; set; }

        public decimal oldPrice { get; set; }

        public decimal newPrice { get; set; }

        public DateTime created { get; set; }


    }
}
