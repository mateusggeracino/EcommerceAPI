using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;

namespace Ecommerce.Business
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentBusiness(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Payment Insert(Payment payment)
        {
            return _paymentRepository.Insert(new Payment
            {
                PayPMId = payment.PayPMId,
                OrderId = payment.OrderId,
                PayStatus = 1
            }); 
        }
    }
}
