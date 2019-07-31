using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Models
{
    [Table("Products.Products", Schema = "Products")]
    public class Product : Entity
    {
        public string ProductType { get; set; }
        public string ProductDescription { get; set; }
        public string Brand { get; set; }
        public string ProductSpecs { get; set; }
        public bool ProductStatus { get; set; }
    }
}