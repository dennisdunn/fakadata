using System.Collections.Generic;

namespace Models
{
    public class ConstantPointsource : IPointsource
    {
        private double _value;

        public string Name { get; private set; }

        public IEnumerable<IDatapoint> Datapoints => Source();

        public ConstantPointsource(string name, double value)
        {
            Name = name;
            _value = value;
        }

        private IEnumerable<IDatapoint> Source()
        {
            yield return new Datapoint { Value = _value };
        }
    }
}
