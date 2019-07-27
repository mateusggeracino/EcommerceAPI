using System.Collections.Generic;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services
{
    public class StockServices : IStockServices
    {
        private readonly IStockBusiness _stockBusiness;
        public StockServices(IStockBusiness stockBusiness)
        {
            _stockBusiness = stockBusiness;
        }

        public Stock Insert(Stock stock)
        {
            return _stockBusiness.Insert(stock);
        }

        public List<Stock> GetAll()
        {
            return _stockBusiness.GetAll();
        }
    }
}