using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sequences
{
    public class PerpetualEnumerable<T> : IEnumerable<T>, IPerpetual<T>
    {
        private readonly RepeatingEnumerator<T> _enumerator;

        public PerpetualEnumerable(IEnumerable<T> target)
        {
            _enumerator = new RepeatingEnumerator<T>(target.ToList().GetEnumerator());
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
