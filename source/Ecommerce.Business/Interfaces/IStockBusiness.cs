using System.Collections.Generic;
using Ecommerce.Domain.Models;

namespace Ecommerce.Business.Interfaces
{
    public interface IStockBusiness
    {
        Stock Insert(Stock stock);
        List<Stock> GetAll();
        Stock GetById(int id);
        bool Remove(Stock stock);
        Stock Update(Stock stock);
        Stock GetByStoreProduct(int storeId, int productId);
        Stock RemoveQuantityVirtual(ShoppingCarts shopping);
        Stock RemoveQuantityRealVirtual(ShoppingCarts shopping);
    }
}