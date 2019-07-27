using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Interfaces
{
    public interface IStockRepository : IRepository<Stock>
    {
        Stock GetByStoreProduct(int storeId, int productId);
    }
}