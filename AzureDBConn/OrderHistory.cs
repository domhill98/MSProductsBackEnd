using System;
using System.Collections.Generic;
using System.Text;

namespace MSProductsBackEnd.Data
{
    public class OrderHistory
    {

        public Guid Id { get; set; }

        public Guid userId { get; set; }

        public Guid productId { get; set; }


    }
}
