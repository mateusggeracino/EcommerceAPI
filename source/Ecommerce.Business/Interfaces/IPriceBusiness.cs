using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interfaces
{
    public interface IPriceBusiness
    {
        Price Insert(Price price);

        List<Price> ExecuteQuery(int storeid, int productid);

        Price Update(Price price);
    }
}
