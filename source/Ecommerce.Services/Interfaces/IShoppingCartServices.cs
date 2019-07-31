using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IShoppingCartServices
    {
        List<ShoppingCarts> List();

        ShoppingCarts GetById(int id);

        string Insert(ShoppingCarts shoppingCarts);

        string Update(ShoppingCarts shoppingCarts);

        Order InsertOrder(ShoppingCarts shoppingCarts);

        List<ShoppingCarts> GetViewShoppingCarts(int shoppingCartId);
    }
}
