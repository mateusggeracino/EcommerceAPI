using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace Ecommerce.Domain.Models
{
    [Table("Stock",Schema = "Products")]
    public class Stock : Entity
    {
        [Column("StockStoreId")]
        public int StoreId { get; set; }
        [Column("StockProductId")]
        public int ProductId { get; set; }
        public int RealStock { get; set; }
        public int VirtualStock { get; set; }
    }
}