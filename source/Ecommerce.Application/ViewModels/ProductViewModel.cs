﻿namespace Ecommerce.Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductType { get; set; }
        public string ProductDescription { get; set; }
        public string Brand { get; set; }
        public string ProductSpecs { get; set; }
        public bool ProductStatus { get; set; }
    }
}