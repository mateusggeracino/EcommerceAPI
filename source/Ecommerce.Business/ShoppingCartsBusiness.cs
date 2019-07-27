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
        private readonly IShoppingKartsRepository _shoppingCarts;
        public ShoppingKartsBusiness(IShoppingKartsRepository shoppingCarts)
        {
            _shoppingCarts = shoppingCarts;
        }
        public IEnumerable<ShoppingCarts> List()
        {
            return _shoppingCarts.GetAll();
        }

        public ShoppingCarts GetById(int id)
        {
            return _shoppingCarts.GetById(id);
        }

        public void InsertShoppingCarts(ShoppingCarts shoppingCarts)
        {
            _shoppingCarts.InsertShoppingCarts(shoppingCarts);
        }

        public void Update(ShoppingCarts shoppingCarts)
        {
            _shoppingCarts.Update(shoppingCarts);
        }
    }
}
