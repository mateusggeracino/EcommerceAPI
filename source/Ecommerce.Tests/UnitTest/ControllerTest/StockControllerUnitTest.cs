using System.Collections.Generic;
using AutoMapper;
using Castle.Core.Logging;
using Ecommerce.Application.Controllers;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using Ecommerce.Tests.Config;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ecommerce.Tests.UnitTest.ControllerTest
{
    [Trait( "Unit", "Stock" )]
    public class StockControllerUnitTest
    {
        [Fact]
        public void InsertSuccess()
        {
            var stockServices = new Mock<IStockServices>();
            var logger = new Mock<ILogger<StockController>>();
            var stockController = new StockController(AutoMapperConfigTest.GetInstance(), stockServices.Object, logger.Object);
            var stockViewModel = A.New<StockViewModel>();
            var stockEntity = A.New<Stock>();

            stockServices.Setup(x => x.Insert(It.IsAny<Stock>())).Returns(stockEntity);

            var response = stockController.Insert(stockViewModel);
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response.Result);

            var httpObjResult = response.Result as OkObjectResult;

            Assert.NotNull(httpObjResult);
            Assert.True(httpObjResult.StatusCode == 200);

            var value = httpObjResult.Value;

            Assert.NotNull(value);
            Assert.False(string.IsNullOrWhiteSpace(value.ToString()));
            Assert.Same("success", value);
        }

        [Fact]
        public void InsertFail()
        {
            var stockServices = new Mock<IStockServices>();
            var logger = new Mock<ILogger<StockController>>();
            var stockController = new StockController(AutoMapperConfigTest.GetInstance(), stockServices.Object, logger.Object);
            var stockViewModel = A.New<StockViewModel>();
            var stockEntity = A.New<Stock>();

            stockServices.Setup(x => x.Insert(It.IsAny<Stock>())).Returns(stockEntity);
            stockController.ModelState.AddModelError("StockStoreId", "Is wrong");

            var response = stockController.Insert(stockViewModel);
            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response.Result);

            var httpObjResult = response.Result as BadRequestObjectResult;

            Assert.NotNull(httpObjResult);
            Assert.True(httpObjResult.StatusCode == 400);

            var value = httpObjResult.Value;

            Assert.NotNull(value);
            Assert.False(string.IsNullOrWhiteSpace(value.ToString()));
        }

        [Fact]
        public void GetAllSuccess()
        {
            var stockServices = new Mock<IStockServices>();
            var logger = new Mock<ILogger<StockController>>();
            var stockController = new StockController(AutoMapperConfigTest.GetInstance(), stockServices.Object, logger.Object);
            var stockEntity = A.ListOf<Stock>();

            stockServices.Setup(x => x.GetAll()).Returns(stockEntity);

            var response = stockController.GetAll();
            Assert.NotNull(response);

            Assert.IsType<OkObjectResult>(response.Result);

            var httpObjResult = response.Result as OkObjectResult;

            Assert.NotNull(httpObjResult);
            Assert.True(httpObjResult.StatusCode == 200);
        }

        [Fact]

        public void GetByProductSuccess()
        {
            var stockServices = new Mock<IStockServices>();
            var logger = new Mock<ILogger<StockController>>();
            var stockController = new StockController(AutoMapperConfigTest.GetInstance(), stockServices.Object, logger.Object);
            var stockEntity = A.New<Stock>();
            stockServices.Setup(x => x.GetByProduct(It.IsAny<int>(), It.IsAny<int>())).Returns(stockEntity);

            var response = stockController.GetByProduct(1, 1);
            Assert.NotNull(response);

            Assert.IsType<OkObjectResult>(response.Result);

            var httpObjResult = response.Result as OkObjectResult;

            Assert.NotNull(httpObjResult);
            Assert.NotNull(httpObjResult.Value);
            Assert.True(httpObjResult.StatusCode == 200);
        }

        [Fact]
        public void RemoveSuccess()
        {
            var stockServices = new Mock<IStockServices>();
            var logger = new Mock<ILogger<StockController>>();
            var stockController = new StockController(AutoMapperConfigTest.GetInstance(), stockServices.Object, logger.Object);
            stockServices.Setup(x => x.Remove(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            var response = stockController.Remove(1, 1);
            Assert.NotNull(response);

            Assert.IsType<OkObjectResult>(response);

            var httpObjResult = response as OkObjectResult;

            Assert.NotNull(httpObjResult);
            Assert.Same("success", httpObjResult.Value);
        }

        [Fact]
        public void UpdateSuccess()
        {
            var stockServices = new Mock<IStockServices>();
            var logger = new Mock<ILogger<StockController>>();
            var stockController = new StockController(AutoMapperConfigTest.GetInstance(), stockServices.Object, logger.Object);
            var stockEntity = A.New<Stock>();
            var stockViewModel = A.New<StockViewModel>();
            stockServices.Setup(x => x.Update(It.IsAny<Stock>())).Returns(stockEntity);
            var response = stockController.Update(stockViewModel);

            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);

            var httpObjResult = response as OkObjectResult;

            Assert.NotNull(httpObjResult);
            Assert.Same("success", httpObjResult.Value);
        }
    }
}