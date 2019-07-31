using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductBusiness _productBusiness;
        public ProductServices(IProductBusiness productbusiness)
        {
            _productBusiness = productbusiness;
        }

        public Product Insert(Product product)
        {
            return _productBusiness.Insert(product);
        }

        public List<Product> ExecuteQueryId(string query)
        {
            return _productBusiness.ExecuteQueryId(query);
        }

        public List<Product> ExecuteQueryDescription(string query)
        {
            return _productBusiness.ExecuteQueryDescription(query);
        }

        public List<Product> ExecuteQueryBrand(string query)
        {
            return _productBusiness.ExecuteQueryBrand(query);
        }

        public List<Product> GetAll()
        {
            return _productBusiness.GetAll();
        }
        public Product Update(Product product)
        {
            return _productBusiness.Update(product);
        }
    }
}
