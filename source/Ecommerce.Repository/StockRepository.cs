using System.Linq;
using Dapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Repository
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(IConfiguration config, ILogger<Repository<Stock>> logger) : base(config, logger)
        {
        }

        public Stock GetByStoreProduct(int storeId, int productId)
        {
            var query = "SELECT * FROM Products.Stock WHERE StockStoreId = @storeId and StockProductId = @productId";
            var parameters = new DynamicParameters();
            parameters.Add("@storeId", storeId);
            parameters.Add("@productId", productId);

            return ExecuteQuery(query,parameters).FirstOrDefault();
        }

        public override Stock Insert(Stock stock)
        {
            var query =
                "INSERT INTO Products.Stock(StockStoreId, StockProductId, RealStock, VirtualStock)" +
                " VALUES(@stockStoreId, @stockProductId, @realStock, @virtualStock)";
            var parameters = new DynamicParameters();
            parameters.Add("@stockStoreId", stock.StockStoreId);
            parameters.Add("@stockProductId", stock.StockProductId);
            parameters.Add("@realStock", stock.RealStock);
            parameters.Add("@virtualStock", stock.VirtualStock);

            ExecuteQuery(query, parameters);

            return stock;
        }
    }
}