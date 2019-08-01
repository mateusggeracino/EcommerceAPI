using System;
using System.Collections.Generic;
using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
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
            try
            {
                var paymentMethods = _paymentMethodService.GetAll( );
                return _mapper.Map<List<PaymentMethodViewModel>>( paymentMethods );
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }


        }

        /// <summary>
        /// Get Payment Method by Id
        /// </summary>
        /// <param name="id">Id Payment Method</param>
        /// <returns>Payment Method</returns>
        [HttpGet( "{id}" )]
        public ActionResult<PaymentMethodViewModel> GetById( [FromRoute] int id )
        {
            try
            {
                var paymentMethod = _paymentMethodService.GetById( id );
                return _mapper.Map<PaymentMethodViewModel>( paymentMethod );
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }

        }

        /// <summary>
        /// Insert Ney Payment Method
        /// </summary>
        /// <param name="paymentMethodViewModel">Object Payment Method</param>
        /// <returns>Success</returns>
        [HttpPost]
        public ActionResult<string> Post( [FromBody] PaymentMethodViewModel paymentMethodViewModel )
        {
            try
            {
                var paymentMethod = _mapper.Map<PaymentMethod>( paymentMethodViewModel );

                _paymentMethodService.Add( paymentMethod );

                return Ok( "Success" );
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }

        }

        /// <summary>
        /// Update Payment Method
        /// </summary>
        /// <param name="id">Id Payment Method</param>
        /// <param name="paymentMethodViewModel">Object Payment Method</param>
        /// <returns>Success</returns>
        [HttpPut( "{id}" )]
        public ActionResult<string> Put( [FromRoute] int id, [FromBody] PaymentMethodViewModel paymentMethodViewModel )
        {
            try
            {
                var paymentMethod = _mapper.Map<PaymentMethod>( paymentMethodViewModel );

                paymentMethod.Id = id;

                _paymentMethodService.Update( paymentMethod );

                return Ok( "Sucess" );
            }
            catch ( Exception ex )
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Delete Payment Method
        /// </summary>
        /// <param name="id">Id Payment Method</param>
        /// <returns>Success</returns>
        [HttpDelete( "{id}" )]
        public ActionResult<string> Delete( [FromRoute] int id )
        {
            try
            {
                _paymentMethodService.Delete( id );

                return Ok( "Sucess" );
            }
            catch ( Exception ex )
            {
                return BadRequest( ex.Message );
            }

        }
    }
}