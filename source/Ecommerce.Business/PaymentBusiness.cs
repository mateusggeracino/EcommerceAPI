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

        public Payments Insert(int orderId, int payMTId)
        {
            return _paymentRepository.Insert(new Payments
            {
                PayPMId = payMTId,
                OrderId = orderId,
                PayStatus = 1
            }); 
        }
    }
}
