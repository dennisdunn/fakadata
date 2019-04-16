using System.Collections.Generic;

namespace Timeseries.Api.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<object> List();
        T Create(T item);
        T Read(int id);
        T Read(string key);
        void Update(T item);
        void Delete(T item);
    }
}