using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Application.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPaymentMethodService _paymentMethodService;
        public PaymentMethodController( IMapper mapper, IPaymentMethodService paymentMethodService )
        {
            _mapper = mapper;
            _paymentMethodService = paymentMethodService;
        }

        [HttpGet]
        public ActionResult<List<PaymentMethodViewModel>> Get( )
        {
            var paymentMethods = _paymentMethodService.GetAll( );
            return _mapper.Map<List<PaymentMethodViewModel>>( paymentMethods );
        }

        [HttpGet( "{id}" )]
        public ActionResult<PaymentMethodViewModel> GetById( [FromRoute] int id )
        {
            var paymentMethod = _paymentMethodService.GetById( id );
            return _mapper.Map<PaymentMethodViewModel>( paymentMethod );
        }

        [HttpPost]
        public ActionResult Post( [FromBody] PaymentMethodViewModel paymentMethodViewModel )
        {
            var paymentMethod = _mapper.Map<PaymentMethod>( paymentMethodViewModel );

            _paymentMethodService.Add( paymentMethod );

            return Ok( );
        }
    }
}