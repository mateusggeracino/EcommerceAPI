using AutoMapper;
using Ecommerce.Application.Controllers;
using Ecommerce.Domain.Models;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Ecommerce.Tests.Config;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ecommerce.Tests.UnitTest.ControllerTest
{
    public class ShoppingCartsUnitTest
    {

        [Fact]
        public void InsertSuccess()
        {
            var shoppingCartsServices = new Mock<IShoppingCartServices>();
            var stockServices = new Mock<IStockServices>();
            //var shoppingCartsController = new ShoppingCartsController(shoppingCartsServices.Object, stockServices.Object);

            //shoppingCartsServices.Setup(x => x.Insert(It.IsAny<ShoppingCarts>())).Returns("success");

            //var shoppingCarts = A.New<ShoppingCarts>();

            //var response = shoppingCartsController.Post(shoppingCarts);
            //Assert.NotNull(response);
            //Assert.IsType<OkObjectResult>(response.Result);

            //var httpObjResult = response.Result as OkObjectResult;

            //Assert.NotNull(httpObjResult);
            //Assert.True(httpObjResult.StatusCode == 200);

            //var value = httpObjResult.Value;

            //Assert.NotNull(value);
            //Assert.False(string.IsNullOrWhiteSpace(value.ToString()));
            //Assert.Same("success", value);
        }

        [Fact]
        public void GetSuccess()
        {
            //var shoppingCartsServices = new Mock<IShoppingCartServices>();
            //var stockServices = new Mock<IStockServices>();
            //var shoppingCartsController = new ShoppingCartsController(shoppingCartsServices.Object, stockServices.Object);

            //var shoppingCartsList = A.ListOf<ShoppingCarts>();

            //shoppingCartsServices.Setup(x => x.List()).Returns(shoppingCartsList);

            //var response = shoppingCartsController.Get();
            //Assert.NotNull(response);
            //Assert.IsType<OkObjectResult>(response.Result);

            //var httpObjResult = response.Result as OkObjectResult;

            //Assert.NotNull(httpObjResult);
            //Assert.True(httpObjResult.StatusCode == 200);
        }

        [Fact]
        public void GetByIdSuccess()
        {
            //var shoppingCartsServices = new Mock<IShoppingCartServices>();
            //var stockServices = new Mock<IStockServices>();
            //var shoppingCartsController = new ShoppingCartsController(shoppingCartsServices.Object, stockServices.Object);

            //var shoppingCarts = A.New<ShoppingCarts>();

            //shoppingCartsServices.Setup(x => x.GetById(1)).Returns(shoppingCarts);

            //var response = shoppingCartsController.Get(1);
            //Assert.NotNull(response);
            //Assert.IsType<OkObjectResult>(response.Result);

            //var httpObjResult = response.Result as OkObjectResult;

            //Assert.NotNull(httpObjResult);
            //Assert.True(httpObjResult.StatusCode == 200);
        }

        [Fact]
        public void UpdateSuccess()
        {
            //var shoppingCartsServices = new Mock<IShoppingCartServices>();
            //var stockServices = new Mock<IStockServices>();
            //var shoppingCartsController = new ShoppingCartsController(shoppingCartsServices.Object, stockServices.Object);

            //var shoppingCarts = A.New<ShoppingCarts>();
            //shoppingCartsServices.Setup(x => x.Update(It.IsAny<ShoppingCarts>())).Returns("success");
            //var response = shoppingCartsController.Put(shoppingCarts);

            //Assert.NotNull(response);
            //Assert.IsType<OkObjectResult>(response.Result);

            //var httpObjResult = response.Result as OkObjectResult;

            //Assert.NotNull(httpObjResult);
            //Assert.Same("success", httpObjResult.Value);

            //var value = httpObjResult.Value;

            //Assert.NotNull(value);
            //Assert.False(string.IsNullOrWhiteSpace(value.ToString()));
            //Assert.Same("success", value);
        }
    }
}
