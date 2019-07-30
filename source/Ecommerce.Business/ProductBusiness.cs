using Dapper;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class ProductBusiness : IProductBusiness
    {
        IProductRepository _productRepository;

        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool Insert(Product product)
        {
            _productRepository.Insert(product);
            return true;
        }

        public List<Product> ExecuteQueryId(string value)
        {
            return _productRepository.ExecuteQueryId(value);
        }

        public List<Product> ExecuteQueryDescription(string value)
        {
            return _productRepository.ExecuteQueryDescription(value);
        }

        public List<Product> ExecuteQueryBrand(string value)
        {
            return _productRepository.ExecuteQueryBrand(value);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
        public Product InsertProduct(Product obj)
        {
            return _productRepository.Insert(obj);
        }

        public bool RemoveProduct(Product obj)
        {
            return _productRepository.Remove(obj);
        }
        public Product Update(Product product)
        {
            return _productRepository.Update(product);
        }
    }
}
