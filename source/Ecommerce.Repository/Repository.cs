using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IConfiguration _config;
        private readonly ILogger<Repository<T>> _logger;

        public Repository(IConfiguration config, ILogger<Repository<T>> logger)
        {
            _config = config;
            _logger = logger;
        }

        private IDbConnection Conn => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public List<T> ExecuteQuery(string query, DynamicParameters parameters = null)
        {
            try
            {
                if (parameters == null)
                    return Conn.Query<T>(query).ToList();

                return Conn.Query<T>(query, parameters).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                if ((Conn != null) && (Conn.State != ConnectionState.Closed))
                {
                    Conn.Close();
                }
            }
        }

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

        public T GetById(int id)
        {
            return Conn.Get<T>(id);
        }

        public void Dispose() => Conn.Dispose();
    }
}