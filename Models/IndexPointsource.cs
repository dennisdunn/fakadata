using System.Collections.Generic;

namespace Models
{
    public class IndexPointsource : IPointsource
    {
        private int _idx;

        public string Name => "Index";

        public IEnumerable<IDatapoint> Datapoints => Source();

        private IEnumerable<IDatapoint> Source()
        {
            yield return new Datapoint { Value = _idx++ };
        }
    }
}
