using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Models.Decorators
{
    public abstract class BasePointDecorator : IPointStream, IDecorator<IPointStream>
    {
        public string Name => Target.Name;

        public IPointStream Target { get; protected set; }
        public Func<IDatapoint, IDatapoint> Apply { get; protected set; }

        public BasePointDecorator() { }

        public BasePointDecorator(IPointStream target)
        {
            Target = target;
        }

        public BasePointDecorator(IPointStream target, Func<IDatapoint, IDatapoint> func) : this(target)
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
