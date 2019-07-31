using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class PriceBusiness : IPriceBusiness
    {
        IPriceRepository _priceRepository;

        public PriceBusiness(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }
        public List<Price> ExecuteQuery(int storeid, int productid)
        {
            var x = _priceRepository.ExecuteQuery(storeid, productid);
            return x;
        }

        public Price Insert(Price price)
        {
            return _priceRepository.Insert(price);
        }

        public Price Update(Price price)
        {
            return _priceRepository.Update(price);
        }
    }
}
