using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Integration.AuthorizarApi.Interface;
using Ecommerce.Integration.AuthorizarApi.Model;
using Ecommerce.Repository.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAuthorizar _authorizar;

        public PaymentBusiness(IPaymentRepository paymentRepository, IAuthorizar authorizar)
        {
            _paymentRepository = paymentRepository;
            _authorizar = authorizar;
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
