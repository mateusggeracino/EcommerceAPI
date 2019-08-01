using Ecommerce.Business;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using GenFu;
using Moq;
using Xunit;

namespace Ecommerce.Tests.UnitTest.BusinessTest
{
    [Trait( "Unit", "Stock Business" )]
    public class StockBusinessTests
    {
        [Fact( DisplayName = "Insert success" )]
        public void InsertSuccess( )
        {
            var stockRepository = new Mock<IStockRepository>( );
            var stockBusiness = new StockBusiness( stockRepository.Object );
            var stock = A.New<Stock>( );
            stockRepository.Setup( x => x.Insert( It.IsAny<Stock>( ) ) ).Returns( stock );
            var result = stockBusiness.Insert( stock );

            Assert.NotNull( result );
            Assert.True( result.Id > 0 );
        }
    }
}