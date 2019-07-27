using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IShoppingCartServices
    {
        IEnumerable<ShoppingCarts> List();

        ShoppingCarts GetById(int id);

        void Insert(ShoppingCarts shoppingCarts);

        void Update(ShoppingCarts shoppingCarts);

        void InsertOrder(ShoppingCarts shoppingCarts);
    }
}
