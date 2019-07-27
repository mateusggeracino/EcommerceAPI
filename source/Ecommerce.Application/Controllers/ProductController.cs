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
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductServices productServices, ILogger<ProductController> logger)
        {
            _productServices = productServices;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            try
            {
                _logger.LogInformation("Received get request");

                return Ok(_productServices.GetAll());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<List<Product>> GetId([FromRoute] string Id)
        {
            return _productServices.ExecuteQueryId(Id);
        }

        [HttpGet("Description/{description}")]
        public ActionResult<List<Product>> GetDescription([FromRoute] string description)
        {
            return _productServices.ExecuteQueryDescription(description);
        }

        [HttpGet("Brand/{brand}")]
        public ActionResult<List<Product>> GetBrand([FromRoute] string brand)
        {
            return _productServices.ExecuteQueryBrand(brand);
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Product product)
        {
            try
            {
                _logger.LogInformation("Received post request");

                if (ModelState.IsValid)
                {
                    return _productServices.Insert(product);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPut("{id}")]
        public Product Update(Product product)
        {
            return _productServices.Update(product);
        }
    }
}