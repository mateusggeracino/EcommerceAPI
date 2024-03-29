﻿using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interfaces
{
    public interface IShoppingCartsBusiness
    {
        List<ShoppingCarts> List();
        ShoppingCarts GetById(int id);
        ShoppingCarts InsertShoppingCarts(ShoppingCarts shoppingCarts);

        ShoppingCarts Update(ShoppingCarts shoppingCarts);

        Order InsertOrder(ShoppingCarts shoppingCartsView);

        List<ShoppingCarts> GetViewShoppingCart(int shoppingCartId);
    }
}
