using Models;
using System.Collections;
using System.Collections.Generic;

namespace Engine
{
    public abstract class BaseGenerator<T> : ITsDescriptionDecorator, IGenerator<T>
    {
        public ITsDescription Target { get; protected set; }

        public T Current { get; protected set; }

        object IEnumerator.Current => Current;

        protected BaseGenerator() { }

        public BaseGenerator(ITsDescription target)
        {
            Target = target;
        }

        public abstract bool MoveNext();

        public abstract void Reset();

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
        }
    }
}
