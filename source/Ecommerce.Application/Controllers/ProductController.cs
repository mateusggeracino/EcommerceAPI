﻿using System;
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
        public ActionResult<string> Post([FromBody] ProductViewModel product)
        {
            try
            {
                _logger.LogInformation("Received post request");

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

        [HttpPut("{id}")]
        public Product Update(Product product)
        {
            return _productServices.Update(product);
        }
    }
}