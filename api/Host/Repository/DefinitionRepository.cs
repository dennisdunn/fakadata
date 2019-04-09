using LiteDB;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Models;

namespace Timeseries.Api.Repository
{
    public class DefinitionRepository : IDefinitionRepository
    {
        private readonly string _connectionString;

        public DefinitionRepository(string connectionString)
        {
            _connectionString = connectionString;
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<Definition>("descriptions").EnsureIndex("Name");
            }
        }

        public IEnumerable<object> List()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<Definition>("descriptions").FindAll().Select(x => new { label = x.Name, value = x._id });
            }
        }

        public IDefinition Create(Definition item)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<Definition>("descriptions").Upsert(item);
                return item;
            }
        }

        public IDefinition Read(int id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<Definition>("descriptions").FindById(id);
            }
        }

        public IDefinition Read(string name)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<Definition>("descriptions").FindOne(Query.EQ("Name", name));
            }
        }

        public void Update(Definition item)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<Definition>("descriptions").Upsert(item);
            }
        }

        public void Delete(IDefinition item)
        {
            Delete(item._id);
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<Definition>("descriptions").Delete(id);
            }
        }
    }
}
