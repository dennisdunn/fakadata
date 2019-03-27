using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Models.Impl
{
    public abstract class BaseDecorator : IPointStream, IPointStreamDecorator
    {
        public string Name => Target.Name;

        public IPointStream Target { get; protected set; }
        public Func<IDatapoint, IDatapoint> Apply { get; protected set; }

        public BaseDecorator() { }

        public BaseDecorator(IPointStream target)
        {
            Target = target;
        }

        public BaseDecorator(IPointStream target, Func<IDatapoint, IDatapoint> func) : this(target)
        {

            Apply = func;
        }

        public IEnumerator<IDatapoint> GetEnumerator()
        {
            return Target.Select(Apply).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
