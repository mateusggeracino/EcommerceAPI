using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services
{
    public class ShoppingCartServices : IShoppingCartServices
    {
        private readonly IShoppingCartsBusiness _shoppingKartsBusiness;

        public ShoppingCartServices(IShoppingCartsBusiness shoppingKartsBusiness)
        {
            _shoppingKartsBusiness = shoppingKartsBusiness;
        }
        public IEnumerable<ShoppingCarts> List()
        {
            throw new NotImplementedException();
        }
    }
}
