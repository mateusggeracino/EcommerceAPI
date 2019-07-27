using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    [Table("Transactions.ShoppingCarts")]
    public class ShoppingCarts : Entity
    {
        [Column("CartCustomerId")]
        public int CustomerId { get; set; }
        [Column("CartStoreId")]
        public int StoreId { get; set; }
        [Column("CartProductId")]
        public int ProductId { get; set; }
        [Column("Quantity")]
        public int Quantity { get; set; }
        [Column("CartCreation")]
        public DateTime Creation { get; set; }
        [Column("CartExpiring")]
        public DateTime Expiring { get; set; }
        [Column("CartStatus")]
        public DateTime Status { get; set; }
    }
}
