using Ecommerce.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository
{
    public class ShoppingKartsRepository : Repository<ShoppingKarts>
    {
        public ShoppingKartsRepository(IConfiguration config, ILogger<Repository<ShoppingKarts>> logger) : base(config, logger)
        {
        }
    }
}
