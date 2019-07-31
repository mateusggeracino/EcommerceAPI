using Dapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository
{
    public class PriceRepository : Repository<Price>, IPriceRepository
    {
        public PriceRepository(IConfiguration config, ILogger<Repository<Price>> logger) : base(config, logger)
        {
        }

        public List<Price> GetAllPrice()
        {
            return GetAll();
        }

        public List<Price> ExecuteQuery(int storeid, int productid)
        {
            var query = $"select Id,PriceStoreId, PriceProductId, Promotion, RegularPrice," +
                        $"PromotionalPrice,PriceGroup " +
                        $"from Products.Prices where PriceStoreId = @StoreId " +
                        $"and PriceProductId = @ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@StoreId", storeid);
            parameters.Add("@ProductId", productid);
            return ExecuteQuery(query, parameters);
        }
    }
}
