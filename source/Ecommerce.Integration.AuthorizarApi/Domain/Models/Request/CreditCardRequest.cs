using System;

namespace Ecommerce.Integration.AuthorizarApi.Domain.Models.Request
{
    public class CreditCardRequest
    {
        public string Reference { get; set; }
        public long AmountInCents { get; set; }
        public string Branch { get; set; }
        public string Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string HolderName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
