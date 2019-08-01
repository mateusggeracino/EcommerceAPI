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
    /// <summary>
    /// Esta classe é responsável por todos os comportamentos do
    /// carrinho de compra
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IShoppingCartServices _shoppingCartServices;
        private readonly IStockServices _stockServices;
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;
        private List<ShoppingCarts> shoppingCartsList = new List<ShoppingCarts>();

        public ShoppingCartsController(IShoppingCartServices shoppingCartservices, IStockServices stockServices,
                                        IMapper mapper, IOrderServices orderServices)
        {
            _shoppingCartServices = shoppingCartservices;
            _stockServices = stockServices;
            _orderServices = orderServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorno de todos os carrinhos de compras
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ShoppingCarts>> GetAll()
        {
            return _shoppingCartServices.List();
            //return Ok("success");
        }

        /// <summary>
        /// Retorno do carrinho de compras por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ShoppingCarts> Get(int id)
        {
            return _shoppingCartServices.GetById(id);
        }

        /// <summary>
        /// Inserção do carrinho de compras
        /// </summary>
        /// <param name="shoppingCartsViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ShoppingCarts> Post([FromBody] ShoppingCartsViewModel shoppingCartsViewModel)
        {
            return _shoppingCartServices.Insert(_mapper.Map<ShoppingCarts>(shoppingCartsViewModel));
        }

        /// <summary>
        /// Atualização do Carrinho de Compras
        /// </summary>
        /// <param name="shoppingCarts"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ShoppingCarts> Put([FromBody] ShoppingCarts shoppingCarts)
        {
            return _shoppingCartServices.Update(shoppingCarts);
        }

        /// <summary>
        /// Finalização do Carrinho de Compras
        /// </summary>
        /// <param name="shoppingCarts"></param>
        [HttpPatch]
        public void FinalizeShoppingCarts([FromBody] ShoppingCarts shoppingCarts)
        {
            shoppingCartsList = _shoppingCartServices.GetViewShoppingCarts(shoppingCarts.Id);
            ShoppingCarts shoppingCartView = shoppingCartsList.Where(x => x.Id == shoppingCarts.Id).FirstOrDefault();
            Order order = _orderServices.InsertOrder(shoppingCartView);
            UpdateShoppingCarts(shoppingCarts, order.Id);
            UpdateStockQuantityVirtual(shoppingCarts);
        }

        /// <summary>
        /// Método responsável por atualizar status
        /// e carUnitPrice do carrinho
        /// </summary>
        /// <param name="shoppingCarts"></param>
        /// <param name="orderId"></param>
        private void UpdateShoppingCarts(ShoppingCarts shoppingCarts, int orderId)
        {
            shoppingCarts.CartStatus = orderId;
            var unitPrice = shoppingCartsList.Where(x => x.Id == shoppingCarts.Id && x.CartProductId == shoppingCarts.CartProductId).FirstOrDefault();
            shoppingCarts.CartUnitPrice = unitPrice?.CartUnitPrice;
            _shoppingCartServices.Update(shoppingCarts);
        }

        /// <summary>
        /// Método responsável por atualizar a quantidade 
        /// virtual em stock
        /// </summary>
        private void UpdateStockQuantityVirtual(ShoppingCarts shoppingCarts)
        {
            //Stock stock = _stockServices.GetByProduct(shoppingCarts.CartStoreId, shoppingCarts.CartProductId);
            _stockServices.RemoveQuantityVirtual(shoppingCarts);
        }

    }
}