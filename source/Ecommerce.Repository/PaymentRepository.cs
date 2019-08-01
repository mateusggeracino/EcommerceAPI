using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository
{
    public class PaymentRepository : Repository<Payments>, IPaymentRepository
    {
        public PaymentRepository(IConfiguration config, ILogger<Repository<Payments>> logger) : base(config, logger)
        {
        }
    }
}
