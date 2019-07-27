using System.Collections.Generic;
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
    }
}