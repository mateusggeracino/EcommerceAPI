using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Interfaces
{
    public interface IPriceRepository : IRepository<Price>
    {
        List<Price> GetPriceByProductId(int storeid, int productid);
    }
}
