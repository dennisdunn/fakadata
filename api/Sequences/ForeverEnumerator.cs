using System;
using System.Collections;
using System.Collections.Generic;

namespace Timeseries.Api.Models.Collections
{
    public class ForeverEnumerator<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _target;

        public T Current => _target.Current;

        object IEnumerator.Current => Current;

        public ForeverEnumerator(IEnumerator<T> target)
        {
            _target = target;
        }

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
