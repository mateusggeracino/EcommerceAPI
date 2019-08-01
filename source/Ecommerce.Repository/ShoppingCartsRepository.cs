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
    public class ShoppingCartsRepository : Repository<ShoppingCarts> , IShoppingCartsRepository
    {
        public ShoppingCartsRepository(IConfiguration config, ILogger<Repository<ShoppingCarts>> logger) : base(config, logger)
        {
        }

        public ShoppingCarts InsertShoppingCarts(ShoppingCarts shoppingCarts)
        {
            try
            {
                string sqlQuery = "INSERT INTO [Transactions].[ShoppingCarts]([CartCustomerId],[CartStoreId],[CartProductId],[Quantity],[CartCreation],[CartExpiring],[CartStatus], [Id]) " +
                                "VALUES (@CartCustomerId,@CartStoreId,@CartProductId,@Quantity,@CartCreation,@CartExpiring,@CartStatus, @Id)";
                var parameters = new DynamicParameters();
                parameters.Add("@CartCustomerId", shoppingCarts.CartCustomerId);
                parameters.Add("@CartStoreId", shoppingCarts.CartStoreId);
                parameters.Add("@CartProductId", shoppingCarts.CartProductId);
                parameters.Add("@Quantity", shoppingCarts.Quantity);
                parameters.Add("@CartCreation", shoppingCarts.CartCreation);
                parameters.Add("@CartExpiring", shoppingCarts.CartExpiring);
                parameters.Add("@CartStatus", shoppingCarts.CartStatus);
                parameters.Add("@Id", shoppingCarts.Id);
                ExecuteQuery(sqlQuery, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return shoppingCarts;
        }

        public List<ShoppingCarts> GetByOrder(int orderId)
        {
            var query = "SELECT * FROM Transactions.ShoppingCarts WHERE CartStatus = @orderId";
            var parameters = new DynamicParameters();
            parameters.Add("@orderId", orderId);

            return ExecuteQuery(query, parameters);
        }

        public List<ShoppingCarts> GetViewShoppingCarts(int shoppingCartId)
        {
            var query = "SELECT *FROM Transactions.vw_ShoppingCart" +
                "        WHERE id = @shoppingCartId";
            var parameters = new DynamicParameters();
            parameters.Add("@shoppingCartId", shoppingCartId);

            return ExecuteQuery(query, parameters);
        }
    }
}
