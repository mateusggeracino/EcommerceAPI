using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services
{
    public class PriceServices : IPriceServices
    {
        private readonly IPriceBusiness _priceBusiness;
        public PriceServices(IPriceBusiness pricebusiness)
        {
            _priceBusiness = pricebusiness;
        }

        public List<Price> ExecuteQuery(int storeid, int productid)
        {
            return _priceBusiness.ExecuteQuery(storeid, productid);
        }

        public Price Insert(Price price)
        {
            return _priceBusiness.Insert(price);
        }

        public Price Update(Price price)
        {
            return _priceBusiness.Update(price);
        }
    }
}
