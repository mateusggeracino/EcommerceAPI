using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public PriceController(IPriceServices productServices, ILogger<PriceController> logger)
        {
            _priceServices = productServices;
            _logger = logger;
        }


        [HttpGet("{productid}")]
        public ActionResult<List<Price>> GetPrice([FromHeader] int storeid, int productid)
        {
            return _priceServices.ExecuteQuery(storeid, productid);
        }

        [HttpPost]
        public ActionResult<Price> Post([FromBody] Price price)
        {
            try
            {
                _logger.LogInformation("Received post request");

                if (!ModelState.IsValid) return BadRequest(price);

                return _priceServices.Insert(price);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPut("{id}")]
        public Price Update(Price price)
        {
            return _priceServices.Update(price);
        }
    }
}