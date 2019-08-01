using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IPaymentServices
    {
        void InsertPayment(int orderId, int payMTId);

        bool FinalyPaymant(int orderId);
    }
}
