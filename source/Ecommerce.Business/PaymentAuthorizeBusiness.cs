using System.Collections.Generic;
using System.Net;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Integration.AuthorizarApi.Business;
using Ecommerce.Integration.AuthorizarApi.Domain.Models.Request;
using Ecommerce.Integration.AuthorizarApi.Domain.Models.Response;
using Ecommerce.Repository.Interfaces;

namespace Ecommerce.Business
{
    public class PaymentAuthorizeBusiness : IPaymentAuthorizeBusiness
    {
        private readonly IPaymentAuthorizeRepository _paymentAuthorizerepository;
        private readonly IStockRepository _stockRepository;
        private readonly IShoppingCartsRepository _shoppingCartsRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentrepository;

        public PaymentAuthorizeBusiness(IPaymentRepository paymentrepository,IPaymentAuthorizeRepository paymentauthorizerepository, IStockRepository stockRepository, IShoppingCartsRepository shoppingCartsRepository, IOrderRepository orderRepository)
        {
            _paymentAuthorizerepository = paymentauthorizerepository;
            _stockRepository = stockRepository;
            _shoppingCartsRepository = shoppingCartsRepository;
            _orderRepository = orderRepository;
            _paymentrepository = paymentrepository;
        }

        public bool FinalyPaymant(int order)
        {
            var payment = _paymentAuthorizerepository.GetByPayment(order);
            if (payment != null)
            {
                var result = AuthorizePayment(payment);

                switch (result.PayStatus)
                {
                    case 0:
                        {
                            UpdateStatusOrder(order, 400);
                            Updatepayment(result, 400);
                            UpdadeStock(order);
                            break;
                        }
                    case 1:
                        {
                            UpdateStatusOrder(order, 500);
                            Updatepayment(result, 500);
                            break;
                        }
                }
                return true;
            }
            return false;          
        }
        private Payments AuthorizePayment(vw_PaymentOrder order)
        {
            Payments payment = new Payments();
            payment.OrderId = order.Id;

            if(order.EndPointName == "CreditCardTransaction")
            {
                var integration = new Integration<CreditCardResponse>();
                var result = integration.Post(order.EndPointName, new CreditCardRequest());                
                payment.PayTransactionId = result.CreditCardTransaction.CreditCard.Id;
                payment.PayStatus = result.CreditCardTransaction.CreditCard.Status;
            }
            else
            {
                var integration = new Integration<PaymentSlipResponse>();
                var result = integration.Post(order.EndPointName, new PaymentSlipResponse());
                payment.PayTransactionId = result.PaymentSlipTransaction.PaymentSlip.Id;
                payment.PayStatus = result.PaymentSlipTransaction.PaymentSlip.Status;
            }
            return payment;
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

        private void Updatepayment(Payments payment, int status)
        {
            _paymentrepository.Updatestatus(payment, status);
        }
    }
}
