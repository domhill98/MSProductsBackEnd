using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProductsBackEnd.API.Models
{
    public class FilterAPI
    {
        public Guid categoryId { get; set; }
        public Guid brandId { get; set; }
        public string text { get; set; }
    }
}
