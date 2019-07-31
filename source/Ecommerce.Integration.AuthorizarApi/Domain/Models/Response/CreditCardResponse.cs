using System;

namespace Ecommerce.Integration.AuthorizarApi.Domain.Models.Response
{
    public class CreditCardResponse
    {
        public CreditCardTransation CreditCardTransaction { get; set; }
        public Guid RequestKey { get; set; }
        public string CreateDate { get; set; }
        public string InternalTimeMs { get; set; }
    }

    public class CreditCardTransation
    {
        public string AffiliationKey { get; set; }
        public string Reference { get; set; }
        public int AmountInCents { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime AuthorizeAt { get; set; }
        public CreditCard CreditCard { get; set; }
        public int Id { get; set; }
        public Guid Key { get; set; }
    }

    public class CreditCard
    {
        public string Branch { get; set; }
        public string Number { get; set; }
        public string ExpirationDate { get; set; }
        public string SecutiryCode { get; set; }
        public string HolderName { get; set; }
        public int Status { get; set; }
        public int Id { get; set; }
        public Guid Key { get; set; }
    }
}