using System.Collections.Generic;
using Ecommerce.Domain.Models;

namespace Ecommerce.Business.Interfaces
{
    public interface IStockBusiness
    {
        Stock Insert(Stock stock);
        List<Stock> GetAll();
    }
}