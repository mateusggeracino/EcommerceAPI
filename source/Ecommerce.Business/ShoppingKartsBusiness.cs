using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class ShoppingKartsBusiness : IShoppingKartsBusiness
    {
        private IRepository<ShoppingKarts> _shoppingKarts;
        public ShoppingKartsBusiness(IRepository<ShoppingKarts> shoppingKartsRepository)
        {
            _shoppingKarts = shoppingKartsRepository;
        }
        public IEnumerable<ShoppingKarts> List()
        {
            throw new NotImplementedException();
        }
    }
}
