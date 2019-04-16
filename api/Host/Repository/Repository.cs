using LiteDB;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Models;

namespace Timeseries.Api.Repository
{
    public class Repository<T> : IRepository<T> where T : IDocument
    {
        private readonly string _collectionName;
        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            _collectionName = nameof(T);
            _connectionString = connectionString;
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<T>(_collectionName).EnsureIndex("Name");
            }
        }

        public IEnumerable<object> List()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<T>(_collectionName).FindAll().Select(x => new { label = x.Name, value = x._id });
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

        public T Read(string key)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<T>(_collectionName).FindOne(q => q.Name == key);
            }
        }

        public void Update(T item)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<T>(_collectionName).Upsert(item);
            }
        }

        public void Delete(T item)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<T>(_collectionName).Delete(item._id);
            }
        }
    }
}
