using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class PaymentAuthorizeBusiness 
    {
        private readonly IPaymentAuthorizeRepository _ipaymentrepository;
        private readonly IStockRepository _stockRepository;
        private readonly IShoppingCartsRepository _shoppingCartsRepository;
        public PaymentAuthorizeBusiness(IPaymentAuthorizeRepository ipaymentrepository, IStockRepository stockRepository, IShoppingCartsRepository shoppingCartsRepository)
        {
            _ipaymentrepository = ipaymentrepository;
            _stockRepository = stockRepository;
            _shoppingCartsRepository = shoppingCartsRepository;
        }

        public bool FinalyPaymant(int order)
        {
            var payment = _ipaymentrepository.GetByPayment(order);
            if (payment != null)
            {
                //Verica a aprovação do pagamento em Result
                var result = AuthorizePayment(payment);

                
                // Pagamento aprovado Atualizar Status da Order para 3 e Stock
                UpdateStatysorder(order, 3);
                UpdadeStock(order);


                // Pagamento reprovado  Atualiza Status da Orther para 2
                UpdateStatysorder(order, 2);


                return true;
            }
            
            else
            {
                return false;
            }           
        }
        private string AuthorizePayment(vw_PaymentOrther order)
        {

            //Verify the authorizePayment and return status

            return "";
        }

        private void UpdateStatysorder(int order, int status)
        {
            // Atualizar Tabela Transactions.Orders

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
