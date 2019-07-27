using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Models
{
    [Table("Products.Stock")]
    public class Stock : Entity
    {
        [Column("Stock_Store_Id")]
        public int StoreId { get; set; }
        [Column("Stock_Product_Id")]
        public int ProductId { get; set; }
        [Column("Real_Stock")]
        public int RealStock { get; set; }
        [Column("Virtual_Stock")]
        public int VirtualStock { get; set; }
    }
}