using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Application.Controllers
{
    /// <summary>
    /// Clase responsável pelo comportamento do pedido (order)
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;
        private readonly IMapper _mapper;

        public OrderController(IPaymentServices paymentServices, IMapper mapper)
        {
            _paymentServices = paymentServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por finalizar o pedido (order)
        /// </summary>
        /// <param name="paymentViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("finalize-order")]
        public void FinalizeOrder(int orderId, int payMTId)
        {
            _paymentServices.InsertPayment(orderId, payMTId);
            //_paymentServices.FinalyPaymant(orderId);
        }
    }
}
