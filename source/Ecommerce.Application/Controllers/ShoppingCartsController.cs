using System;
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
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IShoppingCartServices _shoppingCartServices;

        public ShoppingCartsController(IShoppingCartServices shoppingCartservices)
        {
            _shoppingCartServices = shoppingCartservices;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ShoppingCarts> Get()
        {
            return _shoppingCartServices.List();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ShoppingCarts Get(int id)
        {
            return _shoppingCartServices.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ShoppingCarts shoppingCarts)
        {
             _shoppingCartServices.Insert(shoppingCarts);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] ShoppingCarts shoppingCarts)
        {
            _shoppingCartServices.Update(shoppingCarts);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}