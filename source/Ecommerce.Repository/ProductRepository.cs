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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IConfiguration config, ILogger<Repository<Product>> logger) : base(config, logger)
        {
        }

        public List<Product> GetAllProduct()
        {
            return GetAll();
        }

        public List<Product> ExecuteQueryId(string value)
        {
            var query = "select o.ProductType, o.ProductDescription, o.Brand, o.ProductSpecs" +
                        "from Products.Products o where o.Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", value);
            return ExecuteQuery(query, parameters);
        }

        public List<Product> ExecuteQueryDescription(string value)
        {
            var query = "select o.ProductType, o.ProductDescription, o.Brand, o.ProductSpecs" +
                        "from Products.Products o where o.ProductType like '%@ProductDescription%'";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductDescription", value);
            return ExecuteQuery(query, parameters);
        }

        public List<Product> ExecuteQueryBrand(string value)
        {
            var query = "select o.ProductType, o.ProductDescription, o.Brand, o.ProductSpecs" +
                        "from Products.Products o where o.ProductType like '%@Brand%'";
            var parameters = new DynamicParameters();
            parameters.Add("@Brand", value);
            return ExecuteQuery(query, parameters);
        }

    }
}
