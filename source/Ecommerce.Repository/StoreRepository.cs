using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;

namespace Ecommerce.Repository
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository( IConfiguration config ) : base( config )
        {
        }
    }
}
