using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IOrderRepository _orderRepository;

        public OrderBusiness(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Insert(ShoppingCarts shoppingCartsView)
        {
            return _orderRepository.Insert(new Order
            {
                OrderCartId = shoppingCartsView.Id,
                OrderCreation = DateTime.Now,
                OrderExpiring = DateTime.Now.AddDays(7),
                OrderStatus = 1,
                OrderTotalValue = shoppingCartsView.Quantity * (shoppingCartsView.CartUnitPrice.HasValue ? shoppingCartsView.CartUnitPrice.Value : shoppingCartsView.Quantity)
            });
        }
    }
}
