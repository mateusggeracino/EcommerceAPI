using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;

       public PaymentController(IPaymentServices paymentServices){

            _paymentServices = paymentServices;
       }

        /// <summary>
        /// Finalizar Pedido
        /// </summary>
        /// <param name="shoppingCarts"></param>
        [HttpPost]
        [Route("finalize-order")]
        public void FinalizeOrder(int orderId, int paymentId)
        {
            _paymentServices.InsertPayment(orderId, paymentId);

        }

    }
}
