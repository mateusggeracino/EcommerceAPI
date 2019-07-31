using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IOrderServices
    {
        Order InsertOrder(ShoppingCarts shoppingCartsView);
    }
}
