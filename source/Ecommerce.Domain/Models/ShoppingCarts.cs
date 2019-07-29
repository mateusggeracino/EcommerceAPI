using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    [Table("Transactions.ShoppingCarts", Schema = "Transactions")]
    public class ShoppingCarts : Entity
    {
        public int CartCustomerId { get; set; }
        public int CartStoreId { get; set; }
        public int CartProductId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CartCreation { get; set; }
        public DateTime CartExpiring { get; set; }
        public int CartStatus { get; set; }
    }
}
