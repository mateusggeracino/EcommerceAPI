using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class ShoppingKartsBusiness : IShoppingCartsBusiness
    {
        private IRepository<ShoppingCarts> _shoppingCarts;
        public ShoppingKartsBusiness(IRepository<ShoppingCarts> shoppingKartsRepository)
        {
            _shoppingCarts = shoppingKartsRepository;
        }
        public IEnumerable<ShoppingCarts> List()
        {
            throw new NotImplementedException();
        }
    }
}
