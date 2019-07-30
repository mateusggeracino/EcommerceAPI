using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    [Table("Products.Price",Schema="Prices")]
    public class Price : Entity
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public bool Promotion { get; set; }
        public double RegularPrice { get; set; }
        public double PromotionalPrice { get; set; }
        public int PriceGroup { get; set; }
    }
}
