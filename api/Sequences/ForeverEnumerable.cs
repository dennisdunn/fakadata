using System.Collections;
using System.Collections.Generic;

namespace Timeseries.Api.Models.Collections
{
    public class ForeverEnumerable<T> : IEnumerable<T>, IPerpetual<T>
    {
        private readonly ForeverEnumerator<T> _enumerator;

        public ForeverEnumerable(IEnumerable<T> target)
        {
            _enumerator = new ForeverEnumerator<T>(target.GetEnumerator());
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _enumerator;
        }
    }
}
