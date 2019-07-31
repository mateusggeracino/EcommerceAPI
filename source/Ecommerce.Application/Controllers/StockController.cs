using System;
using System.Collections.Generic;
using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;
using Ecommerce.Integration.AuthorizarApi.Interface;
using Ecommerce.Integration.AuthorizarApi.Model;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Controllers
{
    /// <summary>
    /// Api responsável por oferecer métodos de estoque
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStockServices _stockServices;
        private readonly ILogger<StockController> _logger;
        private readonly IAuthorizar _authorizar;
        public StockController(IMapper mapper, IStockServices stockServices, ILogger<StockController> logger, IAuthorizar authorizar)
        {
            _mapper = mapper;
            _stockServices = stockServices;
            _logger = logger;
            _authorizar = authorizar;
        }

        /// <summary>
        /// Get product by storeId and productId
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{productId:int}")]
        public ActionResult<StockViewModel> GetByProduct([FromHeader] int storeId, int productId)
        {
            try
            {
                var stockEntity = _stockServices.GetByProduct(storeId, productId);
                return Ok(_mapper.Map<StockViewModel>(stockEntity));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockViewModel>> GetAll()
        {
            try
            {
                var obj = new CreditCardTransaction();
                var result = _authorizar.Send("CreditCardTransaction", obj);

                _logger.LogInformation("Received post request");
                var stockList = _stockServices.GetAll();
                return Ok(_mapper.Map<List<StockViewModel>>(stockList));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Insert a new stock
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> Insert([FromBody] StockViewModel stock )
        {
            try
            {
                _logger.LogInformation("Received post request");

                if (!ModelState.IsValid) return BadRequest(ModelState);

                _stockServices.Insert(_mapper.Map<Stock>(stock));
                return Ok("success");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }
        
        /// <summary>
        /// Remove a stock by storeId and productId
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{productId:int}")]
        public ActionResult Remove([FromHeader] int storeId, int productId)
        {
            try
            {
                _logger.LogInformation("Received post request");
                _stockServices.Remove(storeId, productId);
                return Ok("success");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Update stock
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Update([FromBody] StockViewModel stock)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(stock);
                _stockServices.Update(_mapper.Map<Stock>(stock));
                return Ok("success");
            }catch(Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}