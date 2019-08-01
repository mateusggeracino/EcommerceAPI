using System.Net;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Integration.AuthorizarApi.Business;
using Ecommerce.Integration.AuthorizarApi.Domain.Models.Request;
using Ecommerce.Integration.AuthorizarApi.Domain.Models.Response;
using Ecommerce.Repository.Interfaces;
using EndPoint = Ecommerce.Integration.AuthorizarApi.Domain.ValueObject.EndPoint;

namespace Ecommerce.Business
{
    public class PaymentAuthorizeBusiness : IPaymentAuthorizeBusiness
    {
        private readonly IPaymentAuthorizeRepository _paymentRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IShoppingCartsRepository _shoppingCartsRepository;
        private readonly IOrderRepository _orderRepository;

        public PaymentAuthorizeBusiness(IPaymentAuthorizeRepository paymentRepository, IStockRepository stockRepository, IShoppingCartsRepository shoppingCartsRepository, IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _stockRepository = stockRepository;
            _shoppingCartsRepository = shoppingCartsRepository;
            _orderRepository = orderRepository;
        }

        public bool FinalyPaymant(int order)
        {
            var payment = _paymentRepository.GetByPayment(order);
            if (payment != null)
            {
                var result = AuthorizePayment(payment);

                switch (result)
                {
                    case "0":
                        {
                            UpdateStatusOrder(order, 3);
                            UpdadeStock(order);
                            break;
                        }
                    case "1":
                        {
                            UpdateStatusOrder(order, 3);
                            break;
                        }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        private string AuthorizePayment(vw_PaymentOrder order)
        {
            string finaly;
            if(order.EndPointName == "CreditCardTransaction")
            {
                var integration = new Integration<CreditCardResponse>();
                var result = integration.Post(order.EndPointName, new CreditCardRequest());
                finaly = result.CreditCardTransaction.CreditCard.Status.ToString();
            }
            else
            {
                var integration = new Integration<CreditCardResponse>();
                var result = integration.Post(order.EndPointName, new CreditCardRequest());
                finaly = result.CreditCardTransaction.CreditCard.Status.ToString();
            }
            return finaly;
        }

        private void UpdateStatusOrder(int orderId, int status)
        {
            var order = _orderRepository.GetById(orderId);
            order.OrderStatus = status;
            _orderRepository.Update(order);
        }

        private void UpdadeStock(int orderId)
        {
            var orders = _shoppingCartsRepository.GetByOrder(orderId);

            foreach (var order in orders)
            {
                var stockProduct = _stockRepository.GetByStoreProduct(order.CartStoreId, order.CartProductId);

                stockProduct.RealStock -= order.Quantity;

                _stockRepository.Update(stockProduct);
            }
        }
    }
}
