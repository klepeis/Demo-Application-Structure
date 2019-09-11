﻿using System;

namespace Product.Domain.ProductComponent.BusinessObjects.BusinessModels
{
    public class Product
    {
        public long Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}