﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSProductsBackEnd.Data
{
    public class Brand
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}
