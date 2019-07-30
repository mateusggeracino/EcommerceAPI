using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> ExecuteQueryId(string value);

        List<Product> ExecuteQueryDescription(string value);

        List<Product> ExecuteQueryBrand(string value);
    }
}
