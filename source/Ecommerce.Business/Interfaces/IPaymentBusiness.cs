using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interfaces
{
    public interface IPaymentBusiness
    {
        Payments Insert(int orderId, int payMTId);
    }
}
