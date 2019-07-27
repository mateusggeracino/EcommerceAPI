using AutoMapper;
using Castle.Core.Logging;
using Ecommerce.Application.Controllers;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ecommerce.Tests.UnitTest.ControllerTest
{
    public class StockControllerUnitTest
    {
        private StockViewModel StockView()
        {
            return  new StockViewModel
            {
                Id = 1,
                StockStoreId = 1,
                StockProductId = 2,
                VirtualStock = 25,
                RealStock = 35
            };
        }
        private Stock StockEntity()
        {
            return new Stock
            {
                Id = 1,
                StockStoreId = 1,
                StockProductId = 2,
                VirtualStock = 25,
                RealStock = 35
            };
        }

        [Fact]
        public void InsertSuccess()
        {
            var stockServices = new Mock<IStockServices>();
            var mapper = new Mock<IMapper>();
            var logger = new Mock<ILogger<StockController>>();
            var stockController = new StockController(mapper.Object, stockServices.Object, logger.Object);
            
            stockServices.Setup(x => x.Insert(It.IsAny<Stock>())).Returns(StockEntity());
            mapper.Setup(x => x.Map<StockViewModel>(It.IsAny<Stock>())).Returns(StockView());
            mapper.Setup(x => x.Map<Stock>(It.IsAny<StockViewModel>())).Returns(StockEntity());

            var response = stockController.Insert(StockView());
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response.Result);

            var httpObjResult = response.Result as BadRequestObjectResult;

            Assert.NotNull(httpObjResult);
            Assert.True(httpObjResult.StatusCode == 200);

            var value = httpObjResult.Value;

            Assert.NotNull(value);
            Assert.False(string.IsNullOrWhiteSpace(value.ToString()));
            Assert.Same("success", value);
        }
        public void InsertFail()
        {
            var stockServices = new Mock<IStockServices>();
            var mapper = new Mock<IMapper>();
            var logger = new Mock<ILogger<StockController>>();
            var stockController = new StockController(mapper.Object, stockServices.Object, logger.Object);
            
            stockServices.Setup(x => x.Insert(It.IsAny<Stock>())).Returns(StockEntity());
            mapper.Setup(x => x.Map<StockViewModel>(It.IsAny<Stock>())).Returns(StockView());
            mapper.Setup(x => x.Map<Stock>(It.IsAny<StockViewModel>())).Returns(StockEntity());

            var response = stockController.Insert(StockView());
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

    }
}