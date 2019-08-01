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
        public ActionResult<string> GetAll()
        {
            _shoppingCartServices.List();
            return Ok("Success");
        }

        /// <summary>
        /// Retorno do carrinho de compras por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ShoppingCarts> Get(int id)
        {
            _shoppingCartServices.GetById(id);
            return Ok("Success");
        }

        /// <summary>
        /// Inserção do carrinho de compras
        /// </summary>
        /// <param name="shoppingCartsViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> Post([FromBody] ShoppingCartsViewModel shoppingCartsViewModel)
        {
            var shoppingCarts = _shoppingCartServices
                .Insert(_mapper.Map<ShoppingCarts>(shoppingCartsViewModel));

            if ( shoppingCarts != null )
                return Ok( "Success" );
            else
                return BadRequest( );
        }

        /// <summary>
        /// Atualização do Carrinho de Compras
        /// </summary>
        /// <param name="shoppingCarts"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<string> Put([FromBody] ShoppingCarts shoppingCarts)
        {
            _shoppingCartServices.Update(shoppingCarts);
            return Ok("Success");
        }

        /// <summary>
        /// Finalização do Carrinho de Compras
        /// </summary>
        /// <param name="shoppingCarts"></param>
        [HttpPatch]
        public void FinalizeShoppingCarts([FromBody] ShoppingCarts shoppingCarts)
        {
            var orderId = InsertOrder(shoppingCarts.Id);
            UpdateShoppingCarts(shoppingCarts, orderId);
            UpdateStockQuantityVirtual(shoppingCarts);
        }

        /// <summary>
        /// Método responsável por trazer dados do carrinho em uma view
        /// e chamar orderServices para inserir
        /// </summary>
        /// <param name="shoppingCarts"></param>
        /// <returns></returns>
        private int InsertOrder(int shoppingCartsId)
        {
            shoppingCartsList = _shoppingCartServices.GetViewShoppingCarts(shoppingCartsId);
            ShoppingCarts shoppingCartView = shoppingCartsList.Where(x => x.Id == shoppingCartsId).FirstOrDefault();
            Order order = _orderServices.InsertOrder(shoppingCartView);
            return order.Id;
        }

        /// <summary>
        /// Método responsável por atualizar status
        /// e carUnitPrice do carrinho
        /// </summary>
        /// <param name="shoppingCarts"></param>
        /// <param name="orderId"></param>
        private void UpdateShoppingCarts(ShoppingCarts shoppingCarts, int orderId)
        {
            // ** problema aqui **
            shoppingCarts.CartStatus = orderId;
            shoppingCarts.CartUnitPrice = shoppingCartsList.Where(x => x.Id == shoppingCarts.Id && x.CartProductId == shoppingCarts.CartProductId).FirstOrDefault().CartUnitPrice;
            _shoppingCartServices.Update(shoppingCarts);
        }

        /// <summary>
        /// Método responsável por atualizar a quantidade 
        /// virtual em stock
        /// </summary>
        private void UpdateStockQuantityVirtual(ShoppingCarts shoppingCarts)
        {
            Stock stock = _stockServices.GetByProduct(shoppingCarts.CartStoreId, shoppingCarts.CartProductId);
            _stockServices.RemoveQuantityVirtual(shoppingCarts);
        }

    }
}