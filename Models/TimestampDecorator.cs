using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class TimestampDecorator : IPointsource
    {
        private readonly IPointsource _target;
        private DateTime _current = DateTime.Parse("01/01/1970");
        private TimeSpan _period = TimeSpan.FromSeconds(1);

        public string Name => _target.Name;
        public IEnumerable<IDatapoint> Datapoints { get; private set; }

        public TimestampDecorator(IPointsource target, DateTime? start, TimeSpan? period)
        {
            _target = target;
            _current = start ?? _current;
            _period = period ?? _period;

            Datapoints = _target.Datapoints.Select(Update);
        }

        private IDatapoint Update(IDatapoint point)
        {
            point.Timestamp = _current + _period;
            _current = point.Timestamp.Value;
            return point;
        }
    }
}
