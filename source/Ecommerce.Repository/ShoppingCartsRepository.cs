using Ecommerce.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository
{
    public class ShoppingKartsRepository : Repository<ShoppingCarts>
    {
        public ShoppingKartsRepository(IConfiguration config, ILogger<Repository<ShoppingCarts>> logger) : base(config, logger)
        {
        }
    }
}
