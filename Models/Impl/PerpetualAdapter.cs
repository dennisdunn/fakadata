using System;
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

        object IEnumerator.Current => _target.Current;

        public bool MoveNext()
        {
            var success = _target.MoveNext();
            if (!success)
            {
                _target.Reset();
                success = _target.MoveNext();
            }
            return success;
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
