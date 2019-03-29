using System.Collections;
using System.Collections.Generic;

namespace Models.Decorators
{
    public class PerpetualDecorator : BaseDecorator<IPointStream>, IPointStream
    {
        private readonly IEnumerator<IDatapoint> _enumerator;

        public string Name => Target.Name;

        public PerpetualDecorator(IPointStream target) : base(target)
        {
            _enumerator = new PerpetualAdapter<IDatapoint>(target.GetEnumerator());
        }

        public IEnumerator<IDatapoint> GetEnumerator()
        {
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _enumerator;
        }
    }
}
