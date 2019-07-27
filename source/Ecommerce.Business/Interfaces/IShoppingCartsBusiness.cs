using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interfaces
{
    public interface IShoppingCartsBusiness
    {
        IEnumerable<ShoppingCarts> List();
        ShoppingCarts GetById(int id);
        void InsertShoppingCarts(ShoppingCarts shoppingCarts);

        void Update(ShoppingCarts shoppingCarts);

        void InsertOrder(ShoppingCarts shoppingCarts);
    }
}
