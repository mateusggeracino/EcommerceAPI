using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodBusiness _paymentMethodBusiness;
        public PaymentMethodService( IPaymentMethodBusiness paymentMethodBusiness )
        {
            _paymentMethodBusiness = paymentMethodBusiness;
        }

        public bool Add( PaymentMethod paymentMethod )
        {
            return _paymentMethodBusiness.InsertNewMethod( paymentMethod );
        }

        public bool Delete( int paymentMethodId )
        {
            var paymentMethod = _paymentMethodBusiness.FindById( paymentMethodId );

            return _paymentMethodBusiness.DeleteMethod( paymentMethod );
        }

        public List<PaymentMethod> GetAll( )
        {
            return _paymentMethodBusiness.ListAll( );
        }

        public PaymentMethod GetById( int paymentMethodId )
        {
            return _paymentMethodBusiness.FindById( paymentMethodId );
        }

        public bool Update( PaymentMethod paymentMethod )
        {
            return _paymentMethodBusiness.UpdateMethod( paymentMethod );
        }
    }
}
