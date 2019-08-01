using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IPaymentBusiness _paymentCartsBusiness;
        private readonly IPaymentAuthorizeBusiness _paymentAuthorizeBusiness;

        public PaymentServices(IPaymentBusiness paymentCartsBusiness, IPaymentAuthorizeBusiness paymentAuthorizeBusiness)
        {
            _paymentCartsBusiness = paymentCartsBusiness;
            _paymentAuthorizeBusiness = paymentAuthorizeBusiness;
        }

        public void InsertPayment(Payment payment)
        {
            _paymentCartsBusiness.Insert(payment);
        }

        public bool FinalyPaymant(int orderId)
        {
            return _paymentAuthorizeBusiness.FinalyPaymant(orderId);
        }
    }
}
