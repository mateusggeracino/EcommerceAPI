using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Repository
{
    public class StockRepository : Repository<Stock>,IStockRepository
    {
        public StockRepository(IConfiguration config, ILogger<Repository<Stock>> logger) : base(config, logger)
        {
        }
    }
}