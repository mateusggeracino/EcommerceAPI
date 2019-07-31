using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    [Table("Products.Prices", Schema = "Products")]
    public class Price : Entity
    {
        public int PriceStoreId { get; set; }
        public int PriceProductId { get; set; }
        public bool Promotion { get; set; }
        public double RegularPrice { get; set; }
        public double PromotionalPrice { get; set; }
        public int? PriceGroup { get; set; }
    }
}
