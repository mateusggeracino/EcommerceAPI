using System;
using System.Collections.Generic;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        T Insert(T obj);
        bool Remove(T obj);
        List<T> GetAll();
        T Update(T obj);
    }
}