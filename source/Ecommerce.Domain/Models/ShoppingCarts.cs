using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    [Table("Transactions.ShoppingCarts", Schema = "Transactions")]
    public class ShoppingCarts : Entity
    {
        [Column("CartCustomerId")]
        public int CartCustomerId { get; set; }
        [Column("CartStoreId")]
        public int CartStoreId { get; set; }
        [Column("CartProductId")]
        public int CartProductId { get; set; }
        [Column("Quantity")]
        public decimal Quantity { get; set; }
        [Column("CartCreation")]
        public DateTime CartCreation { get; set; }
        [Column("CartExpiring")]
        public DateTime CartExpiring { get; set; }
        [Column("CartStatus")]
        public int CartStatus { get; set; }
    }
}
