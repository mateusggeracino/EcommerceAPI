using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    [Table( "Transactions.PaymentMethods", Schema = "Transactions" )]
    public class PaymentMethod : Entity
    {
        [Column( "PMType" )]
        public string Type { get; set; }
        [Column( "PMSupplierId" )]
        public int SupplierId { get; set; }
    }
}
