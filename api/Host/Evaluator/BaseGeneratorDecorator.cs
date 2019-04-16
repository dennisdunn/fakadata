using System;
using System.Collections;
using System.Collections.Generic;
using Timeseries.Api.Models;

namespace Timeseries.Api.Evaluator
{
    public abstract class BaseGeneratorDecorator<T> : ITsDescriptionDecorator, IGenerator<T>
    {
        public ITsDescription Target { get; protected set; }

        public T Current { get; protected set; }

        object IEnumerator.Current => Current;

        protected BaseGeneratorDecorator() { }

        public BaseGeneratorDecorator(ITsDescription target)
        {
            Target = target;
        }

        public abstract bool MoveNext();

        public virtual void Reset()
        {
            throw new InvalidOperationException();
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Dispose()
        {
        }
    }
}
