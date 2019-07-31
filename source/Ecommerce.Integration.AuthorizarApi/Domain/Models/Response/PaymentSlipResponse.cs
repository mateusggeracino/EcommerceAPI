using System;

namespace Ecommerce.Integration.AuthorizarApi.Domain.Models.Response
{
    public class PaymentSlipResponse
    {
        public PaymentSlipTransaction PaymentSlipTransaction { get; set; }
        public Guid RequestKey { get; set; }
        public DateTime CreateDate { get; set; }
        public long InternalTimeMs { get; set; }
    }

    public class PaymentSlipTransaction
    {
        public string Reference { get; set; }
        public Guid AffiliationKey { get; set; }
        public long AmountInCents { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime AuthorizedAt { get; set; }
        public PaymentSlip PaymentSlip { get; set; }
        public int Id { get; set; }
        public Guid Key { get; set; }
    }

    public class PaymentSlip
    {
        public DateTime DueDate { get; set; }
        public string BarCode { get; set; }
        public int Status { get; set; }
        public int Id { get; set; }
        public Guid Key { get; set; }
    }
}