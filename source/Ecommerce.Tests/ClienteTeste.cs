using Ecommerce.Domain.Models;
using Ecommerce.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ecommerce.Tests
{
    public class ClienteTeste
    {
        [Fact]
        public void ControllerTest()
        {
            var clienteservices = new Mock<ClientServices>();
            //var client = new Client({
            //    CustomerAddress = "",
            //    CustomerEmail = "",
            //    CustomerDocument = "",
            //    CustomerGender = "",
            //    CustomerName = "",
            //    CustomerTelephone = "",
            //    CustomerType = "",
            //    Id = 0,
            //});



        }
    }
}
