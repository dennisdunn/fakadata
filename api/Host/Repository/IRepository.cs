using System.Collections.Generic;

namespace Timeseries.Api.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> List();
        T Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(int id);
    }
}