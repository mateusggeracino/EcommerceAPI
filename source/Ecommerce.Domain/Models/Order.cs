using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    [Table("Transactions.Orders", Schema = "Transactions")]
    public class Order : Entity
    {
        public int OrderCartId { get; set; }
        public DateTime OrderCreation { get; set; }
        public DateTime OrderExpiring { get; set; }
        public int OrderStatus { get; set; }

        public Decimal OrderTotalValue { get; set; }

    }
}
