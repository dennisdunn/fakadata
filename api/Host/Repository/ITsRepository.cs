using System.Collections.Generic;
using Timeseries.Api.Models;

namespace Timeseries.Api.Repository
{
    public interface ITsRepository
    {
        ITsDescription Create(TsDescription item);
        void Delete(int id);
        void Delete(ITsDescription item);
        IEnumerable<ITsInfo> List();
        ITsDescription Read(int id);
        ITsDescription Read(string name);
        void Update(TsDescription item);
    }
}