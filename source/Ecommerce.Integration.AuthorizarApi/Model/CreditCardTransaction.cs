using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Integration.AuthorizarApi.Model
{
    public class CreditCardTransaction
    {
        public string Reference { get; set; }
        public Int64 AmountInCents { get; set; }
        public string Branch { get; set; }
        public string Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string HolderName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
