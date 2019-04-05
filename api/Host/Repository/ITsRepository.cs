using System.Collections.Generic;
using Timeseries.Api.Models;

namespace Timeseries.Api.Repository
{
    public interface ITsRepository
    {
        ITsDescription Create(TsDescription item);
        void Delete(int id);
        void Delete(TsDescription item);
        IEnumerable<ITsInfo> List();
        ITsDescription Read(int id);
        IEnumerable<ITsDescription> Read(string name);
        void Update(TsDescription item);
    }
}