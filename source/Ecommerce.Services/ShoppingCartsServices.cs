using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services
{
    public class ShoppingCartsServices : IShoppingCartServices
    {
        private readonly IShoppingCartsBusiness _shoppingCartsBusiness;
        private readonly IPaymentMethodBusiness _paymentAuthorizeBusiness;

        public ShoppingCartsServices(IShoppingCartsBusiness shoppingCartsBusiness, IPaymentMethodBusiness paymentAuthorizeBusiness)
        {
            _shoppingCartsBusiness = shoppingCartsBusiness;
            _paymentAuthorizeBusiness = paymentAuthorizeBusiness;
        }
        public List<ShoppingCarts> List()
        {
           return  _shoppingCartsBusiness.List();
        }

        public ShoppingCarts GetById(int id)
        {
            return _shoppingCartsBusiness.GetById(id);
        }

        public string Insert(ShoppingCarts shoppingCarts)
        {
            _shoppingCartsBusiness.InsertShoppingCarts(shoppingCarts);
            return ("sucess");

        }
        public string Update(ShoppingCarts shoppingCarts)
        {
            _shoppingCartsBusiness.Update(shoppingCarts);
            return ("sucess");
        }

        public Order InsertOrder(ShoppingCarts shoppingCarts)
        {
            return _shoppingCartsBusiness.InsertOrder(shoppingCarts);
        }

        //public int InsertPayment()
        //{
        //    return _paymentAuthorizeBusiness.
        //}
    }
}
