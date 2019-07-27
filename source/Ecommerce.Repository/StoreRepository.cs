using Microsoft.Extensions.Configuration;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Repository
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(IConfiguration config, ILogger<Repository<Store>> logger) : base( config, logger)
        {
        }
    }
}
