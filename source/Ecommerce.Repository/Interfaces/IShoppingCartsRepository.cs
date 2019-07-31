using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Interfaces
{
    public interface IShoppingCartsRepository : IRepository<ShoppingCarts>
    {
        //void InsertShoppingCarts(ShoppingCarts shoppingCarts);
        List<ShoppingCarts> GetByOrder(int order);

        List<ShoppingCarts> GetViewShoppingCarts(int shoppingCartId);
    }
}
