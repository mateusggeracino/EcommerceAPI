using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class vw_PaymentOrther : Entity
    {
        public string Value { get; set; }

        public string PaymentType { get; set; }
    }
}
