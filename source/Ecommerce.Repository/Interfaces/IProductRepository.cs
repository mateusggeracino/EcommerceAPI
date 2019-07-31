using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetByDescription(string value);

        List<Product> GetByBrand(string value);
    }
}
