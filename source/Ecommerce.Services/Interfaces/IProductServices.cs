using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IProductServices
    {
        Product Insert(Product product);

        Product GetById(int id);

        List<Product> GetByDescription(string description);

        List<Product> GetByBrand(string brand);

        List<Product> GetAll();

        Product Update(Product product);
    }
}
