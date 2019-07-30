﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;
using Ecommerce.Integration.AuthorizarApi;
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
        /// <summary>
        /// Get All Payment Methods
        /// </summary>
        /// <returns>List payment methods</returns>
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
        public ActionResult<string> Post( [FromBody] PaymentMethodViewModel paymentMethodViewModel )
        {
            var paymentMethod = _mapper.Map<PaymentMethod>( paymentMethodViewModel );

            _paymentMethodService.Add( paymentMethod );

            return Ok( "success" );
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Put([FromRoute] int id, [FromBody] PaymentMethodViewModel paymentMethodViewModel )
        {
            var paymentMethod = _mapper.Map<PaymentMethod>( paymentMethodViewModel );

            _paymentMethodService.Update( paymentMethod );

            return Ok( "Sucess" );
        }

        [HttpPut("{id}")]
        public ActionResult<string> Delete([FromRoute] int id )
        {
            _paymentMethodService.Delete( id );

            return Ok( "Sucess" );
        }
    }
}