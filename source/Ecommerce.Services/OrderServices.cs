using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderBusiness _orderBusiness;

        public OrderServices(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }

        /// <summary>
        /// Método que é responsável por passar dados do carrinho
        /// para a regra de negócio da ordem
        /// </summary>
        /// <param name="shoppingCarts"></param>
        /// <param name="shoppingCartsView"></param>
        /// <returns></returns>
        public Order InsertOrder(ShoppingCarts shoppingCartsView)
        {
            return _orderBusiness.Insert(shoppingCartsView);
        }
    }
}
