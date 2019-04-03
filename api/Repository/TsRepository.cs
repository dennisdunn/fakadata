using LiteDB;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository
{
    public class TsRepository : ITsRepository
    {
        private readonly string _connectionString;

        private TsRepository(IConfiguration config) {
            _connectionString = config["connectionStrings:TsDefDb"];
        }

        public IEnumerable<ITsInfo> List()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                return db.GetCollection<TsDescription>("descriptions").FindAll().Select(Extensions.GetInfo);
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

        public IEnumerable<ITsDescription> Read(string name)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var collection = db.GetCollection<TsDescription>("descriptions");
                return collection.Find(item => item.Name.Contains(name, System.StringComparison.OrdinalIgnoreCase));
            }
        }

        public void Update(TsDescription item)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                db.GetCollection<TsDescription>("descriptions").Upsert(item);
            }
        }

        public void Delete(TsDescription item)
        {
            Delete(item.Id);
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
