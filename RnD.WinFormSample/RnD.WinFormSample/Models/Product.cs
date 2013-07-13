﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RnD.WinFormSample.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductQty { get; set; }
        public int CategoryId { get; set; }
    }
}
