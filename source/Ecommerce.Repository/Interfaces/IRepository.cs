using System;
using System.Collections.Generic;
using Dapper;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Interfaces
{
    public interface IRepository<T>  where T : Entity
    {
        T Insert(T obj);
        bool Remove(T obj);
        List<T> GetAll();
        T Update(T obj);
        T GetById(int id);
        List<T> ExecuteQuery(string query, DynamicParameters parameters);
    }
}