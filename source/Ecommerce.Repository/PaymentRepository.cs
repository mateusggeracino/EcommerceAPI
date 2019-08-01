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
    public class PaymentRepository : Repository<Payments>, IPaymentRepository
    {
        public PaymentRepository(IConfiguration config, ILogger<Repository<Payments>> logger) : base(config, logger)
        {

        }

        public void Updatestatus(Payments payment, int status)
        {
            var query = $"update Transactions.Payments set PayTransactionId = @status, PayStatus = @paystatus where OrderId = @payorder";
            var parameters = new DynamicParameters();
            parameters.Add("@status", status);
            parameters.Add("@paystatus", payment.PayStatus);
            parameters.Add("@payorder", payment.OrderId);
            ExecuteQuery(query, parameters);
        }
    }
}
