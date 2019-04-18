using LiteDB;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Models;

namespace Timeseries.Api.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly string _collectionName;
        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            _collectionName = nameof(T);
            _connectionString = connectionString;
        }

        public IEnumerable<T> List()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<T>(_collectionName).FindAll();
            }
        }

        public T Create(T item)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<T>(_collectionName).Upsert(item);
                return item;
            }
        }

        public T Read(int id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<T>(_collectionName).FindById(id);
            }
        }

        public void Update(T item)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<T>(_collectionName).Upsert(item);
            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<T>(_collectionName).Delete(id);
            }
        }
    }
}
