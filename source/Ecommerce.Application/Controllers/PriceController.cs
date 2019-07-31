using System;
using System.Collections.Generic;
using AutoMapper;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceServices _priceServices;
        private readonly ILogger<PriceController> _logger;
        private readonly IMapper _mapper;
        public PriceController(IPriceServices productServices, ILogger<PriceController> logger, IMapper mapper)
        {
            _priceServices = productServices;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet("{productid}")]
        public ActionResult<List<PriceViewModel>> GetPrice([FromHeader] int storeid, int productid)
        {
            try
            {
                _logger.LogInformation("Received get list price request");
                var result = _priceServices.ExecuteQuery(storeid, productid);
                return Ok(_mapper.Map<PriceViewModel>(result));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] PriceViewModel price)
        {
            try
            {
                _logger.LogInformation("Received post price request");

                if (!ModelState.IsValid) return BadRequest(price);
                _priceServices.Insert(_mapper.Map<Price>(price));
                return Ok("success");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<string> Update(PriceViewModel price)
        {
            try
            {
                _logger.LogInformation("Received put price request");
                _priceServices.Update(_mapper.Map<Price>(price));
                return Ok("success");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}