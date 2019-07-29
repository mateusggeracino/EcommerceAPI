using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ecommerce.Repository
{
    public class PaymentAuthorizeRepository<T> : IPaymentAuthorizeRepository
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
            
            
        }


    }
}
