using System.Collections;
using System.Collections.Generic;

namespace Models.Impl
{
    public class PerpetualAdapter<T> : IEnumerator<T>
    {
        IEnumerator<T> _target;

        private PerpetualAdapter() { }

        public PerpetualAdapter(IEnumerator<T> target)
        {
            _target = target;
        }

        public T Current => _target.Current;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            var hasMoved = _target.MoveNext();

            if (hasMoved)
            {
                return hasMoved;
            }
            else
            {
                Reset();
                return _target.MoveNext();
            }
        }

        public void Reset()
        {
            _target.Reset();
        }

        public void Dispose()
        {
            _target.Dispose();
        }
    }
}
