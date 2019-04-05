using System.Collections.Generic;

namespace Timeseries.Api.Evaluator
{
    public interface IGenerator<T> : IEnumerable<T>, IEnumerator<T>
    {
    }
}
