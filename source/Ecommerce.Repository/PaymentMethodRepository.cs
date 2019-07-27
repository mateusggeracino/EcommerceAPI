using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository
{
    public class PaymentMethodRepository : Repository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository( IConfiguration config, ILogger<Repository<PaymentMethod>> logger ) : base( config, logger )
        {
        }
    }
}
