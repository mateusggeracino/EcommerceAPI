using Dapper;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interfaces
{
    public interface IProductBusiness
    {
        bool Insert(Product product);

        List<Product> ExecuteQueryId(string query);

        List<Product> ExecuteQueryDescription(string query);

        List<Product> ExecuteQueryBrand(string query);

        List<Product> GetAll();

        Product Update(Product product);
    }
}
