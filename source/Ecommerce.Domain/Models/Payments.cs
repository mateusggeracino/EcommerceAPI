using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    [Table("Transactions.Payments", Schema = "Payments")]
    public class Payments : Entity
    {
        public int OrderId { get; set; }
        public int PayPMId { get; set; }
        public int PayStatus { get; set; }
    }
}
