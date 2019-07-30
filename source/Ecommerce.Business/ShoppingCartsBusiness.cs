﻿using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
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

        public void InsertShoppingCarts(ShoppingCarts shoppingCarts)
        {
            _shoppingCartsRepository.InsertShoppingCarts(shoppingCarts);
        }

        public Order InsertOrder(ShoppingCarts shoppingCarts)
        {
            return _orderRepository.Insert(new Order
            {
                OrderCartId = shoppingCarts.Id,
                OrderCreation = DateTime.Now,
                OrderExpiring = DateTime.Now.AddDays(7),
                OrderStatus = 1
            });
        }

        public void Update(ShoppingCarts shoppingCarts)
        {
            _shoppingCartsRepository.Update(shoppingCarts);
        }
    }
}
