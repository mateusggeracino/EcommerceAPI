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
        private readonly IShoppingCartsBusiness _shoppingCartsBusiness;

        public ShoppingCartServices(IShoppingCartsBusiness shoppingCartsBusiness)
        {
            _shoppingCartsBusiness = shoppingCartsBusiness;
        }
        public IEnumerable<ShoppingCarts> List()
        {
           return  _shoppingCartsBusiness.List();
        }

        public ShoppingCarts GetById(int id)
        {
            return _shoppingCartsBusiness.GetById(id);
        }

        public void Insert(ShoppingCarts shoppingCarts)
        {
            _shoppingCartsBusiness.InsertShoppingCarts(shoppingCarts);
        }
        public void Update(ShoppingCarts shoppingCarts)
        {
            _shoppingCartsBusiness.Update(shoppingCarts);
        }

        public Order InsertOrder(ShoppingCarts shoppingCarts)
        {
            return _shoppingCartsBusiness.InsertOrder(shoppingCarts);
        }
    }
}
