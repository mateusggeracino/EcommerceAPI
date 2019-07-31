using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interfaces
{
    public interface IShoppingCartsBusiness
    {
        List<ShoppingCarts> List();
        ShoppingCarts GetById(int id);
        void InsertShoppingCarts(ShoppingCarts shoppingCarts);

        void Update(ShoppingCarts shoppingCarts);

        Order InsertOrder(ShoppingCarts shoppingCarts, ShoppingCarts shoppingCartsView);

        List<ShoppingCarts> GetViewShoppingCart(int shoppingCartId);
    }
}
