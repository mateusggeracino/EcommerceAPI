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

        [HttpGet]
        public IEnumerable<ShoppingCarts> Get()
        {
            return _shoppingCartServices.List();
        }

        [HttpGet("{id}")]
        public ShoppingCarts Get(int id)
        {
            return _shoppingCartServices.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] ShoppingCarts shoppingCarts)
        {
             _shoppingCartServices.Insert(shoppingCarts);
        }

        [HttpPut]
        public void Put([FromBody] ShoppingCarts shoppingCarts)
        {
            _shoppingCartServices.Update(shoppingCarts);
        }

        [HttpPatch]
        public void FinalizeShoppingCarts([FromBody] ShoppingCarts shoppingCarts)
        {

            _shoppingCartServices.Update(shoppingCarts);

        }
    }
}