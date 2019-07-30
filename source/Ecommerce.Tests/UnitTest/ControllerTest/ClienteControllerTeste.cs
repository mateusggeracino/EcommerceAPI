using Ecommerce.Application.Controllers;
using Ecommerce.Domain.Models;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.Core.Logging;
using Ecommerce.Application.ViewModels;
using Ecommerce.Tests.Config;
using GenFu;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Ecommerce.Tests
{
    public class ClienteControllerTeste
    {
        [Fact]
        public void ControllerTest()
        {
            var services = new Mock<IClientServices>();
            var logger = new Mock<ILogger<ClientController>>();
            var controller = new ClientController(services.Object, AutoMapperConfigTest.GetInstance(), logger.Object);

            var client = A.New<ClientViewModel>();

            services.Setup(x => x.Insert(It.IsAny<Client>()));

            var result = controller.Post(client);

            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
