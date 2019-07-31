using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Interfaces
{
    public interface IPaymentAuthorizeRepository
    {
        vw_PaymentOrder GetByPayment(int orther);

        void UpdateStock(int other);
    }
}
