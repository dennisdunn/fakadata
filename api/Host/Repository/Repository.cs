using LiteDB;
using System.Collections.Generic;

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
                db.GetCollection<T>(_collectionName).EnsureIndex(doc => doc.Key);
            }
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

        public T Read(string key)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<T>(_collectionName).FindOne(doc => doc.Key == key);
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
