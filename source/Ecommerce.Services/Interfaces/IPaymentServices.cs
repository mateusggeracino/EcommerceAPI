﻿using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IPaymentServices
    {
        void InsertPayment(Payment payment);

        bool FinalyPaymant(int orderId);
    }
}
