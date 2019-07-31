using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Application.ViewModels;
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
        private readonly IStockServices _stockServices;
        private readonly IMapper _mapper;

        public ShoppingCartsController(IShoppingCartServices shoppingCartservices, IStockServices stockServices, IMapper mapper)
        {
            _shoppingCartServices = shoppingCartservices;
            _stockServices = stockServices;
            _mapper = mapper;
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
        public ActionResult<string> Post([FromBody] ShoppingCartsViewModel shoppingCartsViewModel)
        {
             var shoppingCarts = _shoppingCartServices
                 .Insert(_mapper.Map<ShoppingCarts>(shoppingCartsViewModel));

            //if(shoppingCarts.)
            return null;
        }

        [HttpPut]
        public void Put([FromBody] ShoppingCarts shoppingCarts)
        {
            _shoppingCartServices.Update(shoppingCarts);
        }

        /// <summary>
        /// Finalizar Carrinho de Compras
        /// </summary>
        /// <param name="shoppingCarts"></param>
        [HttpPatch]
        public void Patch([FromBody] ShoppingCarts shoppingCarts)
        {
            var order = _shoppingCartServices.InsertOrder(shoppingCarts);
            // id order - vira status do carrinho
            shoppingCarts.CartStatus = order.Id;
            _shoppingCartServices.Update(shoppingCarts);
            var stock = _stockServices.GetByProduct(shoppingCarts.CartStoreId, shoppingCarts.CartProductId);
            _stockServices.RemoveQuantityVirtual(shoppingCarts);
        }

        /// <summary>
        /// Finalizar Pedido
        /// </summary>
        /// <param name="shoppingCarts"></param>
        [HttpPatch]
        [Route("finalize-order")]
        public void FinalizeOrder([FromBody] ShoppingCarts shoppingCarts)
        {
            //_shoppingCartServices.InsertPayment();
        }
    }
}