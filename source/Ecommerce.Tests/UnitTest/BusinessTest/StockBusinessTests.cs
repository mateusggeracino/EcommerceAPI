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

        [Fact]
        public void GetAllSuccess()
        {
            var stockRepository = new Mock<IStockRepository>();
            var stockBusiness = new StockBusiness(stockRepository.Object);
            var stock = A.ListOf<Stock>();
            stockRepository.Setup(x => x.GetAll()).Returns(stock);
            var result = stockBusiness.GetAll();

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void GetByIdSuccess()
        {
            var stockRepository = new Mock<IStockRepository>();
            var stockBusiness = new StockBusiness(stockRepository.Object);
            var stock = A.New<Stock>();
            stockRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(stock);
            var result = stockBusiness.GetById(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateSuccess()
        {
            var stockRepository = new Mock<IStockRepository>();
            var stockBusiness = new StockBusiness(stockRepository.Object);
            var stock = A.New<Stock>();
            stockRepository.Setup(x => x.Update(It.IsAny<Stock>())).Returns(stock);
            var result = stockBusiness.Update(stock);

            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteSuccess()
        {
            var stockRepository = new Mock<IStockRepository>();
            var stockBusiness = new StockBusiness(stockRepository.Object);
            var stock = A.New<Stock>();
            stockRepository.Setup(x => x.Remove(It.IsAny<Stock>())).Returns(true);
            var result = stockBusiness.Remove(stock);

            Assert.True(result);
        }

        [Fact]
        public void GetByStoreProductSuccess()
        {
            var stockRepository = new Mock<IStockRepository>();
            var stockBusiness = new StockBusiness(stockRepository.Object);
            var stock = A.New<Stock>();
            stockRepository.Setup(x => x.GetByStoreProduct(It.IsAny<int>(), It.IsAny<int>())).Returns(stock);
            var result = stockBusiness.GetByStoreProduct(1,1);

            Assert.NotNull(result);
        }

        [Fact]
        public void RemoveQuantityVirtualSuccess()
        {
            var stockRepository = new Mock<IStockRepository>();
            var stockBusiness = new StockBusiness(stockRepository.Object);
            var stock = A.New<Stock>();
            var quantityVirtualStock = stock.VirtualStock;
            var shoppingCarts = A.New<ShoppingCarts>();
            stockRepository.Setup(x => x.GetByStoreProduct(It.IsAny<int>(), It.IsAny<int>())).Returns(stock);
            var result = stockBusiness.RemoveQuantityVirtual(shoppingCarts);

            var quantity = quantityVirtualStock - shoppingCarts.Quantity;
            Assert.NotNull(result);
            Assert.True(stock.VirtualStock == quantity);
        }

        [Fact]
        public void RemoveQuantityRealSuccess()
        {
            var stockRepository = new Mock<IStockRepository>();
            var stockBusiness = new StockBusiness(stockRepository.Object);
            var stock = A.New<Stock>();
            var quantityRealStock = stock.RealStock;
            var shoppingCarts = A.New<ShoppingCarts>();
            stockRepository.Setup(x => x.GetByStoreProduct(It.IsAny<int>(), It.IsAny<int>())).Returns(stock);
            var result = stockBusiness.RemoveQuantityReal(shoppingCarts);

            var quantity = quantityRealStock - shoppingCarts.Quantity;
            Assert.NotNull(result);
            Assert.True(stock.RealStock == quantity);
        }
    }
}