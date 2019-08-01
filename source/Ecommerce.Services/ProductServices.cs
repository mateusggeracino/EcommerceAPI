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

        public Product GetById(int id)
        {
            return _productBusiness.GetById(id);
        }

        public List<Product> GetByDescription(string query)
        {
            return _productBusiness.GetByDescription(query);
        }

        public List<Product> GetByBrand(string query)
        {
            return _productBusiness.GetByBrand(query);
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
