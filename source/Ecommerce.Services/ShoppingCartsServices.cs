﻿using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services
{
    public class ShoppingCartsServices : IShoppingCartServices
    {
        private readonly IShoppingCartsBusiness _shoppingCartsBusiness;

        public ShoppingCartsServices(IShoppingCartsBusiness shoppingCartsBusiness)
        {
            _shoppingCartsBusiness = shoppingCartsBusiness;
        }
        public List<ShoppingCarts> List()
        {
            return _shoppingCartsBusiness.List();
        }


        public ShoppingCarts GetById(int id)
        {
            return _shoppingCartsBusiness.GetById(id);
        }

        public ShoppingCarts Insert(ShoppingCarts shoppingCarts)
        {
            return _shoppingCartsBusiness.InsertShoppingCarts(shoppingCarts);

        }
        public ShoppingCarts Update(ShoppingCarts shoppingCarts)
        {
            return _shoppingCartsBusiness.Update(shoppingCarts);
        }

        public Order InsertOrder(ShoppingCarts shoppingCarts)
        {
            return _shoppingCartsBusiness.InsertOrder(shoppingCarts);
        }

        public List<ShoppingCarts> GetViewShoppingCarts(int shoppingCartId)
        {
            return _shoppingCartsBusiness.GetViewShoppingCart(shoppingCartId);
        }
    }
}
