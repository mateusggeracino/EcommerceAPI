using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interfaces
{
    public interface IPaymentBusiness
    {
        Payment Insert(int orderId, int PayMTId);
    }
}
