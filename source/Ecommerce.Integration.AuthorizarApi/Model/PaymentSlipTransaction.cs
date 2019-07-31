using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Integration.AuthorizarApi.Model
{
    public class PaymentSlipTransaction
    {
        public string Reference { get; set; }
        public Int64 AmountInCents { get; set; }
        public string RequestKey { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
