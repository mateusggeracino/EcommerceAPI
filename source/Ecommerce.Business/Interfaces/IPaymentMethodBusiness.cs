using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interfaces
{
    public interface IPaymentMethodBusiness
    {
        List<PaymentMethod> ListAll( );
        PaymentMethod FindById( int paymentMethodId );
        bool InsertNewMethod( PaymentMethod paymentMethod );
        bool UpdateMethod( PaymentMethod paymentMethod  );
        bool DeleteMethod( PaymentMethod paymentMethod );
    }
}
