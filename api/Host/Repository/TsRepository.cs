using LiteDB;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Models;

namespace Timeseries.Api.Repository
{
    public class TsRepository : ITsRepository
    {
        private readonly string _connectionString;

        public TsRepository(string connectionString)
        {
            _connectionString = connectionString;
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<TsDescription>("descriptions").EnsureIndex("Name");
            }
        }

        public IEnumerable<ITsInfo> List()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<TsDescription>("descriptions").FindAll().Select(x => new TsInfo { _id = x._id, Name = x.Name });
            }
        }

        public ITsDescription Create(TsDescription item)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<TsDescription>("descriptions").Upsert(item);
                return item;
            }
        }

        public ITsDescription Read(int id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<TsDescription>("descriptions").FindById(id);
            }
        }

        public ITsDescription Read(string name)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<TsDescription>("descriptions").FindOne(Query.EQ("Name", name));
            }
        }

        public void Update(TsDescription item)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<TsDescription>("descriptions").Upsert(item);
            }
        }

        public void Delete(ITsDescription item)
        {
            Delete(item._id);
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<TsDescription>("descriptions").Delete(id);
            }
        }
    }
}
