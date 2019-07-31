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
        
        public List<Product> GetByDescription(string description)
        {
            var query = $"select o.ProductType, o.ProductDescription, o.Brand, o.ProductSpecs " +
                        $"from Products.Products o where o.ProductDescription like @ProductDescription";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductDescription", "%" + description + "%");
            return ExecuteQuery(query, parameters);
        }

        public List<Product> GetByBrand(string brand)
        {
            var query = $"select o.ProductType, o.ProductDescription, o.Brand, o.ProductSpecs " +
                        $"from Products.Products o where o.Brand like @Brand";
            var parameters = new DynamicParameters();
            parameters.Add("@Brand", "%" + brand + "%");
            return ExecuteQuery(query, parameters);
        }

    }
}
