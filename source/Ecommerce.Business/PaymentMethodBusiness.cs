using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class PaymentMethodBusiness : IPaymentMethodBusiness
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        public PaymentMethodBusiness( IPaymentMethodRepository paymentMethodRepository )
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public bool DeleteMethod( PaymentMethod paymentMethod )
        {
            return _paymentMethodRepository.Remove( paymentMethod );
        }

        public bool InsertNewMethod( PaymentMethod paymentMethod )
        {
            var ret = _paymentMethodRepository.Insert( paymentMethod );

            return ret != null;
        }

        public List<PaymentMethod> ListAll( )
        {
            return _paymentMethodRepository.GetAll( );
        }

        public bool UpdateMethod( PaymentMethod paymentMethod )
        {
            var ret = _paymentMethodRepository.Update( paymentMethod );

            return ret != null;
        }

        public PaymentMethod FindById( int paymentMethodId )
        {
            return _paymentMethodRepository.GetById( paymentMethodId );
        }
    }
}
