using Ecommerce.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services
{
    public class PaymentServices
    {
        private readonly IPaymentBusiness _paymentCartsBusiness;

        public PaymentServices(IPaymentBusiness paymentCartsBusiness)
        {
            _paymentCartsBusiness = paymentCartsBusiness;
        }

        public void InsertPayment(int orderId, int payPMId)
        {
            _paymentCartsBusiness.Insert(orderId,payPMId);
        }
    }
}
