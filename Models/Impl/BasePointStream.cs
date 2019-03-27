using System.Collections;
using System.Collections.Generic;

namespace Models.Impl
{
    public abstract class BasePointStream : IPointStream
    {
        public virtual string Name { get; protected set; }

        public abstract IEnumerator<IDatapoint> GetEnumerator();

        public BasePointStream() { }

        public BasePointStream(string name)
        {
            Name = name;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
