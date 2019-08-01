using AutoMapper;
using Ecommerce.Application.Controllers;
using Ecommerce.Application.ViewModels;
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
    [Trait( "Unit", "Shopping Carts" )]
    public class ShoppingCartsUnitTest
    {

        [Fact(DisplayName = "Insert success")]
        public void InsertSuccess()
        {
            var shoppingCartsServices = new Mock<IShoppingCartServices>();
            var stockServices = new Mock<IStockServices>();

            var shoppingCartsController = new ShoppingCartsController( shoppingCartsServices.Object, stockServices.Object, AutoMapperConfigTest.GetInstance( ) );

            shoppingCartsServices
                .Setup( x => x.Insert( It.IsAny<ShoppingCarts>( ) ) )
                .Returns( "Success" );

            var shoppingCartsViewModel = A.New<ShoppingCartsViewModel>( );

            var response = shoppingCartsController.Post( shoppingCartsViewModel );

            Assert.NotNull( response );
            Assert.IsType<OkObjectResult>( response.Result );

            var httpObjResult = response.Result as OkObjectResult;

            Assert.NotNull( httpObjResult );
            Assert.True( httpObjResult.StatusCode == 200 );

            var value = httpObjResult.Value;

            Assert.NotNull( value );
            Assert.False( string.IsNullOrWhiteSpace( value.ToString( ) ) );
            Assert.Same( "Success", value );
        }

        [Fact(DisplayName = "Get successs")]
        public void GetSuccess()
        {
            var shoppingCartsServices = new Mock<IShoppingCartServices>( );
            var stockServices = new Mock<IStockServices>( );
            var shoppingCartsController = new ShoppingCartsController( shoppingCartsServices.Object, stockServices.Object, AutoMapperConfigTest.GetInstance( ) );

            var shoppingCartsList = A.ListOf<ShoppingCarts>( );

            shoppingCartsServices.Setup( x => x.List( ) ).Returns( shoppingCartsList );

            var response = shoppingCartsController.Get( );
            Assert.NotNull( response );
            Assert.IsType<OkObjectResult>( response.Result );

            var httpObjResult = response.Result as OkObjectResult;

            Assert.NotNull( httpObjResult );
            Assert.True( httpObjResult.StatusCode == 200 );
        }

        [Fact(DisplayName = "Get by id success")]
        public void GetByIdSuccess()
        {
            var shoppingCartsServices = new Mock<IShoppingCartServices>( );
            var stockServices = new Mock<IStockServices>( );
            var shoppingCartsController = new ShoppingCartsController( shoppingCartsServices.Object, stockServices.Object, AutoMapperConfigTest.GetInstance( ) );

            var shoppingCarts = A.New<ShoppingCarts>( );

            shoppingCartsServices.Setup( x => x.GetById( 1 ) ).Returns( shoppingCarts );

            var response = shoppingCartsController.Get( 1 );
            Assert.NotNull( response );
            Assert.IsType<OkObjectResult>( response.Result );

            var httpObjResult = response.Result as OkObjectResult;

            Assert.NotNull( httpObjResult );
            Assert.True( httpObjResult.StatusCode == 200 );
        }

        [Fact(DisplayName = "Update success")]
        public void UpdateSuccess()
        {
            var shoppingCartsServices = new Mock<IShoppingCartServices>( );
            var stockServices = new Mock<IStockServices>( );
            var shoppingCartsController = new ShoppingCartsController( shoppingCartsServices.Object, stockServices.Object, AutoMapperConfigTest.GetInstance( ) );

            var shoppingCarts = A.New<ShoppingCarts>( );
            shoppingCartsServices.Setup( x => x.Update( It.IsAny<ShoppingCarts>( ) ) ).Returns( "success" );
            var response = shoppingCartsController.Put( shoppingCarts );

            Assert.NotNull( response );
            Assert.IsType<OkObjectResult>( response.Result );

            var httpObjResult = response.Result as OkObjectResult;

            Assert.NotNull( httpObjResult );
            Assert.Same( "Success", httpObjResult.Value );

            var value = httpObjResult.Value;

            Assert.NotNull( value );
            Assert.False( string.IsNullOrWhiteSpace( value.ToString( ) ) );
            Assert.Same( "Success", value );
        }
    }
}
