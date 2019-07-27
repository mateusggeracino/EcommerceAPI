using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IShoppingCartServices
    {
        IEnumerable<ShoppingCarts> List();
    }
}
