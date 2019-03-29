using System.Collections.Generic;

namespace Models.Streams
{
    public class ConstantPointStream : BasePointStream
    {
        private double _value;

        public ConstantPointStream(string name, double value) : base(name)
        {
            _value = value;
        }

        public override IEnumerator<IDatapoint> GetEnumerator()
        {
            return Source().GetEnumerator();
        }

        private IEnumerable<IDatapoint> Source()
        {
            yield return new Datapoint { Value = _value };
        }
    }
}
