using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services
{
    public class ShoppingkartServices : IShoppingKartServices
    {
        private readonly IShoppingKartsBusiness _shoppingKartsBusiness;

        public ShoppingkartServices(IShoppingKartsBusiness shoppingKartsBusiness)
        {
            _shoppingKartsBusiness = shoppingKartsBusiness;
        }
        public IEnumerable<ShoppingKarts> List()
        {
            throw new NotImplementedException();
        }
    }
}
