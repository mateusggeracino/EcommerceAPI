using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Repository
{
    public class Repository<T> : IDisposable, IRepository<T> where T : Entity
    {
        private readonly IConfiguration _config;

        public Repository(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection Conn => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public T Insert(T obj)
        {
            Conn.Insert(obj);
            return obj;
        }

        public bool Remove(T obj)
        {
            return Conn.Delete(obj);
        }

        public List<T> GetAll()
        {
            return Conn.GetAll<T>().ToList();
        }

        public T Update(T obj)
        {
            Conn.Update(obj);
            return obj;
        }

        public void Dispose() => Conn.Dispose();
    }
}