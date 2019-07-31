using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class ShoppingCartsBusiness : IShoppingCartsBusiness
    {
        private readonly IShoppingCartsRepository _shoppingCartsRepository;
        private readonly IOrderRepository _orderRepository;
        public ShoppingCartsBusiness(IShoppingCartsRepository shoppingCartsRepository, IOrderRepository orderRepository)
        {
            _shoppingCartsRepository = shoppingCartsRepository;
            _orderRepository = orderRepository;
        }
        public List<ShoppingCarts> List()
        {
            return _shoppingCartsRepository.GetAll();
        }

        public ShoppingCarts GetById(int id)
        {
            return _shoppingCartsRepository.GetById(id);
        }

        public ShoppingCarts InsertShoppingCarts(ShoppingCarts shoppingCarts)
        {
            return _shoppingCartsRepository.Insert(shoppingCarts);
        }

        public Order InsertOrder(ShoppingCarts shoppingCartsView)
        {
            return _orderRepository.Insert(new Order
            {
                OrderCartId = shoppingCartsView.Id,
                OrderCreation = DateTime.Now,
                OrderExpiring = DateTime.Now.AddDays(7),
                OrderStatus = 1,
                OrderTotalValue = shoppingCartsView.Quantity * (shoppingCartsView.CartUnitPrice.HasValue ? shoppingCartsView.CartUnitPrice.Value : shoppingCartsView.Quantity)
            }); ;
        }

        public void Update(ShoppingCarts shoppingCarts)
        {
            _shoppingCartsRepository.Update(shoppingCarts);
        }

        public List<ShoppingCarts> GetViewShoppingCart(int shoppingCartId)
        {
            return _shoppingCartsRepository.GetViewShoppingCarts(shoppingCartId);
        }
    }
}
