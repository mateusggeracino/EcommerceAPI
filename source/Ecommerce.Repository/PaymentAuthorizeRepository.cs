using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ecommerce.Repository
{
    public class PaymentAuthorizeRepository : IPaymentAuthorizeRepository
    {
        private readonly IConfiguration _config;

        public PaymentAuthorizeRepository(IConfiguration config)
        {
            _config = config;
        }

        protected IDbConnection Conn => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public vw_PaymentOrther GetByPayment(int orther)
        {
            return Conn.Get<vw_PaymentOrther>(orther);
        }

        public void UpdadeStock(int obj)
        {
            var query = "update Products.Stock " +
                        "set RealStock = a.RealStock - b.Quantity " +
                        "from " +
                        "Products.Stock A " +
                        "inner join " +
                        "Transactions.ShoppingCarts B on A.Id = B.CartProductId " +
                        "where " +
                        "   b.CartStatus = @";

        }
    }
}
