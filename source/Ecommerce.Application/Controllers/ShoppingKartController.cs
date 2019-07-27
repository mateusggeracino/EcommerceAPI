﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingKartController : Controller
    {
        private readonly IShoppingKartServices _shoppingKartservices;

        public ShoppingKartController(IShoppingKartServices shoppingKartservices)
        {
            _shoppingKartservices = shoppingKartservices;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ShoppingKarts>> Get()
        {
            //return _shoppingKartservices.List();
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}