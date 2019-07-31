using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    [Table( "Transactions.PaymentMethods", Schema = "Transactions" )]
    public class PaymentMethod : Entity
    {
        [Column( "Type" )]
        public string Type { get; set; }
        [Column( "SupplierId" )]
        public int SupplierId { get; set; }
        [Column( "EndPointName" )]
        public string EndPointName { get; set; }
    }
}
