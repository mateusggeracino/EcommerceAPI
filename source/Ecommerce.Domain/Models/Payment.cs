using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Payment : Entity
    {
        public int OrderId { get; set; }
        public int PayPMId { get; set; }
        public int PayStatus { get; set; }
        public int PayTransactionId { get; set; }
    }
}
