using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IPriceServices
    {
        Price Insert(Price price);

        List<Price> ExecuteQuery(int storeid, int productid);

        Price Update(Price price);
    }
}
