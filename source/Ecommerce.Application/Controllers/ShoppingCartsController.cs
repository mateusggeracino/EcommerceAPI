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
        public ActionResult<string> Get()
        {
            _shoppingCartServices.List();
            return Ok("success");
        }

        [HttpGet("{id}")]
        public ActionResult<ShoppingCarts> Get(int id)
        {
             _shoppingCartServices.GetById(id);
            return Ok("success");
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
        public ActionResult<string> Put([FromBody] ShoppingCarts shoppingCarts)
        {
            _shoppingCartServices.Update(shoppingCarts);
            return Ok("success");
        }

        /// <summary>
        /// Finalizar Carrinho de Compras
        /// </summary>
        /// <param name="shoppingCarts"></param>
        [HttpPatch]
        public void Patch([FromBody] ShoppingCarts shoppingCarts)
        {
            List<ShoppingCarts> shoppingCartsList = _shoppingCartServices.GetViewShoppingCarts(shoppingCarts.Id);
            ShoppingCarts shoppingCartView = shoppingCartsList.Where(x => x.Id == shoppingCarts.Id).FirstOrDefault();

            Order order = _shoppingCartServices.InsertOrder(shoppingCarts, shoppingCartView);

            // ** problema aqui **
            //shoppingCarts.CartStatus = order.Id;
            //shoppingCarts.CartUnitPrice = shoppingCartsList.Where(x => x.Id == shoppingCarts.Id && x.CartProductId == shoppingCarts.CartProductId).FirstOrDefault().CartUnitPrice;
            //_shoppingCartServices.Update(shoppingCarts);

            //Stock stock = _stockServices.GetByProduct(shoppingCarts.CartStoreId, shoppingCarts.CartProductId);
            //_stockServices.RemoveQuantityVirtual(shoppingCarts);
        }
    }
}