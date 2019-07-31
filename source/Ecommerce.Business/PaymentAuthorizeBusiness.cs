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
                //Verica a aprovação do pagamento em Result
                var result = AuthorizePayment(payment);

                switch (result)
                {
                    case HttpStatusCode.OK:
                        {
                            UpdateStatusOrder(order, 3);
                            UpdadeStock(order);
                            break;
                        }
                     
                }

                //if(result.)
                // Pagamento aprovado Atualizar Status da Order para 3 e Stock



                // Pagamento reprovado  Atualiza Status da Orther para 2



                return true;
            }

            else
            {
                return false;
            }
        }
        private HttpStatusCode AuthorizePayment(vw_PaymentOrder order)
        {
            var integration = new Integration<CreditCardResponse>();
            var result = integration.Post(EndPoint.CreditCardTransation, new CreditCardRequest());

            //var creditCard = new CreditCardRequest();
            //var restResponse = _authorizarPayment.Send(order.EndPointName, creditCard);

            //return restResponse.StatusCode;
            return HttpStatusCode.Accepted;
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
