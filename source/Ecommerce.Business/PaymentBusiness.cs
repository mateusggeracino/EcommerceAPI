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

        public Payment Insert(int orderId, int paymentId)
        {
            return _paymentRepository.Insert(new Payment
            {
                PayPMId = paymentId,
                OrderId = orderId,
                PayStatus = 1
            }); 
        }

        //public IRestResponse Api()
        //{

        //    IRestResponse iRestResponse = _authorizar.Send("CreditCardTransaction",new CreditCardTransaction());
            
        //}
    }
}
