using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;

namespace Ecommerce.Business
{
    public class StockBusiness : IStockBusiness
    {
        private readonly IStockRepository _stockRepository;
        public StockBusiness(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public Stock Insert(Stock stock)
        {
            return _stockRepository.Insert(stock);
        }

        public List<Stock> GetAll()
        {
            return _stockRepository.GetAll();
        }

        public Stock GetById(int id)
        {
            return _stockRepository.GetById(id);
        }

        public bool Remove(Stock stock)
        {
            return _stockRepository.Remove(stock);
        }

        public Stock Update(Stock stock)
        {
            return _stockRepository.Update(stock);
        }

        public Stock GetByStoreProduct(int storeId, int productId)
        {
            return _stockRepository.GetByStoreProduct(storeId, productId);
        }

        public Stock RemoveQuantityReal(ShoppingCarts shopping)
        {
            var stock = _stockRepository.GetByStoreProduct(shopping.CartStoreId, shopping.CartProductId);

            stock.RealStock -= shopping.Quantity;

            _stockRepository.Update(stock);
            return stock;
        }

        public Stock RemoveQuantityVirtual(ShoppingCarts shopping)
        {
            var stock = _stockRepository.GetByStoreProduct(shopping.CartStoreId, shopping.CartProductId);

            stock.VirtualStock -= shopping.Quantity;

            _stockRepository.Update(stock);
            return stock;
        }
    }
}