using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSProductsBackEnd.Data
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid ReviewerId { get; set; }

        [MaxLength(100)]
        public string ReviewerName { get; set; }

        public int Rating { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public bool Show { get; set; }


    }
}
