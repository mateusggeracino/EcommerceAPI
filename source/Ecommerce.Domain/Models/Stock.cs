using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace Ecommerce.Domain.Models
{
    [Table("Products.Stock", Schema = "Products")]
    public class Stock : Entity
    {
        public int StockStoreId { get; set; }
        public int StockProductId { get; set; }
        public decimal RealStock { get; set; }
        public decimal VirtualStock { get; set; }
    }
}