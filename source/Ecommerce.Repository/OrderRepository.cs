using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository
{
    public class OrderRepository : Repository<Order> , IOrderRepository
    {
        public OrderRepository(IConfiguration config, ILogger<Repository<Order>> logger) : base(config, logger)
        {
        }
    }
}
