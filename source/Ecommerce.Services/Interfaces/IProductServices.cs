using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IProductServices
    {
        Product Insert(Product product);

        List<Product> ExecuteQueryId(string query);

        List<Product> ExecuteQueryDescription(string query);

        List<Product> ExecuteQueryBrand(string query);

        List<Product> GetAll();

        Product Update(Product product);
    }
}
