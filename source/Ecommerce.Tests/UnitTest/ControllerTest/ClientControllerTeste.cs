using Ecommerce.Application.Controllers;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Ecommerce.Application.ViewModels;
using Ecommerce.Tests.Config;
using GenFu;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Ecommerce.Tests.UnitTest.ControllerTest
{
    [Trait( "Unit", "Client" )]
    public class ClientControllerUnitTest
    {
        [Fact(DisplayName = "Insert Sucess")]
        public void InsertSuccess()
        {
            var services = new Mock<IClientServices>();
            var logger = new Mock<ILogger<ClientController>>();
            var controller = new ClientController(services.Object, AutoMapperConfigTest.GetInstance(), logger.Object);

            var clientViewModel = A.New<ClientViewModel>();
            var clientEntity = A.New<Client>();

            services.Setup(x => x.Insert(It.IsAny<Client>())).Returns(clientEntity);

            var result = controller.Post(clientViewModel);

            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
