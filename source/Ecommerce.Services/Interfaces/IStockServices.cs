﻿using System.Collections.Generic;
using Ecommerce.Domain.Models;

namespace Ecommerce.Services.Interfaces
{
    public interface IStockServices
    {
        Stock Insert(Stock stock);
        List<Stock> GetAll();
    }
}