using Ecommerce.Application.Controllers;
using Ecommerce.Application.ViewModels;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using Ecommerce.Tests.Config;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Tests.UnitTest.ControllerTest
{
    [Trait( "Unit", "Payment Method" )]
    public class PaymentMethodControllerUnitTest
    {
        [Fact( DisplayName = "Insert payment method" )]
        public void InsertPaymentMethod( )
        {
            PaymentMethodViewModel paymentMethodViewModel = A.New<PaymentMethodViewModel>( );

            Mock<IPaymentMethodService> mockPaymentMethodService = new Mock<IPaymentMethodService>( );

            mockPaymentMethodService
                .Setup( ( a ) => a.Add( It.IsAny<PaymentMethod>( ) ) )
                .Returns( true );
                
            PaymentMethodController paymentMethodController = new PaymentMethodController( AutoMapperConfigTest.GetInstance( ), mockPaymentMethodService.Object );

            var result = paymentMethodController.Post( paymentMethodViewModel ) ;

            var httpObjResult = result.Result as OkObjectResult;

            Assert.NotNull( httpObjResult );
            Assert.True( httpObjResult.StatusCode == 200 );

            var value = httpObjResult.Value;

            Assert.NotNull( value );
            Assert.False( string.IsNullOrWhiteSpace( value.ToString( ) ) );
            Assert.Same( "success", value );
        }
    }
}
