using Dapper;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Domain.Validations;

namespace Ecommerce.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _productRepository;

        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Insert(Product product)
        {
            var productValidation = new ProductValidation();
            product.ValidationResult = productValidation.Validate(product);

            if (product.ValidationResult.Errors.Any()) return product;

            return _productRepository.Insert(product);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetByDescription(string description)
        {
            return _productRepository.GetByDescription(description);
        }

        public List<Product> GetByBrand(string brand)
        {
            return _productRepository.GetByBrand(brand);
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
