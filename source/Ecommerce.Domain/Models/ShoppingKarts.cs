using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    [Table("Transactions.shopping_karts")]
    public class ShoppingKarts : Entity
    {
        [Column("kart_customer_id")]
        public int CustomerId { get; set; }
        [Column("kart_store_id")]
        public int StoreId { get; set; }
        [Column("kart_product_id")]
        public int ProductId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("kart_creation")]
        public DateTime Creation { get; set; }
        [Column("kart_expiring")]
        public DateTime Expiring { get; set; }
        [Column("kart_status")]
        public DateTime Status { get; set; }
    }
}
