using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ecommerce.Business.Interfaces
{
    public interface IPaymentAuthorizeBusiness
    {
        bool FinalyPaymant(int order);
    }
}
