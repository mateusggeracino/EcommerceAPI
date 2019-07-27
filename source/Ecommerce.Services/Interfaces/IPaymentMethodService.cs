using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IPaymentMethodService
    {
        List<PaymentMethod> GetAll( );
        PaymentMethod GetById( int paymentMethodId );
        bool Add( PaymentMethod paymentMethod );
        bool Update( PaymentMethod paymentMethod );
        bool Delete( int paymentMethodId );
    }
}
