using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ProductController : BaseController
    {
        private readonly IProductServices _productServices;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(IProductServices productServices, ILogger<ProductController> logger, IMapper mapper)
        {
            _productServices = productServices;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                _logger.LogInformation("Received get all product request");
                var result = _productServices.GetAll();
                return Ok(_mapper.Map<List<ProductViewModel>>(result));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet)]
        public ActionResult<List<ProductViewModel>> GetId([FromHeader] int Id)
        {
            try
            {
                _logger.LogInformation("Received get by id product request");
                var result = _productServices.GetById(Id);
                return Ok(_mapper.Map<ProductViewModel>(result));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("Description/{description}")]
        public ActionResult<List<ProductViewModel>> GetDescription([FromRoute] string description)
        {
            try
            {
                _logger.LogInformation("Received get by description product request");
                var result = _productServices.GetByDescription(description);
                return Ok(_mapper.Map<List<ProductViewModel>>(result));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("Brand/{brand}")]
        public ActionResult<List<ProductViewModel>> GetBrand([FromRoute] string brand)
        {
            try
            {
                _logger.LogInformation("Received get by brand product request");
                var result = _productServices.GetByBrand(brand);
                return Ok(_mapper.Map<List<ProductViewModel>>(result));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] ProductViewModel product)
        {
            try
            {
                _logger.LogInformation("Received post product request");

                if (!ModelState.IsValid) return BadRequest(product);
                var result = _productServices.Insert(_mapper.Map<Product>(product));
                if (result.ValidationResult.Errors.Any()) return AddValidationErrors(result.ValidationResult.Errors);

                return Ok("success");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPut]
        public ActionResult<string> Update([FromHeader] int id, ProductViewModel product)
        {
            try
            {
                _logger.LogInformation("Received put product request");
                product.Id = id;
                var result = _productServices.Update(_mapper.Map<Product>(product));
                if (result.ValidationResult.Errors.Any()) return AddValidationErrors(result.ValidationResult.Errors);

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