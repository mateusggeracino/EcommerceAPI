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
        private readonly IShoppingKartsRepository _shoppingCartsRepository;
        public PaymentAuthorizeBusiness(IPaymentAuthorizeRepository ipaymentrepository, IStockRepository stockRepository, IShoppingKartsRepository shoppingCartsRepository)
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

        private void UpdadeStock(int order)
        {
            var Query = "update Products.Stock " +
                "set RealStock = a.RealStock - b.Quantity " +
                "from " +
                    "Products.Stock A " +
                "inner join " +
                    "Transactions.ShoppingCarts B on A.Id = B.CartProductId " +
                "where " +
                "   b.CartStatus = {ID}";
            // Atualiza tabela Products.Stock
        }
    }
}
