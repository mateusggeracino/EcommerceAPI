using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly IPaymentRepository _paymentRepository;


        public PaymentBusiness(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Payment Insert(int orderId, int paymentId)
        {
            return _paymentRepository.Insert(new Payment
            {
                PayPMId = paymentId,
                OrderId = orderId,
                PayStatus = 1
            }); 
        }

        void IPaymentBusiness.Insert(int orderId, int PayMTId)
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {

        }
    }
}
