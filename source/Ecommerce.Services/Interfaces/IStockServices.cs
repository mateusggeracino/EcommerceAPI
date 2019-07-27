using System.Collections.Generic;
using Ecommerce.Domain.Models;

namespace Ecommerce.Services.Interfaces
{
    public interface IStockServices
    {
        Stock Insert(Stock stock);
        List<Stock> GetAll();
        bool Remove(int storeId, int productId);
        Stock Update(Stock map);
        Stock GetByProduct(int storeId, int productId);
        Stock RemoveQuantityVirtual(ShoppingCarts shopping);
        Stock RemoveQuantityRealVirtual(ShoppingCarts shopping);
    }
}