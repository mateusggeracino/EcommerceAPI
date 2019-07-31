using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interfaces
{
    public interface IPaymentBusiness
    {
        void Insert(int orderId, int PayMTId);
    }
}
