using Ecommerce.Application.Controllers;
using Ecommerce.Domain.Models;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ecommerce.Tests
{
    public class ClienteControllerTeste
    {
        [Fact]
        public void ControllerTest()
        {
            var services = new Mock<IClientServices>();
            var controller = new ClientController(services.Object);
            var client = new Client
            {
                CustomerAddress = "Rua",
                CustomerEmail = "Email",
                CustomerDocument = "123",
                CustomerGender = "12",
                CustomerName = "123",
                CustomerTelephone = "432",
                CustomerType = "A",
                Id = 0
            };

            services.Setup(x => x.Save(It.IsAny<Client>()));

            var result = controller.Post(client);

            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
