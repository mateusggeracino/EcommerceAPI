using Ecommerce.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository
{
    public class ShoppingKartsRepository : Repository<ShoppingKarts>
    {
        public ShoppingKartsRepository(IConfiguration config) : base(config)
        {
        }
    }
}
